using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo2.Model
{
    public class Manga
    {
        public Manga() { }

        public Manga(string id, string name, int episode , string description , string age) 
        {
            Id = id;
            Name = name;
            Episode = episode;
            Description = description;
            Age = age;
        }

        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id= value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name= value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }

        private int _episode;
        public int Episode
        {
            get => _episode;
            set
            {
                if (_episode != value)
                {
                    _episode= value;
                    RaisePropertyChanged(nameof(Episode));
                }
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
               if(_description != value)
                {
                    _description= value;
                    RaisePropertyChanged(nameof(Description));
                }
            }
        }
        private string _age;
        public string Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age= value;
                    RaisePropertyChanged(nameof(Age));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
