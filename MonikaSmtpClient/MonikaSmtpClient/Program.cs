
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MonikaSmtpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SmtpClient client = new SmtpClient())
            {
                //Tutaj dane dostępowe należy podać :
                var credential = new NetworkCredential
                {
                    UserName = "monikatestpop3@o2.pl",
                    Password = "pop3pop3pop3"
                };
                client.Credentials = credential;

                
                //dostawca musi udostępnić nam host oraz port poczty
                client.Host = "poczta.o2.pl";
                client.Port = 587;
                client.EnableSsl = true;

                //Tworzę nową wiadomość
                var message = new MailMessage();

                //Odbiorca
                message.To.Add(new MailAddress("meilOdbiorcy@xxxxxx.pl"));
                //Nadawca
                message.From = new MailAddress("monikatestpop3@o2.pl");
                //Tytuł nowej wiadomości
                message.Subject = "PS LAB N2 ZIMA 2018/19 GRA14";
                message.Body = "Monika ";
              
                message.IsBodyHtml = true; // true żeby móc użyć znaczników html

               //Jeżeli chcielibyśmy wysłać jakiś załącznik
                /*Attachment a = new Attachment("zdjecie.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
                message.Attachments.Add(a);*/

                client.Send(message);
                Console.WriteLine("Wiadomość została wysłana.");
            }
            Console.ReadKey();
        }
    }
}
