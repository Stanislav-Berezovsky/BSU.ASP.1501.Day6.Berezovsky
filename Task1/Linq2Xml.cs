using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task1
{
    public class Linq2Xml : IRepository<Book>
    {
        string path;

        public Linq2Xml(string filePath)
        {
            this.path = filePath;
        }



        public void Save(IEnumerable<Book> items)
        {
            var xml = new XElement("Books",
                items.Select((book) => new XElement("Book",
                    new XAttribute("Genre", book.Genre),
                    new XElement("Author", book.Author),
                    new XElement("Title", book.Title),
                    new XElement("Publication", book.Publication))));
            xml.Save(path);
        }

        List<Book> IRepository<Book>.Load()
        {
            var books = new List<Book>();
            if (!File.Exists(path))
                return books;
            var document = XDocument.Load(path);
            foreach (var book in document.Root.Elements("Book"))
            {
                books.Add(new Book(book.Element("Author").Value, book.Element("Title").Value, book.Attribute("Genre").Value, Int32.Parse(book.Element("Publication").Value)));
            }
            return books;
        }
    }
}
