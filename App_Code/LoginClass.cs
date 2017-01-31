using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for LoginClass
/// </summary>
public class LoginClass
{
    SqlConnection connect;
    string Email;
    string pass;
    public LoginClass(string emailAddress, string password)
    {
        Email = emailAddress;
        pass = password;
        string connectString =
            ConfigurationManager.ConnectionStrings["CommunityAssistConnection"].ToString();
        connect = new SqlConnection(connectString);
    }

    public int ValidateLogin()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "usp_Login";
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@password", pass);
        connect.Open();
        int result = cmd.ExecuteNonQuery();
        connect.Close();
        int key = 0;
        if(result != -1)
        {
            key = GetUserKey();
        }
        return result;
    }
    
    private int GetUserKey()
    {
        string sql = "Select PersonKey from Person where PersonEmail =@Email";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@Email", Email);
        SqlDataReader reader = null;
        connect.Open();
        reader = cmd.ExecuteReader();
        int key = 0;
        while (reader.Read())
        {
            key = (int)reader["PersonKey"];
        }
        connect.Close();

        return key;
    }


}