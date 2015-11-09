using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookRepository : IRepository<Book>
    {
        string path;
        public BookRepository(string filePath)
        {
            this.path = filePath;
        }




        /*public IEnumerable<Book> Load()
        {
            var books = new List<Book>();
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            while (reader.PeekChar() > -1)
            {
                books.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
            }
            reader.Close();
            return books;
        }*/

        public void Save(IEnumerable<Book> books)
        {
            using (var writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Genre);
                    writer.Write(book.Publication);
                }
            }
        }

        List<Book> IRepository<Book>.Load()
        {
            var books = new List<Book>();
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            while (reader.PeekChar() > -1)
            {
                books.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
            }
            reader.Close();
            return books;
        }
    }
}
