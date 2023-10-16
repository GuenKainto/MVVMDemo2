using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDemo.ViewModel;

namespace WpfAppDemo
{
    internal class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new NavigateICommand<string>(OnNav);
        }

        private BookViewModel bookViewModel = new BookViewModel();

        private MangaViewModel mangaViewModel = new MangaViewModel();

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get => _CurrentViewModel;
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public NavigateICommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "Manga":
                    CurrentViewModel = mangaViewModel;
                    break;
                case "Book":
                default:
                    CurrentViewModel = bookViewModel;
                    break;
            }
        }

    }
}
