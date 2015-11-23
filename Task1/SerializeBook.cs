using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SerializeBook : IRepository<Book>
    {
        string path;


        public SerializeBook(string filePath)
        {
            this.path = filePath;
        }


        public void Save(IEnumerable<Book> items)
        {
            FileMode fileMode = File.Exists(path) ? FileMode.Open : FileMode.Create;
            var formatter = new BinaryFormatter();
            using (var s = new FileStream(path, fileMode))
            {
                formatter.Serialize(s, items);
            }

        }

        List<Book> IRepository<Book>.Load()
        {
            var books = new List<Book>();
            var formatter = new BinaryFormatter();
            using (var s = new FileStream(path, FileMode.Open))
            {
                books = (List<Book>)formatter.Deserialize(s);
            }
            return books;
        }
    }
}
