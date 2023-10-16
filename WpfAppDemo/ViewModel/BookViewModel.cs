using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDemo.Models;
using WpfAppDemo.Service;

namespace WpfAppDemo.ViewModel
{
    internal class BookViewModel : BindableBase
    {
        # region variable
        private BookManagerService sv;
        public ObservableCollection<Book> ListBook { get; set; }
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
                OnSelectedBook(SelectedBook);
                DeleteCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        public BookViewModel()
        {
            DateRelease_dtp = DateTime.Now.Date;
            sv = new BookManagerService();
            ListBook = sv.GetListBook();
            AddCommand = new MyICommand(OnAdd, CanAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
            ReloadCommand = new MyICommand(OnReload, () => true);
        }

        #region Command
        public MyICommand AddCommand { get; set; }
        private void OnAdd()
        {
            Book item = new Book(Id_txb, Name_txb, DateRelease_dtp, Publisher_txb);
            if (sv.Add_Service(item))
                MessageBox.Show("Successful", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            OnReload();
        }
        private bool CanAdd()
        {
            if (Id_txb == null || Name_txb == null || DateRelease_dtp == null || Publisher_txb == null) return false;
            else return true;
        }

        public MyICommand DeleteCommand { get; set; }
        private void OnDelete()
        {
            MessageBoxResult rs = MessageBox.Show("Are you sure you want to delete this book", "Delete manga", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (rs == MessageBoxResult.OK)
            {
                if (sv.Delete_Service(SelectedBook.B_ID))
                    MessageBox.Show("Successful", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                OnReload();
            }

        }
        private bool CanDelete()
        {
            return SelectedBook != null;
        }
        public MyICommand UpdateCommand { get; set; }
        private void OnUpdate()
        {
            MessageBoxResult rs = MessageBox.Show("Are you sure you want to update this book", "Update book", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (rs == MessageBoxResult.OK)
            {
                Book updateBook = new Book(Id_txb, Name_txb, DateRelease_dtp, Publisher_txb);
                if (sv.UpdateByID_Service(updateBook, SelectedBook.B_ID))
                    MessageBox.Show("Successful", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                OnReload();
            }
        }
        private bool CanUpdate()
        {
            return SelectedBook != null && CanAdd();
        }
        public MyICommand ReloadCommand { get; set; }
        private void OnReload()
        {
            SelectedBook = null;
            ListBook.Clear();
            ListBook = sv.GetListBook();
            OnPropertyChanged(nameof(ListBook));
            Id_txb = "";
            Name_txb = "";
            DateRelease_dtp = DateTime.Now.Date;
            Publisher_txb = "";
        }
        private void OnSelectedBook(Book SelectedBook)
        {
            if (SelectedBook != null)
            {
                Id_txb = SelectedBook.B_ID;
                Name_txb = SelectedBook.B_Name;
                DateRelease_dtp = SelectedBook.B_DateRelease;
                Publisher_txb = SelectedBook.B_Publisher;
            }

        }
        #endregion

        #region properties
        private string _idTxb;
        public string Id_txb
        {
            get => _idTxb;
            set
            {
                _idTxb = value;
                OnPropertyChanged(nameof(Id_txb));
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        private string _nameTxb;
        public string Name_txb
        {
            get => _nameTxb;
            set
            {
                _nameTxb = value;
                OnPropertyChanged(nameof(Name_txb));
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        private DateTime _dateReleaseDtp;
        public DateTime DateRelease_dtp
        {
            get => _dateReleaseDtp;
            set
            {
                _dateReleaseDtp = value;
                OnPropertyChanged(nameof(DateRelease_dtp));
            }
        }
        private string _publisherTxb;
        public string Publisher_txb
        {
            get => _publisherTxb;
            set
            {
                _publisherTxb = value;
                OnPropertyChanged(nameof(Publisher_txb));
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}
