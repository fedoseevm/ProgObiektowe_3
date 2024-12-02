using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty_2
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
                if (Notify == null)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomień");
                }
                Notify?.Invoke(message);    // ? sprawdza, czy Notify jest null
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Dodaj powiadomienie Email");
            Console.WriteLine("2. Dodaj powiadomienie SMS");
            Console.WriteLine("3. Dodaj powiadomienie Push");
            Console.WriteLine("4. Usuń powiadomienie Email");
            Console.WriteLine("5. Usuń powiadomienie SMS");
            Console.WriteLine("6. Usuń powiadomienie Push");
            Console.WriteLine("7. Wyślij powiadomienie");
            Console.WriteLine("8. Wyjdź");
            Console.Write("Wybierz opcję: ");
        }
        static void Main(string[] args)
        {
            // Tworzenie instancji klas powiadomień
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            // Tworzenie instancji klasy
            var notifiationManager = new NotificationManager();

            while (true)
            {
                try
                {
                    ShowMenu();
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            notifiationManager.AddNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("Dodano powiadomienie Email\n");
                            break;
                        case "2":
                            notifiationManager.AddNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Dodano powiadomienie SMS\n");
                            break;
                        case "3":
                            notifiationManager.AddNotificationMethod(pushNotifier.SendPushNotification);
                            Console.WriteLine("Dodano powiadomienie Push\n");
                            break;
                        case "4":
                            notifiationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("Usunięto powiadomienie Email\n");
                            break;
                        case "5":
                            notifiationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Usunięto powiadomienie SMS\n");
                            break;
                        case "6":
                            notifiationManager.RemoveNotificationMethod(pushNotifier.SendPushNotification);
                            Console.WriteLine("Usunięto powiadomienie Push\n");
                            break;
                        case "7":
                            Console.WriteLine("Wpisz wiadomość do wysłania:");
                            var message = Console.ReadLine();
                            notifiationManager.SendNotification(message);
                            break;
                        case "8":
                            return;
                        default:
                            Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("\n Wystąpił błąd: {0}", exception);
                }
            }
        }
    }
}
