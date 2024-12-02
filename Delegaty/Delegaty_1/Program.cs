using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty_1
{
    internal class Program
    {
        public delegate void NotificationHandler(string message);

        public class EmailNotifier
        {
            public void SendEmail(string message)
            {
                Console.WriteLine("Email wyslany: {0}", message);
            }
        }
        
        public class SMSNotifier
        {
            public void SendSMS(string message)
            {
                Console.WriteLine("SMS wyslany: {0}", message);
            }
        }

        public class PushNotifier
        {
            public void SendPushNotification(string message)
            {
                Console.WriteLine("Powiadomienie PUSH wyslane: {0}", message);
            }
        }

        public class NotificationManager
        {
            public NotificationHandler Notify;
            public void AddNotificationMethod(NotificationHandler handler)
            {
                Notify += handler;
            }
            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                Notify -= handler;
            }
            public void SendNotification(string message)
            {
                Notify?.Invoke(message);    // ? sprawdza, czy Notify jest null
            }
        }

        static void Main(string[] args)
        {
            // Delegary reprezentują referencje do metod

            // Tworzenie instancji klas powiadomień
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            // Tworzenie instancji klasy
            var notifiationManager = new NotificationManager();

            // Dodawanie metod powiadomień do delegata
            notifiationManager.AddNotificationMethod(emailNotifier.SendEmail);
            notifiationManager.AddNotificationMethod(smsNotifier.SendSMS);
            notifiationManager.AddNotificationMethod(pushNotifier.SendPushNotification);

            // Wysyłanie powiadomienia
            notifiationManager.SendNotification("Witaj, to jest testowe powiadomienie");

            // Usuwanie metody powiadomienia SMS
            notifiationManager.RemoveNotificationMethod(smsNotifier.SendSMS);

            Console.WriteLine("\n");
            // Wysłanie powiadomienia ponownie
            notifiationManager.SendNotification("Kolejne testowe powiadomienie");

        }
    }
}
