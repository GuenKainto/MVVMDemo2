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
    internal class MangaManagerService
    {
        private DatabaseConnection dtc = new DatabaseConnection();
        private SqlCommand cmd;
        public ObservableCollection<Manga> GetListManga() 
        {
            ObservableCollection<Manga> list = new ObservableCollection<Manga>();
            Manga temp;
            string querry = "SELECT * FROM Manga";
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
                    temp = new Manga();
                    temp.M_ID = reader.GetString(0);
                    temp.M_Name = reader.GetString(1);
                    temp.M_Episode = reader.GetInt32(2);
                    temp.M_Description = reader.GetString(3);
                    temp.M_Age = reader.GetString(4);
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

        public bool Add_Service(Manga manga)
        {
            string querry = "INSERT INTO Manga VALUES (@id,@name,@episode,@description,@age)";
            if (dtc.GetConnection().State == System.Data.ConnectionState.Closed)
            {
                dtc.GetConnection().Open();
            }
            try
            {
                cmd = new SqlCommand(querry, dtc.GetConnection());
                cmd.Parameters.AddWithValue("@id", manga.M_ID);
                cmd.Parameters.AddWithValue("@name", manga.M_Name);
                cmd.Parameters.AddWithValue("@episode", manga.M_Episode);
                cmd.Parameters.AddWithValue("@description", manga.M_Description);
                cmd.Parameters.AddWithValue("@age", manga.M_Age);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }
        public bool Delete_Service(string M_ID)
        {
            string querry = "DELETE FROM Manga WHERE M_Id = " + "'" + M_ID + "'";
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

        public bool UpdateByID_Service(Manga manga, string M_ID)
        {
            string querry = "Update Manga " +
                "SET M_ID = @id, M_NAME = @name, M_EPISODE = @episode, M_DESCRIPTION = @description, M_AGE = @age " +
                "WHERE M_ID = @oldId ";
            if (dtc.GetConnection().State == System.Data.ConnectionState.Closed)
            {
                dtc.GetConnection().Open();
            }
            try
            {
                cmd = new SqlCommand(querry, dtc.GetConnection());
                cmd.Parameters.AddWithValue("@id", manga.M_ID);
                cmd.Parameters.AddWithValue("@name", manga.M_Name);
                cmd.Parameters.AddWithValue("@episode", manga.M_Episode);
                cmd.Parameters.AddWithValue("@description", manga.M_Description);
                cmd.Parameters.AddWithValue("@age", manga.M_Age);
                cmd.Parameters.AddWithValue("@oldid", M_ID);
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
