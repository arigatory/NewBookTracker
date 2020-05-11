using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewBookTracker.DAL.Entities
{
    public class Book : INotifyPropertyChanged
    {
        private string title;
        private DateTime started;
        private int numberOfPages;
        private List<DateTime> dateTimesAcsess;
        private int currentPage;
        private bool isFinished;

        public string Title { get => title; set {
                title = value;
                RaisePropertyChanged();
            }
        }
        public DateTime Started
        {
            get => started; set
            {
                started = value;
                RaisePropertyChanged();
            }
        }
        public int NumberOfPages
        {
            get => numberOfPages; set
            {
                numberOfPages = value;
                RaisePropertyChanged();
            }
        }
        public List<DateTime> DateTimesAcsess { get => dateTimesAcsess; set => dateTimesAcsess = value; }
        public int CurrentPage
        {
            get => currentPage; set
            {
                currentPage = value;
                RaisePropertyChanged();
            }
        }
        public bool IsFinished
        {
            get => isFinished; set
            {
                isFinished = value;
                RaisePropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
