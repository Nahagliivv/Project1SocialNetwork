using System;
using System.Collections.Generic;
using System.Linq;
using MimeKit;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace CourseProjectOOPVer2._0.Logic
{
    public class SendCodeToEmail
    {
        public static string SendEmailWithCode(string email)
        {
            string code = GenerateCode();
            string body = "Код для регистрации: ";
            MailAddress from = new MailAddress("do.sviazy@mail.ru", "До связи");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to)
            {
                Subject = "Социальная сеть",
                Body = body + code,
                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25)
            {
                Credentials = new NetworkCredential("do.sviazy@mail.ru", "Qwertyuiop123Qw"),
                EnableSsl = true
            };
            try
            {
                smtp.Send(m);
            }
            catch { }
            return code;
        }
        private static string GenerateCode()
        {
            string data = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            string code = "";
            Random rand = new Random();
            for(int i =0; i < 6; i++)
            {
                code += data[rand.Next(0, 36)];
            }
            return code;
        }
    }
}
