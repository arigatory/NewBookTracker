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
                    new Book()
                    {
                        Title="Test Book", CurrentPage=10,
                        DateTimesAcsess = new List<DateTime>(),
                        IsFinished=false,
                        NumberOfPages=100,
                        Started = DateTime.Today
                    },
                    new Book()
                    {
                        Title="Another Book", CurrentPage=20,
                        DateTimesAcsess = new List<DateTime>(),
                        IsFinished=false,
                        NumberOfPages=500,
                        Started = DateTime.Now
                    }
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
