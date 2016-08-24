using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using System.Net;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails shippinginfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");
                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Products.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})\n",
                        line.Quantity,
                        line.Products.Name,
                        subtotal);
                }
                body.AppendFormat("Total order value: {0:c}",
                    cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippinginfo.Name)
                    .AppendLine(shippinginfo.Line1)
                    .AppendLine(shippinginfo.Line2)
                    .AppendLine(shippinginfo.Line3)
                    .AppendLine(shippinginfo.City)
                    .AppendLine(shippinginfo.State)
                    .AppendLine(shippinginfo.Country)
                    .AppendLine(shippinginfo.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippinginfo.GiftWrap ? "Yes" : "No");
                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "New order submitted!",
                    body.ToString());
                smtpClient.Send(mailMessage);
            }
        }

        
    }
}
