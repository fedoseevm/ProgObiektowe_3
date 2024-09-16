using Fedoseev_Maksim.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedoseev_Maksim
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.Write("Podaj markę samochodu: ");
            string brand = Console.ReadLine();
			Console.Write("Podaj model samochodu: ");
			string model = Console.ReadLine();
			int iloscDrzwi = GetValidInput("Podaj ilość drzwi: ");
			Car car = new Car(brand, model, iloscDrzwi);

			Console.Write("\nPodaj markę motoru: ");
			brand = Console.ReadLine();
			Console.Write("Podaj model motoru: ");
			model = Console.ReadLine();
            Console.Write("Wpisz [T], jeśli motor posiada wózek boczny: ");
			bool hasSidecar = Console.ReadLine().ToLower() == "t";

			Motorcycle motor = new Motorcycle(brand, model, hasSidecar);

			car.DisplayInfo();
            motor.DisplayInfo();
			Console.ReadKey();
		}

		private static int GetValidInput(string prompt)
		{
            while (true)
			{
				Console.Write(prompt);
				if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
				{
					return result;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy format danych");
					Console.ResetColor();
                }
			}
		}
	}
}
