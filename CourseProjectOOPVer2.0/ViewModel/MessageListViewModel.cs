using CourseProjectOOPVer2._0.Interfaces;
using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class MessageListViewModel : ViewModelBase, IMessageListRealization
    {
        private List<User> UsersHoHaveDialog;
        public ObservableCollection<MessageHistoryViewModel> MessageHistory { get; set; }
        List<MessageHistoryViewModel> copyList;
        private string _SearchText { get; set; } = "";
        public string SearchText { get { return _SearchText; } set { _SearchText = value; OnPropertyChanged("SearchText"); } }
        public Visibility MsgStatusVis { get; set; } = Visibility.Collapsed;
        public MessageListViewModel()
        {
            copyList = new List<MessageHistoryViewModel>();
            MessageHistory = new ObservableCollection<MessageHistoryViewModel>();
            UsersHoHaveDialog = new List<User>();
            MainSearch();
            _Search();
        }
        void MainSearch()
        {
            MessageHistory.Clear();
            copyList.Clear();
            
            using (var db = new DataBaseContext())
            {
                List<long> interlocutorsIds = new List<long>();
                var allDialogs = db.Dialogs.ToList();
                var sortAllDialogs = allDialogs.OrderByDescending(x => x.DateSendLastMessage);
                var dialogs = sortAllDialogs.Where(x => x.User1.Id == Model.CurrentUser.CurrentUserID || x.User2.Id == Model.CurrentUser.CurrentUserID);
                if (dialogs.Count() == 0)
                {
                    MsgStatusVis = Visibility.Visible;
                    return;
                }
                foreach (var x in dialogs)
                {
                    if (x.User1.Id != CurrentUser.CurrentUserID)
                    {
                        interlocutorsIds.Add(x.User1.Id);
                        continue;
                    }
                    if (x.User2.Id != Model.CurrentUser.CurrentUserID)
                    {
                        interlocutorsIds.Add(x.User2.Id);
                        continue;
                    }
                }
                foreach (var z in interlocutorsIds)
                {
                    foreach (var x in db.Users)
                    {
                        if (x.Id == z)
                        {
                            UsersHoHaveDialog.Add(x);
                            break;
                        }
                    }
                }
                interlocutorsIds.Clear();
            }
            foreach (var x in UsersHoHaveDialog)
            {
                copyList.Add(new MessageHistoryViewModel(x));
            }
        }
        public ICommand Search
        {
            get { return new DelegateCommand(() => { MainSearch(); _Search(); }); }
        }
        void _Search()
        {
            var reg = new Regex(SearchText.ToLower());
            foreach(var x in copyList)
            {
                if (reg.IsMatch(x.UserName.ToLower()))
                {
                    MessageHistory.Add(x);
                }
            }
            UsersHoHaveDialog.Clear();
        }
    }
}
