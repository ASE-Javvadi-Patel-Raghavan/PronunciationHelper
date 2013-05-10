using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Registration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Registration : System.Web.Services.WebService {

    public Registration () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string SHRegistration(String Username, String Password, String Name, String Emailid) {
        string v_names = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();

            bool memExist = false;
            SqlCommand cmd1 = new SqlCommand("select count(*) from [dbo].[User] where username = '"+Username+ "' ");
            cmd1.Connection = conn;
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read() && (int)dr[0] > 0)
            {
                memExist = true;
                v_names = "Username already exists";
            }
            else
            {
                memExist = false;
            }
            dr.Close();
            dr.Dispose();
            if (!memExist)
            {
                SqlCommand cmd = new SqlCommand("insert into [dbo].[User] (username,password,name_txt,email_txt,created_dt,updated_dt) values ('"+Username+ "','"+ Password +"','"+Name+ "','" +Emailid+ "','" +System.DateTime.Today+"', '" +System.DateTime.Today+"')", conn); 
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                v_names = "Registration Successfull";
                conn.Close();
            }            
        }
        catch (Exception ex)
        {
            v_names = "Error in Registration";
        }
        return v_names;
    }
    
}
