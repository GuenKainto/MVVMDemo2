using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo.Models
{
    internal class Manga
    {
        public Manga() { }
        public Manga(string id, string name, int episode, string description, string age)
        {
            M_ID = id;
            M_Name = name;
            M_Episode = episode;
            M_Description = description;
            M_Age = age;
        }

        private string _mid;
        public string M_ID
        {
            get => _mid;
            set
            {
                if (_mid != value)
                    _mid = value;
                RaisePropertyChanged(nameof(M_ID));
            }
        }

        private string _mName;
        public string M_Name
        {
            get => _mName;
            set
            {
                if (_mName != value)
                    _mName = value;
                RaisePropertyChanged(nameof(M_Name));
            }
        }

        private int _mEpisode;
        public int M_Episode
        {
            get => _mEpisode;
            set
            {
                if (_mEpisode != value)
                    _mEpisode = value;
                RaisePropertyChanged(nameof(M_Episode));
            }
        }

        private string _mDescription;
        public string M_Description
        {
            get => M_Description;
            set
            {
                if (_mDescription != value)
                    _mDescription = value;
                RaisePropertyChanged(nameof(M_Description));
            }
        }

        private string _mAge;
        public string M_Age
        {
            get => _mAge;
            set 
            {
                if (_mAge != value)
                    _mAge = value;
                RaisePropertyChanged(nameof(M_Age)); 
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
