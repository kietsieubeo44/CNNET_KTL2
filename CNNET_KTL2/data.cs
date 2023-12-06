using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CNNET_KTL2
{
    class data
    {
        public static string chuoikn = ("Data Source = PC01; Initial Catalog = QLCHS; Integrated Security = True");
        public SqlConnection con = new SqlConnection();
        //pt kkhoi tao
        public data()
        {
            con = new SqlConnection(chuoikn);
        }
        //pt xu lia
        public void open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public int getNQR(string sql)
        {
            open();  // Opens the database connection
            SqlCommand cmd = new SqlCommand(sql, con);  // Creates a new SqlCommand with the provided SQL query and connection
            int kq = cmd.ExecuteNonQuery();  // Executes the SQL query and returns the number of rows affected
            close();  // Closes the database connection
            return kq;  // Returns the result (number of rows affected)
        }

        public DataSet getDT(string sqlquery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            da.Fill(ds);
            return ds;
        }
        public DataTable getDTB(string sqlquery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public int getScalar(string sqlquery)
        {
            open();
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            int kq = (int)cmd.ExecuteScalar();
            close();
            return kq;
        }
    }
}
