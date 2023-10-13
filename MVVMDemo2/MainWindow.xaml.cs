using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMDemo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BookViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            MVVMDemo2.ViewModel.BookViewModel bookViewModelObject = new MVVMDemo2.ViewModel.BookViewModel();
            bookViewModelObject.AddTempBookIntoList();

            BookViewControl.DataContext = bookViewModelObject;
        }
    }
}
