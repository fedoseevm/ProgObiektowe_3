﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public Person(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;
	}
}

public class Author : Person
{
	public List<Book> BooksList { get; set; }
	public Author(string firstName, string lastName) : base(firstName, lastName)
	{
		BooksList = new List<Book>();
	}
	public void AddBook(Book book)
	{
		BooksList.Add(book);
	}
}

public class Book
{
	public string Title { get; set; }
	public Author Author { get; set; }
	public int PublicationYear { get; set; }
	public Book(string title, Author author, int publicationYear)
	{
		Title = title;
		Author = author;
		PublicationYear = publicationYear;
	}
}
public class Reader : Person
{
	public List<Book> BorrowedBooksList { get; set; }
	public Reader(string firstName, string lastName) : base(firstName, lastName)
	{
		BorrowedBooksList = new List<Book>();
	}
	public void BorrowBook(Book book)
	{
		BorrowedBooksList.Add(book);
        Console.WriteLine($"Czytelnik {FirstName} {LastName} wyporzyczył książkę: {book.Title}");
    }
}

public class Library
{
	public List<Book> BooksList { get; set; }
	public List<Author> AuthorsList { get; set; }
	public List<Reader> ReadersList { get; set; }
	public Library()
	{
		BooksList = new List<Book>();
		ReadersList = new List<Reader>();
		AuthorsList = new List<Author>();
	}

	public void AddBook(Book book)
	{
		BooksList.Add(book);
	}
	public void AddReader(Reader reader)
	{
		ReadersList.Add(reader);
	}
	public void AddAuthor(Author author)
	{
		AuthorsList.Add(author);
	}
	public void BorrowBook(Reader reader, Book book)
	{
		if (BooksList.Contains(book))
		{
			reader.BorrowBook(book);
			BooksList.Remove(book);
		}
		else
		{
			Console.WriteLine("Książka nie jest dostępna w bibliotece.");
		}
	}
	public void DisplayBooks()
	{
		Console.WriteLine("Książki dostępne w bibliotece:");
		foreach (var book in BooksList)
		{
			Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
		}
	}
	public void DisplayAuthors()
	{
		Console.WriteLine("Autorzy w bibliotece:");
		foreach (var author in AuthorsList)
		{
			Console.WriteLine($"{author.FirstName} {author.LastName}");
		}
	}
	public void DisplayBorrowedBooks(Reader reader)
	{
		Console.WriteLine("Książki wypożyczone w bibliotece:");
		foreach (var book in reader.BorrowedBooksList)
		{
			Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublicationYear}) wypożyczona przez {reader.FirstName} {reader.LastName}");
		}
	}
		
	// Dodać metodę wyświetlająca wszystkich autorów w formie tabeli
}

namespace System_Zarzadzania_Biblioteka
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Author author1 = new Author("Adam", "Mickiewicz");
			Author author2 = new Author("Henryk", "Sienkiewicz");
			
			Book book1 = new Book("Pan Tadeusz", author1, 1834);
			Book book2 = new Book("Quo Vadis", author2, 1896);

			author1.AddBook(book1);
			author1.AddBook(book2);

			Library library = new Library();
			library.AddAuthor(author1);
			library.AddAuthor(author2);
			library.AddBook(book1);
			library.AddBook(book2);

			Reader reader1 = new Reader("Jan", "Kowalski");
			Reader reader2 = new Reader("Anna", "Nowak");
			
			library.AddReader(reader1);
			library.AddReader(reader2);


            bool exit = false;
			while (!exit)
			{
				// Wyświetlenie menu
				Console.WriteLine("Menu");
				Console.WriteLine("1. Dodaj czytelnika");
				Console.WriteLine("2. Exit");

				int choice = GetValidInt("Wybór: ");
				switch (choice)
				{
					case 1:
						string firstName = GetValidString("Podaj imie czytelnika: ");
						string lastName = GetValidString("Podaj nazwisko czytelnika: ");
						Reader czytelnik1 = new Reader(firstName, lastName);
						Console.WriteLine("Dodano czytelnika {0} {1}", firstName, lastName);
						break;
					case 2:
						return;
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Nieprawidłowa opcja menu. Spróbuj ponownie\n");
						Console.ResetColor();
						break;
				}
			}
        }
        private static string GetValidString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy format danych. Spróbuj ponownie\n");
                    Console.ResetColor();
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
                    Console.WriteLine("Nieprawidłowy format danych. Spróbuj ponownie\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
