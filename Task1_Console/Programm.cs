using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = "Books.txt";
            var path1 = "Book.XML";
            //IRepository<Book> rep = new BookRepository(path);
            IRepository<Book> rep1 = new WorkWithXml(path1);
            var bookService = new BookListService(rep1);
            Book book = new Book("werwer", "petrov", "Metoda", 1);
            bookService.Add(book);
            //bookService.Delete(book);
            var books = bookService.Sort(x => x.Publication);
            foreach (var b in books)
            {
                Console.Write("{0}\t", b.Author);
                Console.Write("{0}\t", b.Title);
                Console.Write("{0}\t", b.Genre);
                Console.Write("{0}\t", b.Publication);
                Console.WriteLine();
            }
            /*
            Console.WriteLine();
            var _books = bookService.SearchBooks(x => x.Author == "qqq");
            foreach (var b in _books)
            {
                Console.Write("{0}\t", b.Author);
                Console.Write("{0}\t", b.Title);
                Console.Write("{0}\t", b.Genre);
                Console.Write("{0}\t", b.Publication);
                Console.WriteLine();
            }

            Console.WriteLine();
            var find = bookService.Search(x => x.Author == "qqq");
            Console.Write("{0}\t{1}\t{2}\t{3}", find.Author, find.Title, find.Genre, find.Publication);
            Console.ReadKey();
            foreach (var b in books)
            {
                Console.Write("{0}\t", b.Author);
                Console.Write("{0}\t", b.Title);
                Console.Write("{0}\t", b.Genre);
                Console.Write("{0}\t", b.Publication);
                Console.WriteLine();
            }*/

            Console.ReadKey();
        }
    }
}
