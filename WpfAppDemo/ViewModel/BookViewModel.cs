using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo.ViewModel
{
    internal class BookViewModel : BindableBase
    {
        #region properties

        public string Id_txb { get; set; }
        public string Name_txb { get; set; }
        public DateTime DateRelease_dtp { get; set; }
        public string Decription_txb { get; set; }
        #endregion
    }
}
