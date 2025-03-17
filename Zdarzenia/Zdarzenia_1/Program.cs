using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zdarzenia_1.src.Enums;
using Zdarzenia_1.src.Models;
using Zdarzenia_1.src.Services;

namespace Zdarzenia_1 {
	internal class Program {
		static void Main(string[] args) {
			PasswordManager.PasswordVerified += (name, success) => Console.WriteLine($"Logowanie użytkownika {name}: {(success ? "udane" : "nieudane")}");

            PasswordManager.SavePassword("admin", "pass");
            PasswordManager.SavePassword("manager", "pass");
            PasswordManager.SavePassword("normalUser", "pass");
            PasswordManager.SavePassword("xyz", "pass");


            Console.WriteLine("Logowanie udane");

			bool exitProgram = false;
			
			while (!exitProgram) {
				Console.Clear();
				Console.WriteLine("---- System logowania ----");

                Console.Write("\nWprowadź użytkownika: ");
                string username = Console.ReadLine();

                Console.Write("\nWprowadź hasło: ");
                string password = Console.ReadLine();

                if (!PasswordManager.VerifyPassword(username, password)) {
					Console.WriteLine("Niepoprawna nazwa użytkownika lub hasło.");
					Console.ReadKey();
					continue;
                }

                var user = new User(username);

                if (username == "admin") {
                    user.AddRole(Role.Administrator);
                } else if (username == "manager") {
                    user.AddRole(Role.Manager);
                } else if (username == "normalUser") {
                    user.AddRole(Role.User);
                }

                var rbacSystem = new RBAC();
				string filePath = "testFile.txt";

				bool loggedIn = true;
				while (loggedIn) {
					Console.Clear();
                    Console.WriteLine($"Zalogowano jako: {username}\n");

					Console.WriteLine("Wybierz opcję: ");
                    Console.WriteLine("1. Odczytaj plik");
					if (rbacSystem.HasPermission(user, Permission.Write))
						Console.WriteLine("2. Zapisz do pliku");
					if (rbacSystem.HasPermission(user, Permission.Delete))
						Console.WriteLine("3. Modyfikuj plik");
					if (rbacSystem.HasPermission(user, Permission.ManageUsers))
						Console.WriteLine("4. Dodaj użytkownika");
					Console.WriteLine("5. Wyloguj się");
                    Console.WriteLine("6. Wyjdź z programu");

					int choice;
					if (!int.TryParse(Console.ReadLine(), out choice) && choice < 1 && choice > 6) {
						Console.WriteLine("Niepoprawna wybór. Spróbuj ponownie");
						continue;
					}

					switch (choice) {
						case 1:
							FileManager.ReadFile(filePath);
							break;
						case 2:
							if (rbacSystem.HasPermission(user, Permission.Write))
								FileManager.WriteToFile(filePath);
							break;
						case 3:
							if (rbacSystem.HasPermission(user, Permission.Delete))
								FileManager.ModifyFile(filePath);
							break;
						case 4:
							if (rbacSystem.HasPermission(user, Permission.ManageUsers))
								FileManager.AddNewUser();
							break;
						case 5:
							Console.WriteLine("wylogowano");
							loggedIn = false;
							break;
						case 6:
							Console.WriteLine("Zamykanie programu");
							Environment.Exit(0);
							break;
					}
					Console.ReadKey();
				}
				Console.ReadKey();
			}
		}
	}
}
