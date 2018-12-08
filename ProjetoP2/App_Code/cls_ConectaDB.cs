using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for cls_ConectaDB
/// </summary>
public class cls_ConectaDB
{
    string strCon = "Data Source=.\\SQLEXPRESS;Initial Catalog=PW;Integrated Security=True";
    SqlConnection conn = new SqlConnection();

    public SqlDataReader Dr_SQL(string strCmd)
    {
        
        conn.ConnectionString = this.strCon;
        conn.Open();

        SqlCommand cmd = new SqlCommand(strCmd, conn);

        SqlDataReader dr = cmd.ExecuteReader();
       // conn.Close();
        return dr;
    }

    public DataTable Dt_SQL(String strCmd)
    {
        DataTable dt = new DataTable();

        //SqlConnection conn = new SqlConnection();
        conn.ConnectionString = this.strCon;
        try
        {
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);

            da.Fill(dt);

            conn.Dispose();
            da.Dispose();
            conn.Close();
        }
        catch
        {
        }
        return dt;
    }

    public bool ExecNonQuery(String strCmd)
    {
        try
        {
            //SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.strCon;
            conn.Open();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = strCmd;
            comando.Connection = conn;
            comando.ExecuteNonQuery();

            conn.Dispose();
            comando.Dispose();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public void Close()
    {
        conn.Close();
    }
}