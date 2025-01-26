using static System.Reflection.Metadata.BlobBuilder;

namespace TaskD03
{
     class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true;
        }
    }

     class Library
    {
         List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Book SearchBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title)
                {
                    return books[i];
                }
            }
            return null;
        }

        public void BorrowBook(string title)
        {
            Book book = SearchBook(title);
            if (book != null && book.Availability)
            {
                book.Availability = false;
                Console.WriteLine($"Book '{title}' borrowed successfully.\n");
            }
            else if (book == null)
            {
                Console.WriteLine($"Book '{title}' not found.\n");
            }
            else
            {
                Console.WriteLine($"Book '{title}' is already borrowed.\n");
            }
        }

        public void ReturnBook(string title)
        {
            Book book = SearchBook(title);
            if (book != null && !book.Availability)
            {
                book.Availability = true;
                Console.WriteLine($"Book '{title}' returned successfully.\n");
            }
            else if (book == null)
            {
                Console.WriteLine($"Book '{title}' not found.\n");
            }
            else
            {
                Console.WriteLine($"Book '{title}' is already available.\n");
            }
        }
    }



    public class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}