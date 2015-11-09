using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListService
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private IRepository<Book> Repository { get; set; }
        private List<Book> books = new List<Book>();

        public BookListService(IRepository<Book> repository)
        {
            this.Repository = repository;
            books = Repository.Load();
        }

        public void Add(Book book)
        {
            logger.Trace("Add started");
            if (book == null)
                throw new ArgumentNullException();
            var IsExist = books.Contains(book);
            if (IsExist)
            {
                var ex = new ArgumentException("This book already exists");
                logger.Error(ex,"Exception in Add");
                throw ex;
            }
            books.Add(book);
            Repository.Save(books);
            logger.Trace("Add finished");
        }

        public void Delete(Book book)
        {
            logger.Trace("Delete started");
            if (book == null)
                throw new ArgumentNullException();
            var IsDelete = books.Remove(book);
            if (!IsDelete)
            {
                var ex = new ArgumentException("This book doesn't exist");
                logger.Error(ex, "Exception in Delete");
                throw ex;
            }
            Repository.Save(books);
            logger.Trace("Delete finished");
        }


        public IEnumerable<Book> SearchBooks(Predicate<Book> match)
        {
            logger.Trace("SearchBooks started");
            return books.FindAll(match);
        }

        public Book Search(Func<Book, bool> func)
        {
            logger.Trace("Search Started");
            return books.FirstOrDefault(func);
        }
        public IEnumerable<Book> Sort(Func<Book, object> func)
        {
            logger.Trace("Sort Started");
            return books.OrderBy(func);
        }
    }
}
