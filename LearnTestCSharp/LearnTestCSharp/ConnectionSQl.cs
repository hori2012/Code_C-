using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LearnTestCSharp
{
    internal class ConnectionSQl
    {
        static public void ConnectionStringSettings(ref SqlConnection cnn)
        {
            cnn = new SqlConnection(@"Data Source=LAPTOP-7ABHDLJ3\SQLEXPRESS;Initial Catalog=code_InClass;Integrated Security=True");
            cnn.Open();
        }
    }
}
