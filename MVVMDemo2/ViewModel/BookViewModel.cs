using MVVMDemo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo2.ViewModel
{
    public class BookViewModel
    {
        public List<Book> ListBook
        {
            get; set;
        }
        public BookViewModel() 
        {
            AddTempBookIntoList();
        }
        public void AddTempBookIntoList()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("B01","C# for beginner","10/11/2012","WibuCoder"));
            books.Add(new Book("B02","C++ for beginner", "09/11/2014", "WibuCoder"));
            books.Add(new Book("B03","Welcome to Hello World", "11/01/2010", "WibuCoder"));
            books.Add(new Book("B04","Life", "17/02/2012", "WibuCoder"));

            ListBook = books;
        }
    }
}
