using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedoseev_Maksim.Classes
{
	internal class Vehicle
	{
		public string Brand { get; set; }
		public string Model { get; set; }

		public virtual void DisplayInfo()
		{
            Console.WriteLine($"\nPojazd {Brand} {Model}");
        }
	}
}
