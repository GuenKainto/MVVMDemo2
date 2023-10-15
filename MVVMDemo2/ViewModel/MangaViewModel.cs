using MVVMDemo2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMDemo2.ViewModel
{
    internal class MangaViewModel : BindableBase
    {
        public MyICommand DeleteMangaCommand { get; set; }
        public MyICommand AddMangaCommand { get; set; }
        public MyICommand UpdateMangaCommand { get; set; }
        public MyICommand CountItemCommand { get; set; }
        public MangaViewModel()
        {
            ShowUpMangaList();
            DeleteMangaCommand = new MyICommand(OnDelete, CanDelete);
            AddMangaCommand = new MyICommand(OnAdd, CanAdd);
            CountItemCommand = new MyICommand(OnCountItem,CanCountItem);
            EditableManga = new SimpleEditableManga();

        }
        public ObservableCollection<Manga> ListManga { get; set; }
        public void ShowUpMangaList()
        {
            ObservableCollection<Manga> mangas = new ObservableCollection<Manga>();
            mangas.Add(new Manga("M01", "Kimi no Nawa", 1, "The story about the love and ...", "16+"));
            mangas.Add(new Manga("M02", "Magical Girl Lyrical Nanoha", 1, "The story of a little girl who ...", "12+"));
            mangas.Add(new Manga("M03", "Eighty Six", 1, "War, pain and despair", "18+"));
            mangas.Add(new Manga("M04", "Eighty Six", 2, "War, pain and despair", "18+"));
            mangas.Add(new Manga("M05", "Eighty Six", 3, "War, pain and despair", "18+"));

            ListManga = mangas;
        }
        private Manga _selectedManga;
        public Manga SelectedManga
        {
            get => _selectedManga;
            set
            {
                _selectedManga = value;
                DeleteMangaCommand.RaiseCanExecuteChanged();
                //UpdateMangaCommand.RaiseCanExecuteChanged();
            }
        }

        private SimpleEditableManga _editablemanga;
        public SimpleEditableManga EditableManga
        {
            get => _editablemanga;
            set
            {
                SetProperty(ref _editablemanga, value);
            }
        }



        private string _id_txb;
        public string Id_txb
        {
            get => _id_txb;
            set
            {
                _id_txb = value;
                OnPropertyChanged(nameof(Id_txb));
            }
        }
        private string _name_txb;
        public string Name_txb
        {
            get => _name_txb;
            set
            {
                _name_txb = value;
                OnPropertyChanged(nameof(Name_txb));
            }
        }
        private int _episode_txb;
        public int Episode_txb
        {
            get => _episode_txb;
            set
            {
                _episode_txb = value;
                OnPropertyChanged(nameof(Episode_txb));
            }
        }
        private string _decription_txb;
        public string Decription_txb
        {
            get => _decription_txb;
            set
            {
                _decription_txb = value;
                OnPropertyChanged(nameof(Decription_txb));
            }
        }
        private string _age_txb;
        public string Age_txb
        {
            get => _age_txb;
            set
            {
                _age_txb = value;
                OnPropertyChanged(nameof(Age_txb));
            }
        }
        private void OnDelete()
        {
            ListManga.Remove(SelectedManga);
        }
        private bool CanDelete()
        {
            return SelectedManga != null;
        }

        private void OnAdd()
        {
            Manga addItem = new Manga(Id_txb, Name_txb, Episode_txb, Decription_txb, Age_txb);
            ListManga.Add(addItem);

            Id_txb = string.Empty;
            Name_txb = string.Empty;
            Episode_txb = 0;
            Decription_txb = string.Empty;
            Age_txb = string.Empty;

            EditableManga = new SimpleEditableManga();
        }
        private bool CanAdd()
        {
            return true;
        }


        private void OnUpdate()
        {

        }
        private bool CanUpdate()
        {
            return true;
        }

        private void OnCountItem()
        {
            MessageBox.Show("Number of manga in list : " + ListManga.Count);
        }
        public bool CanCountItem()
        {
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
