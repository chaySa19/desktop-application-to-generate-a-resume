using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVgener
{
    class ADO
    {
        static string strcn = @"Data Source=DESKTOP-TQL2833\SQLEXPRESS;initial catalog=GestioNCV;Integrated Security=True";
        public static void SetData(string req)
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = req;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //message = "Modification Ok !!!!!!!!!!!";
                //State = true;

            }
            catch (Exception ex)
            {
                
            }
        }
        public static DataTable GetData(string req)
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = req;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                cn.Close();
              
                return dt;

            }
            catch (Exception ex)
            {
              
                return null;
            }
        }
    }
}
