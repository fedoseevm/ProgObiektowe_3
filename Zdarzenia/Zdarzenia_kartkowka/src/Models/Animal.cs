using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalApp.Enums;

namespace AnimalApp.Models
{
	public class Animal
	{

		public string Name { get; set; }

		public AnimalType Type { get; set; }

		public Animal(string name, AnimalType type)
		{
			Name = name;
			Type = type;
		}

		public virtual void MakeSound()
		{
			Console.WriteLine($"{Name} wydaje dźwięk.");
		}
	}
}
