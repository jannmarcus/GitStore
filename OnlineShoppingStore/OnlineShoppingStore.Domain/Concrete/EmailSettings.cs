using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "kaceymanalac@gmail.com";
        public string MailFromAddress = "kaceymanalac@gmail.com";
        public bool UseSsl = true;
        public string Username = "kaceymanalac@gmail.com";
        public string Password = "123456789";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;

    }
}
