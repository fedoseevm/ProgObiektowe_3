using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalApp.Enums;

namespace AnimalApp.Models
{
	public class Dog : Animal
	{
		public Dog(string name) : base(name, AnimalType.Dog) { }

		public override void MakeSound()
		{
			Console.WriteLine($"{Name} szczeka: Hau hau!");
		}
	}
}
