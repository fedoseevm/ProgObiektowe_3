using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedoseev_Maksim.Classes
{
	internal class Car : Vehicle
	{
		public int NumberOfDoors;
		public Car(string brand, string model, int numberOfDoors)
		{
			Brand = brand;
			Model = model;
			NumberOfDoors = numberOfDoors;
		}
		public override void DisplayInfo()
		{
			base.DisplayInfo();
            Console.WriteLine("Ilość drzwi: {0}", NumberOfDoors);
        }
	}
}
