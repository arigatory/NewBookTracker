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

        public BookTrack[] GetBooks()
        {
            if (!File.Exists(_fileName))
            {
                return new BookTrack[]
                {
                    new BookTrack("Основы алгебры. Часть 1. Кострикин",271),
                    new BookTrack("WPF в .NET 4.5 c примерами на С#",1018,288)

                };
            }

            using (StreamReader sr = new StreamReader(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BookTrack[]));
                return (BookTrack[])serializer.Deserialize(sr);
            }
        }

        public void SaveBooks(BookTrack[] books)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BookTrack[]));
                serializer.Serialize(sw, books);
            }
        }

    }
}
