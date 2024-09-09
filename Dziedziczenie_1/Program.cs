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

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Rectangle rect = new Rectangle();
                        Console.Write("\nPodaj szerokość: ");
                        float rectWidth = float.Parse(Console.ReadLine());
                        Console.Write("\nPodaj wysokość: ");
                        float rectHeight = float.Parse(Console.ReadLine());
                        rect.SetDimensions(rectWidth, rectHeight);
                        Console.WriteLine("\nPowierzchnia prostokąta: {0}", rect.CalculateArea());
                        Console.WriteLine("Obwód prostokąta: {0}", rect.CalculatePerimeter());
                        break;
                    case 2:
                        float circleRadius = GetValidInput("Podaj pronień koła: ");
                        Circle circle = new Circle(circleRadius);
                        Console.WriteLine("\nPowierzchnia koła: {0}", circle.CalculateArea());
                        Console.WriteLine("Obwód koła: {0}", circle.CalculatePerimeter());
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie");
                        break;
                }
            }
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
