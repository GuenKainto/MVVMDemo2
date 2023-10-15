using MVVMDemo2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDemo2.ViewModel
{
    internal class BookViewModel : BindableBase
    {
        public MyICommand DeleteCommand { get; set; }
        public BookViewModel()
        {
            AddTempBookIntoList();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }
        public ObservableCollection<Book> ListBook { get; set; }
        public void AddTempBookIntoList()
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();
            books.Add(new Book("B01", "C# for beginner", "10/11/2012", "WibuCoder"));
            books.Add(new Book("B02", "C++ for beginner", "09/11/2014", "WibuCoder"));
            books.Add(new Book("B03", "Welcome to Hello World", "11/01/2010", "WibuCoder"));
            books.Add(new Book("B04", "Life", "17/02/2012", "WibuCoder"));

            ListBook = books;
        }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get
            {
                return _selectedBook;
            }

            set
            {
                _selectedBook = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete()
        {
            ListBook.Remove(SelectedBook);
        }

        private bool CanDelete()
        {
            return SelectedBook != null;
        }
    }
}
