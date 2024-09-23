using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziedziczenie_1
{
    internal class Program
    {
        class Shape
        {
            public virtual float CalculateArea()
            {
                return 0;
            }
            public virtual float CalculatePerimeter()
            {
                return 0;
            }
        }
        class Rectangle : Shape
        {
            private float width;
            private float height;

            public void SetDimensions(float w, float h)
            {
                width = w;
                height = h;
            }
            public override float CalculateArea()
            {
                //return base.CalculateArea();
                return width * height;
            }
            public override float CalculatePerimeter()
            {
                return 2 * (height + width);
            }
        }
        class Circle : Shape
        {
            private float radius;
            public Circle(float r)
            {
                radius = r;
            }
            public void SetRadius(float r)
            {
                radius = r;
            }
            public override float CalculateArea()
            {
                return (float)Math.Round((Math.PI * radius * radius), 2);
            }
            public override float CalculatePerimeter()
            {
                return (float)Math.Round((2 * Math.PI * radius), 2);
            }
        }

        class Triangle : Shape
        {
            private float sideA;
            private float sideB;
            private float sideC;

            public Triangle(float sideA, float sideB, float sideC)
            {
                this.sideA = sideA;
                this.sideB = sideB;
                this.sideC = sideC;
            }
			public override float CalculateArea()
			{
                float s = (sideA + sideB + sideC) / 2;
                return (float)Math.Round(Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC)), 2);
			}
            public override float CalculatePerimeter()
            {
                return sideA + sideB + sideC;
            }
		}

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n\nWybierz kształt do obliczenia");
                Console.WriteLine("1. Prostokąt");
                Console.WriteLine("2. Koło");
                Console.WriteLine("3. Trójkąt");
                Console.WriteLine("4. Trapez");
                Console.WriteLine("5. Kula");
                Console.WriteLine("6. Wyjście");

                //Console.Write("\nWybór: ");
                int choice = (int)(GetValidInput("\nWybór: "));
                switch (choice)
                {
                    case 1:
                        Rectangle rect = new Rectangle();
                        float rectWidth = GetValidInput("\nPodaj szerokość: ");
                        float rectHeight = GetValidInput("\nPodaj wysokość: ");
                        rect.SetDimensions(rectWidth, rectHeight);
                        Console.WriteLine("\nPowierzchnia prostokąta: {0}", rect.CalculateArea());
                        Console.WriteLine("Obwód prostokąta: {0}", rect.CalculatePerimeter());
                        break;
                    case 2:
                        float circleRadius = GetValidInput("Podaj promień koła: ");
                        Circle circle = new Circle(circleRadius);
                        Console.WriteLine("\nPowierzchnia koła: {0}", circle.CalculateArea());
                        Console.WriteLine("Obwód koła: {0}", circle.CalculatePerimeter());
                        break;
                    case 3:
                        float sideA, sideB, sideC;
                        do
                        {
                            sideA = GetValidInput("Podaj długość boku A: ");
                            sideB = GetValidInput("Podaj długość boku B: ");
                            sideC = GetValidInput("Podaj długość boku C: ");

                            if (!IsValidTriangle(sideA, sideB, sideC))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nNieprawidłowe dane. Spróbuj ponownie\n");
                                Console.ResetColor();
                            }
                        } while (!IsValidTriangle(sideA, sideB, sideC));
                        Triangle triangle = new Triangle(sideA, sideB, sideC);
                        Console.WriteLine("Powierzchnia trójkąta: {0}", triangle.CalculateArea());
                        Console.WriteLine("Obwód trójkąta: {0}", triangle.CalculatePerimeter());
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie");
                        break;
                }
            }
        }

		private static bool IsValidTriangle(float sideA, float sideB, float sideC)
		{
			return (sideA + sideB > sideC) && (sideB + sideC > sideA) && (sideA + sideC > sideB);
		}

		private static float GetValidInput(string prompt)
        {
            float result;
            while (true)
            {
                Console.Write(prompt);
                if (float.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy format danych. Spróbuj ponownie\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
