using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class dbManager
{
    private String connection_string;
    SqlConnection con=null;
    SqlCommand cmd=null;
    SqlDataAdapter ad=null;
    DataSet ds= new DataSet();
    

    public dbManager(String connectionString)
    {
        connection_string = connectionString;
    }
    public DataSet getData(String query)
    {
        try
        {

            con= new SqlConnection(connection_string);
            con.Open();
            cmd = new SqlCommand(query, con);
            ad=new SqlDataAdapter(cmd);
            ad.Fill(ds);
        }
        catch (SqlException ex)
        {
            return ds;
        }
        finally
        {
            con.Close();
        }
        return ds;
    }
    public int execute_Query(String query)
    {
        int result = 0;
        try
        {
            con = new SqlConnection(connection_string);
            con.Open();
            cmd = new SqlCommand(query, con);
            result = cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            result = 0;
        }
        finally
        {
            con.Close();
        }
        return result;
    }
}