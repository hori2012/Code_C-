using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanVien
{
    internal class ConnectionStringSql
    {
        static public void connection(ref SqlConnection cnn)
        {
            string connectionString = @"Data Source = LAPTOP-7ABHDLJ3\SQLEXPRESS; Initial Catalog = QLNhanVien; User ID = CongHao; Password = conghao20";
            cnn = new SqlConnection(connectionString);
        }

    }
}
