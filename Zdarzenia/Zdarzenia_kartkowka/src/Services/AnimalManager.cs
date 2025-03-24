using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalApp.Models;

namespace AnimalApp.Services
{
	public class AnimalManager
	{
		private List<Animal> animals = new List<Animal>();

		public void AddAnimal(Animal animal)
		{
			animals.Add(animal);
			Console.WriteLine($"Dodano zwierzę: {animal.Name} ({animal.Type})");
		}

		public void MakeAllSounds()
		{
			foreach (var animal in animals)
			{
				animal.MakeSound();
			}
		}
	}
}
