using NewBookTracker.DAL;
using NewBookTracker.Models;
using NewBookTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewBookTracker
{
    public class ViewLauncher
    {
        public ViewLauncher()
        {
            _provider = new BookProvider("Books.xml");
            _model = new BookModel(_provider);
        }
        public void ShowMainWindow()
        {
            if (Application.Current.MainWindow != null)
            {
                return;
            }

            BookViewModel vm = new BookViewModel(_model, this);
            MainWindow mainWindow = new MainWindow() { DataContext = vm };
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        //public void ShowFindWindow()
        //{
        //    FindViewModel vm = new FindViewModel(_model);
        //    FindWindow window = new FindWindow();
        //    window.DataContext = vm;
        //    window.Show();
        //}

        private readonly BookProvider _provider;
        private readonly BookModel _model;
    }
}
