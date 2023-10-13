using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;

namespace MVVMDemo2.Model
{
    public class BookModel { }
    public class Book : INotifyPropertyChanged
    {

        public Book() { }
        public Book(string id, string name, string dateRelease, string publisher)
        {
            Id = id;
            Name = name;
            DateRelease = dateRelease;
            Publisher = publisher;
        }

        private string _id { get; set; }

        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        private string _name { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }

        private string _dataRelease { get; set; }
        public string DateRelease
        {
            get => _dataRelease;
            set
            {
                if (_dataRelease != value)
                {
                    _dataRelease = value;
                    RaisePropertyChanged(nameof(DateRelease));
                }
            }
        }

        private string _publisher { get; set; }
        public string Publisher
        {
            get => _publisher;
            set
            {
                if (_publisher != value)
                {
                    _publisher = value;
                    RaisePropertyChanged(nameof(Publisher));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
