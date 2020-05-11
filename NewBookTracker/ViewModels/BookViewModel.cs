using NewBookTracker.Models;
using System;
using System.Collections.Generic;
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

        public BookViewModel(BookModel bookModel, ViewLauncher viewLauncher)
        {
            _model = bookModel;
            _viewLauncher = viewLauncher;
            _model.BookListChanged += (o,e) => ReloadBooks();
            ReloadBooks();
        }

        private void ReloadBooks()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
