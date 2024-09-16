using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedoseev_Maksim.Classes
{
	internal class Motorcycle : Vehicle
	{
		public bool HasSidecar { get; set; }
		public Motorcycle(string brand, string model, bool hasSidecar)
		{
			Brand = brand;
			Model = model;
			HasSidecar = hasSidecar;
		}
		public override void DisplayInfo()
		{
			base.DisplayInfo();
			if (HasSidecar)
			{
                Console.WriteLine("Posiada wózek boczny");
            }
			else
			{
                Console.WriteLine("Nie posiada bocznego wózka");
            }
		}
	}
}
