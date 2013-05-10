using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Login
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Login : System.Web.Services.WebService {

    public Login () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod (Description = "Aunthitication")]
    public string SHLogin(string username, string password)
    {
        string v_names = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select name_txt from [dbo].[User] where  username ='" + username + "' and password ='" + password + "'");
            cmd.Connection = conn;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                v_names = dr[0].ToString();
            }
            else
            {
                v_names = " User does not exist.";
            }
            dr.Close();
            dr.Dispose();
            conn.Close();

        }
        catch (Exception ex)
        {
            v_names = "Error ";
        }
        return v_names;
       
    }
    
}
