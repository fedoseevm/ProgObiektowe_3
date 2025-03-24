using System;
using System.Collections.Generic;
using AnimalApp.Models;
using AnimalApp.Services;

namespace AnimalApp

{
	internal class Program
	{
		static void Main(string[] args)
		{
			AnimalManager manager = new AnimalManager();

			Dog dog = new Dog("Reksio");
			Cat cat = new Cat("Mruczek");

			manager.AddAnimal(dog);
			manager.AddAnimal(cat);

			Console.WriteLine("\nDźwięki zwierząt:");

			manager.MakeAllSounds();
		}
	}
}