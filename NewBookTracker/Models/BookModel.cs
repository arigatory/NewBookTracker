using NewBookTracker.DAL;
using NewBookTracker.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBookTracker.Models
{
    public class BookModel
    {
        private readonly BookProvider _bookProvider;
        private BookTrack[] Books;
        public event EventHandler BookListChanged;


        public BookModel(BookProvider bookProvider)
        {
            _bookProvider = bookProvider;
            Load();
        }

        private void Load()
        {
            Books = _bookProvider.GetBooks();
        }

        public void Save(BookTrack[] books)
        {
            _bookProvider.SaveBooks(books);
            Books = books;
            BookListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
