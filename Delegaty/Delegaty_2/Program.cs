using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty_2
{
    internal class Program
    {
        public delegate void NotificationHandler(string message);
        public interface INotifier
        {
            void Notify(string message);
        }

        public class EmailNotifier : INotifier
        {
			public void Notify(string message)
            {
                try
                {
					Console.WriteLine("Email wyslany: {0}", message);
				}
                catch (Exception exception)
                {
					Console.WriteLine("Błąd podczas wysyłania Emaila: {0}", exception);
				}
            }

            //public void SendEmail(string message)
            //{
            //    Console.WriteLine("Email wyslany: {0}", message);
            //}
        }

        public class SMSNotifier
        {
			public void Notify(string message)
			{
				try
				{
					Console.WriteLine("SMS wyslany: {0}", message);
				}
				catch (Exception exception)
				{
					Console.WriteLine("Błąd podczas wysyłania SMSa: {0}", exception);
				}
			}
			//public void SendSMS(string message)
			//{
			//    Console.WriteLine("SMS wyslany: {0}", message);
			//}
		}

        public class PushNotifier
        {
			public void Notify(string message)
			{
				try
				{
					Console.WriteLine("Powiadomienie PUSH wyslane: {0}", message);
				}
				catch (Exception exception)
				{
					Console.WriteLine("Błąd podczas wysyłania powiadomienia PUSH: {0}", exception);
				}
			}

			//public void SendPushNotification(string message)
			//{
			//    Console.WriteLine("Powiadomienie PUSH wyslane: {0}", message);
			//}
		}

        public class NotificationManager
        {
            public NotificationHandler Notify;
            public void AddNotificationMethod(NotificationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Console.WriteLine("Ta metoda powiadamiania jest już dodana");
                    return;
                }
                Notify += handler;
                Console.WriteLine("Dodano metodę powiadamiania");
            }
            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Notify -= handler;
                    Console.WriteLine("Usunięto metodę powiadamiania");
                }
            }
            public void SendNotification(string message)
            {
                if (Notify == null)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomień. Dodaj co najmniej jedną metodę");
                    return;
                }

                // Iteracja po wszystkich dodanych metodach i zapysywanie wysyłania w log.txt
                foreach (var handler in Notify.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(message); // DynamicInvoke() - używamy, gdy typy parametrów są znane 
                        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Wysłano: {handler.Method.Name}, wiadomość: {message}\n";
                        File.AppendAllText("log.txt", logEntry);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Błąd podczas wysyłania powiadomienia: {0}", exception);
                    }
                }
                //Notify?.Invoke(message);    // ? sprawdza, czy Notify jest null
            }

            public void ListNotificationMethods()
            {
                if (Notify == null)
                {
					Console.WriteLine("Brak dostępnych metod powiadomień. Dodaj co najmniej jedną metodę");
					return;
				}

                Console.WriteLine("Zarejestrowane metody powiadomień: ");
                var displayedHandlers = new HashSet<string>();

                foreach (var handler in Notify.GetInvocationList())
                {
                    var target = handler.Target;
                    var methodName = handler.Method.Name;
                    var className = target?.GetType().Name ?? "Nieznany";

                    var uniqueKey = $"{className}.{methodName}";

                    if (!displayedHandlers.Contains(uniqueKey))
                    {
                        displayedHandlers.Add(uniqueKey);
                        Console.WriteLine($"- Klasa {className}, metoda {methodName}");
                    }
                }
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
            var notificationManager = new NotificationManager();

            while (true)
            {
                try
                {
                    ShowMenu();
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            notificationManager.AddNotificationMethod(emailNotifier.Notify);
                            Console.WriteLine("Dodano powiadomienie Email\n");
                            Console.ReadKey();
                            break;
                        case "2":
                            notificationManager.AddNotificationMethod(smsNotifier.Notify);
                            Console.WriteLine("Dodano powiadomienie SMS\n");
							Console.ReadKey();
							break;
                        case "3":
                            notificationManager.AddNotificationMethod(pushNotifier.Notify);
                            Console.WriteLine("Dodano powiadomienie Push\n");
							Console.ReadKey();
							break;
                        case "4":
                            notificationManager.RemoveNotificationMethod(emailNotifier.Notify);
                            Console.WriteLine("Usunięto powiadomienie Email\n");
							Console.ReadKey();
							break;
                        case "5":
                            notificationManager.RemoveNotificationMethod(smsNotifier.Notify);
                            Console.WriteLine("Usunięto powiadomienie SMS\n");
							Console.ReadKey();
							break;
                        case "6":
                            notificationManager.RemoveNotificationMethod(pushNotifier.Notify);
                            Console.WriteLine("Usunięto powiadomienie Push\n");
							Console.ReadKey();
							break;
                        case "7":
                            Console.Write("Wpisz wiadomość do wysłania: ");
                            var message = Console.ReadLine();
                            notificationManager.SendNotification(message);
							Console.ReadKey();
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
