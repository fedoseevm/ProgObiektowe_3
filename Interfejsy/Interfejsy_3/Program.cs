using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_3
{
    internal interface IDiscountable
    {
        double ApplyDiscount(double percentage);
    }
    internal interface IReadable
    {
        void Read();
    }

    class Book : IComparable<Book>, IEquatable<Book>, IFormattable, IDiscountable, IReadable
    {
        public string title;
        public string author;
        public int yearOfPublication;
        public double price;

        public Book(string title, string author, int yearOfPublication, double price)
        {
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
        }

        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return price.CompareTo(other.price);
        }

        public bool Equals(Book other)
        {
            if (this == other) return true;
            return false;
        }

        // Nadpisanie domyślnej metody ToString() 
        //public override string ToString()
        //{
        //    return $"{title}, {author}, {yearOfPublication}, {price}";
        //}

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{title}, {author}, {yearOfPublication}, {price}";
        }

        public double ApplyDiscount(double percentage)
        {
            price -= price / 100 * percentage;
            return price;
        }

        public void Read()
        {
            Console.WriteLine($"Czytanie książki {title} {author} {yearOfPublication}");
        }

        public virtual void Download()
        {
            Console.WriteLine("Nie da się pobrać fizycznej książki");
        }
    }

    class EBook : Book
    {
        public string format;
        public EBook(string title, string author, int yearOfPublication, double price, string format) : base(title, author, yearOfPublication, price)
        {
            this.format = format;
        }

        public override void Download()
        {
            Console.WriteLine($"Pobieranie książki {title} {author} {yearOfPublication}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            books.Add(new Book("Hobbit", "Nowak", 1937, 45.99));
            books.Add(new Book("Hobbit2", "Pawlak", 2000, 155.99));
            books.Add(new EBook("Hobbit3", "Arbuz", 2000, 5.99, "PDF"));
            books.Add(new EBook("Hobbit4", "Arbuz", 1948, 5.99, "UPUB"));

            Console.WriteLine("Lista książek:");
            foreach (Book book in books)
            {
                Console.WriteLine(book);    // Console.WriteLine(book.ToString()) ten zapis oznacza to samo, ponieważ ToString() uruchamia się domyślnie
            }

            Console.WriteLine("\nLista posortowana domyślnie (według ceny)");
            books.Sort();

            foreach (Book book in books)
            {
                Console.WriteLine(book); 
            }

            Console.WriteLine("\n\nSortowanie według daty publikacji");
            var sortedByYear = books.OrderBy(b => b.yearOfPublication);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\n\nSortowanie według autora");
            var sortedByAuthor = books.OrderBy(b => b.author);
            foreach (Book book in sortedByAuthor)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\n\nSortowanie według ceny nierosnąco a następnie według roku publickacji od najstarzej książki");
            var sortedByPriceAndYear = books.OrderByDescending(b => b.price).ThenBy(b => b.yearOfPublication); // ThenBy() przeprowadza dodatkowe sortowanie według drugiego warunku (yearOfPublication) 
            foreach (Book book in sortedByPriceAndYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("\n");

            books[0].ApplyDiscount(25);
            Console.WriteLine(books[0]);
            books[0].Read();
            books[2].Download();
        }
    }
}
