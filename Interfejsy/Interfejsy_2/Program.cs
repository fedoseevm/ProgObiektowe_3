using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_2
{
    interface IAnimal
    {
        void MakeSound();
        void Eat();
    }
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void MakeSound();
        public void Eat()
        {
            Console.WriteLine($"{Name} je");
        }
    }
    public class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age)
        {

        }
        public override void MakeSound()
        {
            Console.WriteLine("Hau!");
        }
    }
    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
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
            Dog dog1 = new Dog("Azor", 2);
            Cat cat1 = new Cat("Filemon", 3);

            dog1.MakeSound();
            dog1.Eat();

            cat1.MakeSound();
            cat1.Eat();

            Console.Clear();

            // Tworzenie listy zwierząt
            List<IAnimal> animals = new List<IAnimal>()
            {
                new Dog("Azor", 3),
                new Cat("Mruczek", 2)
            };
            animals.Add(dog1);
            animals.Add(cat1);

            foreach (IAnimal animal in animals)
            {
                animal.MakeSound();
                animal.Eat();
            }
        }
    }
}
