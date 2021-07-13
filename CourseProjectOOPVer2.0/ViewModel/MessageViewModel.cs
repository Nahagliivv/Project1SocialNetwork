using CourseProjectOOPVer2._0.Interfaces;
using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class MessageViewModel: ViewModelBase, IMessageRealization
    {
        private ObservableCollection<MessageViewModel> ParentRef;
        private Model.Message Message;
        private bool checkEdit { get; set; } = false;
        private Brush _EditColor { get; set; }
        public Brush EditColor { get { return _EditColor; } set { _EditColor = value; OnPropertyChanged("EditColor"); } }
        private string _MessageText { get; set; }
        private bool _IsReadOnly { get; set; }
        public bool IsReadOnly { get { return _IsReadOnly; } set { _IsReadOnly = value; OnPropertyChanged("IsReadOnly"); } }
        public string MessageText { get { return _MessageText; } set { _MessageText = value; OnPropertyChanged("MessageText"); } }
        public DateTime PublicDate { get; set; }
        public string UserFullName { get; set; }
        public Visibility MessageMenagement { get; set; } = Visibility.Hidden;
        private ImageSource _EditStatus { get; set; }
        public ImageSource EditStatus { get { return _EditStatus; } set { _EditStatus = value; OnPropertyChanged("EditStatus"); } }
        public MessageViewModel(Model.Message message, ObservableCollection<MessageViewModel> reff)
        {
            EditColor = Brushes.White;
            IsReadOnly = true;
            EditStatus = (new ImageSourceConverter()).ConvertFromString(@"pack://application:,,,/styles/IcnsPic/EditPen.png") as ImageSource;
            Message = message;
            ParentRef = reff;
            MessageText = message.Text;
            PublicDate = message.SendDate;
            UserFullName = message.Username;
            if(Message.UserId == Model.CurrentUser.CurrentUserID)
            {
                MessageMenagement = Visibility.Visible;
                return;
            }
        }
        public ICommand DeleteMessage
        {
            get
            {
                return new DelegateCommand(() => { Delete(); });
            }
        }
        void Delete()
        {
            var accept = MessageBox.Show("Вы действительно хотите удалить сообщение без возможности восстановления?", "Удаление сообщения", MessageBoxButton.YesNo);
            if (accept != MessageBoxResult.Yes)
            {
                return;
            }
            ParentRef.Remove(this);
            using(var db = new Model.DB.DataBaseContext())
            {
                db.Messages.Attach(Message);
                db.Messages.Remove(Message);
                db.SaveChanges();
                var currentDialog = db.Dialogs.Where(x => x.Id == Message.DialogId).First();
                if (db.Messages.Count(x=>x.DialogId ==Message.DialogId) == 0)
                {
                    db.Dialogs.Remove(currentDialog);
                    db.SaveChanges();
                    return;
                }
                var allMessages = db.Messages.Where(x => x.DialogId == currentDialog.Id);
                var lastMessage = allMessages.OrderByDescending(x => x.SendDate).First();
                currentDialog.DateSendLastMessage = lastMessage.SendDate;
                db.SaveChanges();
            }
        }
        public ICommand EditMessage
        {
            get
            {
                return new DelegateCommand(() => { Edit(); });
            }
        }
        void Edit()
        {
            if (!checkEdit)
            {
                checkEdit = true;
                IsReadOnly = false;
                EditStatus = (new ImageSourceConverter()).ConvertFromString(@"pack://application:,,,/styles/IcnsPic/OK.png") as ImageSource;
                EditColor = Brushes.LightGreen;
                return;
            }
            if (checkEdit)
            {
                if(MessageText ==""||MessageText == null)
                {
                    return;
                }
                EditStatus = (new ImageSourceConverter()).ConvertFromString(@"pack://application:,,,/styles/IcnsPic/EditPen.png") as ImageSource;
                checkEdit = false;
                IsReadOnly = true;
                using (var db = new DataBaseContext())
                {
                    var editMessage = db.Messages.Where(x => x.Id == Message.Id).FirstOrDefault();
                    editMessage.Text = MessageText;
                    db.SaveChanges();
                }
                EditColor = Brushes.White;
                return;
            }
        }
    }
}
