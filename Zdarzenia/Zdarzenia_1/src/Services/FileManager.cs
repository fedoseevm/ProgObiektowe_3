using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia_1.src.Services {
    internal class FileManager {
        public static void ReadFile(string filePath) {
            if (File.Exists(filePath)) {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Zawartość pliku:\n" + content);
            }
            else {
                Console.WriteLine("Plik nie instnieje");
            }
        }

        public static void WriteToFile(string filePath) {
            Console.Write("Podaj tekst do zapisania w pliku:\n>");
            string text = Console.ReadLine();
            File.WriteAllText(filePath, text);
            Console.WriteLine("Zapisano do pliku");
        }

        public static void ModifyFile(string filePath) {
            if (File.Exists(filePath)) {
                Console.Write("Podaj tekst do zapisania w pliku:\n>");
                string text = Console.ReadLine();
                File.AppendAllText(filePath, text);
                Console.WriteLine("Zmodyfikowano plik");
            } else {
                Console.WriteLine("Plik nie instnieje");
            }
        }

        public static void AddNewUser() {
            Console.Write("Podaj nazwę użytkownika: ");
            string newUserName = Console.ReadLine();

            Console.Write("Podaj hasło użytkownika");
            string newPassword = Console.ReadLine();

            PasswordManager.SavePassword(newUserName, newPassword);
            Console.WriteLine($"Dodano nowego użytkownika: {newUserName}");
        }
    }
}
