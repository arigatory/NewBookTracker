using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewBookTracker.DAL.Entities
{
    public class BookTrack : INotifyPropertyChanged
    {
        private string title;
        private int numberOfPages;
        private Dictionary<DateTime, int> datePage;
        private bool isFinished;
        private Dictionary<DateTime, int> datePage1;

        public string Title
        {
            get => title; set
            {
                title = value;
                RaisePropertyChanged();
            }
        }
        public DateTime Started
        {
            get
            {
                return datePage.Keys.Min();
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
        public int CurrentPage
        {
            get
            {
                if (datePage == null)
                {
                    return 0;
                }
                return datePage[datePage.Keys.Max()];
            }
            set
            {
                datePage.Add(DateTime.Now, value);
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
        public Dictionary<DateTime, int> DatePage
        {
            get => datePage; set
            {
                datePage1 = value;
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
