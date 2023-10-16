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



        #region commands
        public MyICommand DeleteMangaCommand { get; set; }
        public MyICommand AddMangaCommand { get; set; }
        public MyICommand UpdateMangaCommand { get; set; }
        public MyICommand CountItemCommand { get; set; }
        public MyICommand ReloadCommand { get; set; }
        #endregion


        #region properties

        public string? Id_txb { get; set; }
        public string? Name_txb { get; set; }
        public int Episode_txb { get; set; }
        public string? Decription_txb { get; set; }
        public string? Age_txb { get; set; }
        #endregion


        public void Init_Command()
        {
            DeleteMangaCommand = new MyICommand(OnDelete, CanDelete);
            AddMangaCommand = new MyICommand(OnAdd, CanAdd);
            UpdateMangaCommand = new MyICommand(OnUpdate, CanUpdate);
            CountItemCommand = new MyICommand(OnCountItem, () => true);
            ReloadCommand = new MyICommand(OnReload, () => true);
        }

        public void Init_Properties()
        {
            EditableManga = new SimpleEditableManga();
            ShowUpMangaList();

        }

        public MangaViewModel()
        {
            Init_Command();
            Init_Properties();

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
                OnSelectedItemChanged();
                DeleteMangaCommand.RaiseCanExecuteChanged();
                UpdateMangaCommand.RaiseCanExecuteChanged();
            }
        }
        /// /////////////////////////////////////////////
        private SimpleEditableManga _editablemanga;
        public SimpleEditableManga EditableManga
        {
            get => _editablemanga;
            set
            {
                SetProperty(ref _editablemanga, value);
            }
        }

        /// //////////////////////////////////////////// <summary>
        /// ////////////////////////////////////////////
        /// </summary>

        private void OnDelete()
        {
            MessageBoxResult rs = MessageBox.Show("Are you sure you want to delete this ?", "Delete File", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (rs == MessageBoxResult.OK)
                ListManga.Remove(SelectedManga);
            OnReload();
        }
        private bool CanDelete()
        {
            return SelectedManga != null;
        }

        private void OnAdd()
        {
            Manga addItem = new Manga(Id_txb, Name_txb, Episode_txb, Decription_txb, Age_txb);
            ListManga.Add(addItem);
            MessageBox.Show("Add successful!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            OnReload();
        }
        private bool CanAdd()
        {
            return true;
        }


        private string _nameTextBoxTest;

        public string NameTextBoxTest
        {
            get { return _nameTextBoxTest; }
            set
            {
                if (_nameTextBoxTest != value)
                {
                    _nameTextBoxTest = value;
                    OnPropertyChanged(nameof(NameTextBoxTest));
                }
            }
        }



        private void OnUpdate()
        {
            Manga newManga = new Manga(Id_txb, Name_txb, Episode_txb, Decription_txb, Age_txb);
            int index = ListManga.IndexOf(SelectedManga);
            ListManga[index] = newManga;
            MessageBox.Show("Update successful!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            OnReload();
        }
        private bool CanUpdate()
        {
            return SelectedManga != null;
        }

        private void OnCountItem()
        {
            MessageBox.Show("Number of manga in list : " + ListManga.Count);
        }

        private void OnReload()
        {
            Id_txb = string.Empty;
            Name_txb = string.Empty;
            Episode_txb = 0;
            Decription_txb = string.Empty;
            Age_txb = string.Empty;
        }
        public void OnSelectedItemChanged()
        {
            if (SelectedManga != null)
            {
                Id_txb = SelectedManga.Id;
                NameTextBoxTest = Guid.NewGuid().ToString();
                Name_txb = SelectedManga.Name;
                Episode_txb = SelectedManga.Episode;
                Decription_txb = SelectedManga.Description;
                Age_txb = SelectedManga.Age;
                MessageBox.Show(Id_txb);
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
        }


    }
}
