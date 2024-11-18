using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprawdzian_interfejsy_gr2
{
    interface IAnimal
    {
        void MakeSound();
        void Eat();
    }
    abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }
        public Animal(string name, string species, int age, string owner)
        {
            Name = name;
            Species = species;
            Age = age;
            Owner = owner;
        }

        public abstract void MakeSound();
        public void Eat()
        {
            Console.WriteLine($"{Name} je");
        }
    }
    class Dog : Animal
    {
        public Dog(string name, string species, int age, string owner) : base(name, species, age, owner)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Hau!");
        }
    }
    class Cat : Animal
    {
        public Cat(string name, string species, int age, string owner) : base(name, species, age, owner)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Miau!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            Dog dog1 = new Dog("Azor", "Pies", 2, "Jan Kowalski");
            Cat cat1 = new Cat("Filemon", "Kot", 3, "Anna Nowak");
            Dog dog2 = new Dog("Reksio", "Pies", 4, "Piotr Wiśniewski");
            Cat cat2 = new Cat("Mruczek", "Kot", 1, "Katarzyna Zielińska");

            dog1.MakeSound();
            dog1.Eat();
            dog2.MakeSound();
            dog2.Eat();
            cat1.MakeSound();
            cat1.Eat();
            cat2.MakeSound();
            cat2.Eat();
            Console.WriteLine("\n");

            List<Animal> animals = new List<Animal>()
            {
                dog1,
                dog2,
                cat1,
                cat2
            };

            foreach (var animal in animals)
            {
                animal.MakeSound();
                animal.Eat();
            }

            // Part 2
            Console.WriteLine("\nSortowanie według Właściciela:");
            var sortedByOwner = animals.OrderBy(b => b.Owner);
            foreach (var animal in sortedByOwner)
            {
                Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
            }

            Console.WriteLine("\nSortowanie według Gatunku:");
            var sortedBySpecies = animals.OrderBy(b => b.Species);
            foreach (var animal in sortedBySpecies)
            {
                Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
            }

            Console.WriteLine("\nSortowanie według Wieku:");
            var sortedByAge = animals.OrderBy(b => b.Age);
            foreach (var animal in sortedByAge)
            {
                Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
            }

            Console.WriteLine("\nSortowanie według Imienia:");
            var sortedByName = animals.OrderBy(b => b.Name);
            foreach (var animal in sortedByName)
            {
                Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
            }
            

            // Part 3
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Sortowanie według właściciela");
            Console.WriteLine("2. Sortowanie według gatunku");
            Console.WriteLine("3. Sortowanie według wieku");
            Console.WriteLine("4. Sortowanie według imienia");
            Console.WriteLine("5. Wyjście");

            while (true)
            {
                int choice = GetValidInt("\nWybór: ");

                List<Animal> outputList;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1. Sortowanie według właściciela");
                        var sortedListByOwner = animals.OrderBy(b => b.Owner);
                        foreach (var animal in sortedListByOwner)
                        {
                            Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("2. Sortowanie według gatunku");
                        var sortedListBySpecies = animals.OrderBy(b => b.Species);
                        foreach (var animal in sortedListBySpecies)
                        {
                            Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("3. Sortowanie według wieku");
                        var sortedListByAge = animals.OrderBy(b => b.Age);
                        foreach (var animal in sortedListByAge)
                        {
                            Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("4. Sortowanie według imienia");
                        var sortedListByName = animals.OrderBy(b => b.Name);
                        foreach (var animal in sortedListByName)
                        {
                            Console.WriteLine($"{animal.Name}, {animal.Species}, {animal.Age}, {animal.Owner}");
                        }
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja menu. Spróbuj ponownie\n");
                        break;
                }
            }
        }

        private static int GetValidInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowe dane. Spróbuj ponownie\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
