using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo.Models
{
    internal class Book
    {
        public Book() { }
        public Book(string id, string name, string dateRelease, string publisher)
        {
            B_ID = id;
            B_Name = name;
            B_DateRelease = dateRelease;
            B_Publisher = publisher;
        }

        private string _bid;
        public string B_ID
        {
            get => _bid; 
            set 
            {
                if(_bid != value)
                _bid = value; 
                RaisePropertyChanged(nameof(B_ID));
            }
        }

        private string _bName;
        public string B_Name
        {
            get => _bName; 
            set 
            {
                if (_bName != value)
                _bName = value;
                RaisePropertyChanged(nameof(B_Name));
            }
        }
        private string _bDateRelease;
        public string B_DateRelease
        {
            get => _bDateRelease;
            set 
            {
                if (_bDateRelease != value)
                    _bDateRelease = value;
                RaisePropertyChanged(nameof(B_DateRelease));
            }
        }
        private string _bPublisher;
        public string B_Publisher
        {
            get => _bPublisher;
            set
            {
                if(_bPublisher != value)
                    _bPublisher = value;
                RaisePropertyChanged(nameof(B_Publisher));
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
