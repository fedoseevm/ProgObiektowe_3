using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_1
{
    interface IAnimal
    {
        void MakeSound();
    }
    public class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Hau!");
        }
    }
    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Miau!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
         
            // Interfejs IAnimal:
            // Definiuje metodę MakeSound, którą muszą zaimplementować wszystkie klasy implementujące ten interfejs.
            // Klasy Dog, Cat, Cow, Sheep:
            // Każda z tych klas implementuje interfejs IAnimal i definiuje własną wersję metody MakeSound.
            // Klasa Program:
            // W metodzie Main tworzona jest lista animals, która zawiera obiekty różnych klas implementujących interfejs IAnimal.
            // Pętla foreach iteruje przez listę animals i wywołuje metodę MakeSound dla każdego obiektu, co powoduje wyświetlenie odpowiednich dźwięków na ekranie.

            Dog dog1 = new Dog();
            Cat cat1 = new Cat();
            dog1.MakeSound();
            cat1.MakeSound();
        }
    }
}
