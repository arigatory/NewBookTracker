using NewBookTracker.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NewBookTracker.DAL
{
    public class BookProvider
    {
        private readonly string _fileName;
        public BookProvider(string fileName)
        {
            _fileName = fileName;
        }

        public Book[] GetBooks()
        {
            if (!File.Exists(_fileName))
            {
                return new Book[]
                {
                    new Book("Основы алгебры. Часть 1. Кострикин",271),
                    new Book("WPF в .NET 4.5 c примерами на С#",1018,288)
                };
            }

            using (StreamReader sr = new StreamReader(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                return (Book[])serializer.Deserialize(sr);
            }
        }

        public void SaveBooks(Book[] books)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                serializer.Serialize(sw, books);
            }
        }

    }
}
