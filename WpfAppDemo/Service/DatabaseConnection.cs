using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfAppDemo.Service
{
    internal class DatabaseConnection
    {
        private SqlConnection dc = new SqlConnection("Data Source = LAPTOP-T46EHQ2Q; Initial catalog = MVVMDemo2; Integrated Security=true; TrustServerCertificate=True");
        public SqlConnection GetConnection()
        {
            return dc; 
        }
    }
}
