using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia_1.src.Services {
    public class PasswordManager {
        private const string passwordFilePath = "userPasswords.txt";
        public static event Action<string, bool> PasswordVerified;

        static PasswordManager() {
            if (!File.Exists(passwordFilePath)) {
                File.Create(passwordFilePath).Dispose();
            }
        }

        public static void SavePassword(string username, string password) {
            if (File.ReadLines(passwordFilePath).Any(line => line.Split(',')[0] == username)) {
                Console.WriteLine($"Użytkownik {username} już ustnieje w systemie");
                return;
            }

            string hashedPassword = HashPassword(password);
            File.AppendAllText(passwordFilePath, $"{username},{hashedPassword}\n");
            Console.WriteLine($"Użytkownik {username} został zapisany");
        }

        private static string HashPassword(string password) {
            using (var sha256 = SHA256.Create()) {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public static bool VerifyPassword(string username, string password) {
            string hashedPassword = HashPassword(password);

            foreach (var line in File.ReadLines(passwordFilePath)) {
                var parts = line.Split(',');
                if (parts[0] == username && parts[1] == hashedPassword) {
                    PasswordVerified?.Invoke(username, true);
                    return true;
                }
            }
            PasswordVerified?.Invoke(username, false);
            return false;
        }
    }
}
