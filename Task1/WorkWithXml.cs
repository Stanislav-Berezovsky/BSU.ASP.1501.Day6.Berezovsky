using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task1
{
    public class WorkWithXml:IRepository<Book>
    {

        string path;

        public WorkWithXml(string filePath)
        {
            this.path = filePath;
        }
        public List<Book> Load()
        {
            var book = new List<Book>();
            string genre = "";
            string author = "";
            string title = "";
            int publication = 0;
            if (!File.Exists(path))
                return book;
            using (var reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (reader.Name)
                            {
                                case "Book":
                                    genre = reader.GetAttribute("Genre");
                                    break;
                                case "Author":
                                    author = reader.ReadElementContentAsString();
                                    break;
                                case "Title":
                                    title = reader.ReadElementContentAsString();
                                    break;
                                case "Publication":
                                    publication = reader.ReadElementContentAsInt();
                                    break;
                            }
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name == "Book")
                                book.Add(new Book(author, title, genre, publication));
                            break;
                    }
                }
            }
            return book;
        }

        public void Save(IEnumerable<Book> entity)
        {
            var settings = new XmlWriterSettings { Indent = true };
            using (var fs = new FileStream(path, FileMode.Create))
            {               
                using (var writer = XmlWriter.Create(fs, settings))
                {
                    // начинаем с XML-декларации
                    writer.WriteStartDocument();
                    // открывающий тег с двумя атрибутами
                    writer.WriteStartElement("Books");
                    foreach (var book in entity)
                    {
                        writer.WriteStartElement("Book");
                        writer.WriteAttributeString("Genre", book.Genre);
                        // вложенный элемент со строковым содержимым
                        writer.WriteElementString("Author", book.Author);
                        writer.WriteElementString("Title", book.Title);
                        // так пишутся элементы с не строковым содержимым
                        // для этого используется метод WriteValue()
                        writer.WriteStartElement("Publication");
                        writer.WriteValue(book.Publication);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        // закрывающие теги (принцип стека)
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
    }
}