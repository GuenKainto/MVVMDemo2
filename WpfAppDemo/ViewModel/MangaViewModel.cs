using System.Collections.ObjectModel;
using System.Windows;
using WpfAppDemo.Models;
using WpfAppDemo.Service;

namespace WpfAppDemo.ViewModel
{
    internal class MangaViewModel: BindableBase
    {
        # region variable
        private MangaManagerService sv;
        public ObservableCollection<Manga> ListManga { get; set; }
        private Manga _selectedManga;
        public Manga SelectedManga
        {
            get => _selectedManga;
            set
            {
                _selectedManga = value;
                OnPropertyChanged(nameof(SelectedManga));
                OnSelectedManga(SelectedManga);
                DeleteCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
        
        public MangaViewModel() 
        {
            sv = new MangaManagerService();
            ListManga = sv.GetListManga();
            AddCommand = new MyICommand(OnAdd, CanAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
            ReloadCommand = new MyICommand(OnReload, () => true);
        }

        #region Command
        public MyICommand  AddCommand { get; set; }
        private void OnAdd()
        {
            Manga item = new Manga(Id_txb, Name_txb, Episode_txb, Description_txb, Age_txb);
            if(sv.Add_Service(item))
                MessageBox.Show("Successful","Message",MessageBoxButton.OK,MessageBoxImage.Information);
            OnReload();
        }
        private bool CanAdd()
        {
            if (Id_txb == null || Name_txb == null || Description_txb == null || Age_txb == null) return false;
            else return true;
        }

        public MyICommand DeleteCommand { get; set; }
        private void OnDelete()
        {
            MessageBoxResult rs = MessageBox.Show("Are you sure you want to delete this manga","Delete manga",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if(rs == MessageBoxResult.OK) 
            {
                if(sv.Delete_Service(SelectedManga.M_ID))
                    MessageBox.Show("Successful", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                OnReload();
            }
            
        }
        private bool CanDelete()
        {
            return SelectedManga != null ;
        }
        public MyICommand UpdateCommand { get; set; }
        private void OnUpdate()
        {
            MessageBoxResult rs = MessageBox.Show("Are you sure you want to update this manga", "Update manga", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (rs == MessageBoxResult.OK)
            {
                Manga updateManga = new Manga(Id_txb, Name_txb, Episode_txb, Description_txb, Age_txb);
                if (sv.UpdateByID_Service(updateManga, SelectedManga.M_ID))
                    MessageBox.Show("Successful", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                OnReload();
            }
        }
        private bool CanUpdate()
        {
            return SelectedManga != null && CanAdd();
        }
        public MyICommand ReloadCommand {  get; set; }
        private void OnReload()
        {
            SelectedManga = null;
            ListManga.Clear();
            ListManga = sv.GetListManga();
            OnPropertyChanged(nameof(ListManga));
            Id_txb = "";
            Name_txb = "";
            Episode_txb = 0;
            Description_txb = "";
            Age_txb = "";
        }
        private void OnSelectedManga(Manga SelectedManga)
        {
            if(SelectedManga != null)
            {
                Id_txb = SelectedManga.M_ID;
                Name_txb = SelectedManga.M_Name;
                Episode_txb = SelectedManga.M_Episode;
                Description_txb = SelectedManga.M_Description;
                Age_txb = SelectedManga.M_Age;
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
        private int _episodeTxb;
        public int Episode_txb
        {
            get => _episodeTxb;
            set
            {
                _episodeTxb = value;
                OnPropertyChanged(nameof(Episode_txb));
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        private string _descriptionTxb;
        public string Description_txb
        {
            get => _descriptionTxb;
            set
            {
                _descriptionTxb = value;
                OnPropertyChanged(nameof(Description_txb));
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        private string _ageTxb;
        public string Age_txb 
        {
            get => _ageTxb;
            set
            {
                if(_ageTxb != value)
                {
                    _ageTxb = value;
                    OnPropertyChanged(nameof(Age_txb));
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }
        #endregion

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}
