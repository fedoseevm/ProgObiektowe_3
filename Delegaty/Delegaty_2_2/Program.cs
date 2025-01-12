namespace Delegaty_2_2
{
	internal class Program
	{
		public delegate void NotificationHandler(string message);
		public class User
		{
			public string Name { get; set; }
			public int Priority {  get; set; }

		}
		public interface INotifier
		{
			void Notify(string message);
		}

		public class EmailNotifier : INotifier
		{
			public void Notify(string message)
			{
                Console.WriteLine("Email wysłany: {0}", message);
            }
		}
		public class SMSNotifier : INotifier
		{
			public void Notify(string message)
			{
				Console.WriteLine("SMS wysłany: {0}", message);
			}
		}
		public class PushNotifier : INotifier
		{
			public void Notify(string message)
			{
				Console.WriteLine("Powiadomienie PUSH wysłane: {0}", message);
			}
		}
		public class NotificationManager
		{
			public NotificationHandler Notify;
			private Dictionary<string, User> users = new Dictionary<string, User>();
			private List<INotifier> notifiers = new List<INotifier>();

			public void AddUser(string name, int priority)
			{
				if (!users.ContainsKey(name))
				{
					users[name] = new User() { Name = name, Priority = priority };
					Console.WriteLine($"Dodano użytkownika {name} z priorytetem {priority}");
				}
				else
				{
                    Console.WriteLine($"Użytkownik {name} już istnieje!");
                }
			}

			public void RemoveUser(string name)
			{
				if (users.Remove(name))
				{
                    users.Remove(name);
                    Console.WriteLine($"Usunięto użytkownika: {name}");
                }
				else
				{
                    Console.WriteLine($"Użytkownik {name} nie istnieje");
                }
			}

			public User GetUserByName(string name)
			{
				if (users.TryGetValue(name, out User user))
				{
					return user;
				}
				return null;
			}

			public void ListUsers()
			{
				if (users.Count == 0)
				{
					Console.WriteLine("Brak użytkowników");
					return;
				}

                Console.WriteLine("Lista użytkowników: ");
				int index = 1;
				foreach (var user in users)
				{
                    Console.WriteLine($"{index}. {user.Value.Name} (priorytet: {user.Value.Priority})");
					index++;
                }
            }

			public void SendNotification(string message, int priority)
			{
				if (notifiers.Count == 0)
				{
					Console.WriteLine("Brak dostępnych metod powiadomień");
					return;
				}

				var filteredUsers = new List<User>(users.Values).FindAll(u => u.Priority <= priority);
				
				if (filteredUsers.Count == 0)
				{
                    Console.WriteLine($"Brak użytkowników z priorytetem równym lub wyższym niż {priority}");
					return;
                }

                Console.WriteLine($"Wiadomość: \"{message}\"");
				//foreach (var notifier in notifiers)
				//{
				//	notifier.Notify(message);
				//}
				Notify.Invoke(message);

				Console.WriteLine("\nPowiadomienie zostało wysłane do: ");
				foreach (var user in filteredUsers)
				{
                    Console.WriteLine($" - {user.Name} (priorytet: {user.Priority})");
                }
			}

			public void AddNotifier(INotifier notifier)
			{
				if (!notifiers.Contains(notifier))
				{
					notifiers.Add(notifier);
					Notify += notifier.Notify;
                    Console.WriteLine("Metoda powiadomienia została dodana");
                }
				else
				{
                    Console.WriteLine("Ta metoda powiadomienia już istnieje");
                }
			}

			public void RemoveNotifier(INotifier notifier)
			{
				if (notifiers.Contains(notifier))
				{
					notifiers.Remove(notifier);
                    Notify -= notifier.Notify;
                    Console.WriteLine("Metoda powiadomienia zostałą usunięta");
                }
				else
				{
                    Console.WriteLine("Nie znaleziono tej metody powiadomienia");
                }
			}

			public void ListNotifiers()
			{
				if (notifiers.Count == 0)
				{
					Console.WriteLine("Brak dostępnych metod powiadomień");
					return;
				}

				Console.WriteLine("Dostępne meotdy powidamiania: ");
				foreach (var notifier in notifiers)
				{
                    Console.WriteLine($" - {notifier.GetType().Name}");
                }
			}
		}

		static void Main(string[] args)
		{
			var notificationManager = new NotificationManager();

			var emailNotifier = new EmailNotifier();
			var smsNotifier = new SMSNotifier();
			var pushNotifier = new PushNotifier();

			while (true)
			{
				Console.WriteLine("\nMenu");
				Console.WriteLine("1. Dodaj użytkownika");
				Console.WriteLine("2. Usuń użytkownika");
				Console.WriteLine("3. Wyślij powiadomienie do użytkownika");
				Console.WriteLine("4. Wyświetl użytkowników");
				Console.WriteLine("5. Dodaj metodę powiadomień");
				Console.WriteLine("6. Usuń metodę powiadomień");
				Console.WriteLine("7. Wyświetl metody powiadomień");
				Console.WriteLine("8. Wyjdź");

				Console.Write("\nWyberz opcję: ");
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
                        Console.Write("Podaj imię użytkownika: ");
						string name = Console.ReadLine();

						int priority = GetValidPriority("Podaj priorytet użytkownika (liczba całkowita od 1 do 3: ");
                        notificationManager.AddUser(name, priority);
						break;
					case "2":
                        Console.Write("Podaj imię użytkownika, którego chcesz usunąć: ");
						notificationManager.RemoveUser(Console.ReadLine());
                        break;
					case "3":
                        Console.Write("Wpisz swoją wiadomość: ");
                        string message = Console.ReadLine();

                        priority = GetValidPriority("Podaj priorytet użytkowników, do których będzie wysłana wiadomość (liczba całkowita od 1 do 3: ");
						notificationManager.SendNotification(message, priority);
						break;
					case "4":
						notificationManager.ListUsers();
                        break;
					case "5":
                        Console.WriteLine("Wybierz metodę powiadamiania: ");
                        Console.WriteLine("\t1. Email");
                        Console.WriteLine("\t2. SMS");
                        Console.WriteLine("\t3. Powiadomienie PUSH");

                        Console.Write("\nWyberz opcję: ");
						choice = Console.ReadLine();
						switch (choice)
						{
							case "1":
								notificationManager.AddNotifier(emailNotifier);
								break;
							case "2":
								notificationManager.AddNotifier(smsNotifier);
								break;
							case "3":
								notificationManager.AddNotifier(pushNotifier);
								break;
							default:
                                Console.WriteLine("Nieprawidłowy wybór. Naciśnij dowolny klawisz");
								Console.ReadKey();
								break;
                        }
						break;
					case "6":
                        Console.WriteLine("Wybierz metodę powiadamiania do usunięcia: ");
                        Console.WriteLine("\t1. Email");
                        Console.WriteLine("\t2. SMS");
                        Console.WriteLine("\t3. Powiadomienie PUSH");

                        Console.Write("\nWyberz opcję: ");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                notificationManager.RemoveNotifier(emailNotifier);
                                break;
                            case "2":
                                notificationManager.RemoveNotifier(smsNotifier);
                                break;
                            case "3":
                                notificationManager.RemoveNotifier(pushNotifier);
                                break;
                            default:
                                Console.WriteLine("Nieprawidłowy wybór. Naciśnij dowolny klawisz");
                                Console.ReadKey();
                                break;
                        }
                        break;
					case "7":
						notificationManager.ListNotifiers();
                        break;
					case "8":
						return;
					default:
                        Console.WriteLine("Błędne dane. Wybierz poprawną opcję");
						break;
                }
			}
		}

        private static int GetValidPriority(string prompt)
        {
            while (true)
			{
                Console.Write(prompt);
				if (int.TryParse(Console.ReadLine(), out int result) && result >= 1 && result <= 3)
				{
					return result;
				}
				else
				{
                    Console.WriteLine("Błędne dane. Spróbuj ponownie\n");
                }
            }
        }
    }
}