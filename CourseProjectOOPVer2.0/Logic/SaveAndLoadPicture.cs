using CourseProjectOOPVer2._0.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace CourseProjectOOPVer2._0.Logic
{
    public class SaveAndLoadPicture
    {
        public static byte[] PictureToByte(string filename) //преобразование картинки в байт по пути
        {
            byte[] pic;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                pic = new byte[fs.Length];
                fs.Read(pic, 0, pic.Length);
            }
            return pic;
        }
       public static BitmapImage LoadImage(byte[] imageData)// преобразование байтов в картинку
        {
            try
            {
                if (imageData == null || imageData.Length == 0) return null;
                var image = new BitmapImage();
                using (var mem = new MemoryStream(imageData))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
            catch { 
                using(var db = new Model.DB.DataBaseContext())
                {
                    string imagePath = "pack://application:,,,/logo1.png";//картинка по умолчанию
                    StreamResourceInfo imageInfo = System.Windows.Application.GetResourceStream(new Uri(imagePath));
                    var curUImg = db.Imgs.Where(x => x.Id == CurrentUser.CurrentUserID).First();
                    curUImg.Data = SaveAndLoadPicture.ReadFully(imageInfo.Stream);
                    db.SaveChanges();
                    return SaveAndLoadPicture.LoadImage(curUImg.Data);
                }
            }
                
        }
        public static byte[] ReadFully(Stream input)///преобразование потока в картинку, метод нужен для чтения изображения по умолчанию из проекта, а не из внешнего файла
        {
            byte[] buffer = new byte[16 * 128];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
      
    }
}
