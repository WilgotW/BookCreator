using System.ComponentModel.Design;
using static System.Reflection.Metadata.BlobBuilder;

namespace BiblioteksApp
{
    internal class Program
    {
        public static List<Book> books = new List<Book>();

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Library!");


            Menu();

            
        }
        private static void Menu()
        {
            Console.Clear();
            int answer;
            Console.WriteLine("What do you want to do? \n");
            Console.WriteLine("Type: \n 1. Read books \n 2. Create new book");
            while(true)
            {
                try
                {
                    answer = int.Parse(Console.ReadLine());

                    if (answer == 1)
                    {
                        SeeBooks();
                    }
                    else if (answer == 2)
                    {
                        books.Add(CreateBook());
                        Menu();
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            
        }
        private static void SeeBooks()
        {
            Console.WriteLine($"There are: {books.Count} books \n");
            foreach(Book book in books)
            {
                string temp = $"Title: {book.Title} Author: {book.Author} Pages: {book.Pages}";
                Print();
                Console.WriteLine(temp);
                Print();

                void Print()
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadLine();
            Menu();
            
        }
        private static Book CreateBook()
        {
            Console.WriteLine("Write title:");
            string title = Console.ReadLine();
            Console.WriteLine("Write author:");
            string author = Console.ReadLine();
            Console.WriteLine("Write pages:");

            int pages = int.Parse(Console.ReadLine());
            
            Book book = new Book(title, author, pages);
            Console.WriteLine("Created Book: " + title + " By: " + author + " and is " + pages + " long");
            System.Threading.Thread.Sleep(2000);

            return book;
        }
    }
}