using NewBookTracker.DAL.Entities;
using NewBookTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewBookTracker.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly BookModel _model;
        private readonly ViewLauncher _viewLauncher;
        public ObservableCollection<Book> Books { get; set; }
        private Book _currentBook;

        public BookViewModel(BookModel bookModel, ViewLauncher viewLauncher)
        {
            _model = bookModel;
            _viewLauncher = viewLauncher;
            _model.BookListChanged += (o, e) => ReloadBooks();
            ReloadBooks();
        }


        public Book CurrentBook
        {
            get { return _currentBook; }
            set
            {
                _currentBook = value;
                RaisePropertyChanged();
                // DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        private void ReloadBooks()
        {
            Books = new ObservableCollection<Book>(_model.Books);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
