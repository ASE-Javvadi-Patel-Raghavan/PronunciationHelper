using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for GroupSelection
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GroupSelection : System.Web.Services.WebService {

    public GroupSelection () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string SHGroupSelection(String Username, String Groupname)
        {
        string v_names = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();

            bool usergroupExist = false;
            SqlCommand cmd2 = new SqlCommand("select groupid from [dbo].[Group] where groupname = '" + Groupname + "' ");
             cmd2.Connection = conn;
           int Groupid = (int)cmd2.ExecuteScalar();
           
            SqlCommand cmd1 = new SqlCommand("select count(*) from [dbo].[UserGroup] where username = '" + Username + "' and groupid ='" + Groupid + "' ");
            cmd1.Connection = conn;
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read() && (int)dr[0] > 0)
            {
                usergroupExist = true;
                v_names = "User and group combination already exists";
            }
            else
            {
                usergroupExist = false;
            }
            dr.Close();
            dr.Dispose();
            if (!usergroupExist)
            {
                SqlCommand cmd = new SqlCommand("insert into [dbo].[UserGroup] (username,groupid) values ('" + Username + "','" + Groupid + "')", conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                v_names = "Group is assigned to the user";
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            v_names = "Error in Assigning a group";
        }
        return v_names;
    }

}