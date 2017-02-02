﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for GrantClass
/// </summary>
public class GrantClass
{
    private SqlConnection connect;
    public GrantClass()
    {
        string connectString = ConfigurationManager.ConnectionStrings["CommunityAssistConnection"].ToString();
        connect = new SqlConnection(connectString);
    }

    public DataTable GetGrants(int GrantTypeKey)
    {
        DataTable table = new DataTable();
        string sql = "Select GrantReviewDate as [Date], "
 + "GrantRequestExplanation as Explanation, "
 + "GrantAllocationAmount as Amount, "
 + "GrantRequestStatus as [Status] "
 + "From GrantRequest r "
 + "inner join GrantReview gr "
 + "on r.GrantRequestKey = gr.GrantRequestKey "
 + " Where GrantTypeKey = @GrantTypeKey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@GrantTypeKey", GrantTypeKey);
        SqlDataReader reader = null;
        connect.Open();
        reader = cmd.ExecuteReader();
        table.Load(reader);
        reader.Close();
        connect.Close();
        return table;
    }

    public DataTable GetGrantType()
    {
        DataTable table = new DataTable();
        string sql = "Select GrantTypeKey, GrantTypeName from GrantType";
        SqlCommand cmd = new SqlCommand(sql, connect);
        SqlDataReader reader = null;
        connect.Open();
        reader = cmd.ExecuteReader();
        table.Load(reader);
        reader.Close();
        connect.Close();
        return table;
    }


}
