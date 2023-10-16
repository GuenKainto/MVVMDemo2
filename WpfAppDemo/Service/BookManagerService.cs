using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDemo.Models;

namespace WpfAppDemo.Service
{
    internal class BookManagerService
    {
        private DatabaseConnection dtc = new DatabaseConnection();
        private SqlCommand cmd;
        public ObservableCollection<Book> GetListBook()
        {
            ObservableCollection<Book> list = new ObservableCollection<Book>();
            Book temp;
            string querry = "SELECT * FROM BOOK";
            if (dtc.GetConnection().State == System.Data.ConnectionState.Closed)
            {
                dtc.GetConnection().Open();
            }
            try
            {
                cmd = new SqlCommand(querry, dtc.GetConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp = new Book();
                    temp.B_ID = reader.GetString(0);
                    temp.B_Name = reader.GetString(1);
                    temp.B_DateRelease = reader.GetDateTime(2);
                    temp.B_Publisher = reader.GetString(3);
                    list.Add(temp);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return list;
        }

        public bool Add_Service(Book book)
        {
            string querry = "INSERT INTO BOOK VALUES (@id,@name,@dateRelease,@publisher)";
            if (dtc.GetConnection().State == System.Data.ConnectionState.Closed)
            {
                dtc.GetConnection().Open();
            }
            try
            {
                cmd = new SqlCommand(querry, dtc.GetConnection());
                cmd.Parameters.AddWithValue("@id", book.B_ID);
                cmd.Parameters.AddWithValue("@name", book.B_Name);
                cmd.Parameters.AddWithValue("@dateRelease", book.B_DateRelease.Date);
                cmd.Parameters.AddWithValue("@publisher", book.B_Publisher);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }
        public bool Delete_Service(string B_ID)
        {
            string querry = "DELETE FROM Book WHERE B_Id = " + "'" + B_ID + "'";
            if (dtc.GetConnection().State == System.Data.ConnectionState.Closed)
            {
                dtc.GetConnection().Open();
            }
            try
            {
                cmd = new SqlCommand(querry, dtc.GetConnection());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        public bool UpdateByID_Service(Book book, string B_ID)
        {
            string querry = "Update Book " +
                "SET B_ID = @id, B_NAME = @name, B_DateRelease = @dateRelease, B_Publisher = @publisher " +
                "WHERE B_ID = @oldId ";
            if (dtc.GetConnection().State == System.Data.ConnectionState.Closed)
            {
                dtc.GetConnection().Open();
            }
            try
            {
                cmd = new SqlCommand(querry, dtc.GetConnection());
                cmd.Parameters.AddWithValue("@id", book.B_ID);
                cmd.Parameters.AddWithValue("@name", book.B_Name);
                cmd.Parameters.AddWithValue("@dateReLease", book.B_DateRelease.Date);
                cmd.Parameters.AddWithValue("@publisher", book.B_Publisher);
                cmd.Parameters.AddWithValue("@oldid", B_ID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }
    }
}
