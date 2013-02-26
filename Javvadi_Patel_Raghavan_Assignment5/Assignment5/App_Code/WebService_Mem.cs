using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for WebService_Mem
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService_Mem : System.Web.Services.WebService {

    public WebService_Mem () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string Members()
    {
        string v_names = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();

            bool memExist = false;
            SqlCommand cmd1 = new SqlCommand("select count(*) from [dbo].[Members]");
            cmd1.Connection = conn;
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read() && (int)dr[0] > 0)
            {
                memExist = true;
            }
            else
            {
                v_names = " Member does not exist.";
            }
            dr.Close();
            dr.Dispose();
            if (memExist)
            {
                SqlCommand cmd = new SqlCommand("select membername_txt from [dbo].[Members]");
                cmd.Connection = conn;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    v_names = dr[0].ToString();
                    while (dr.Read())
                    {
                        v_names = string.Concat(v_names, ", ", dr[0].ToString());

                    }
                }
                else
                {
                    v_names = " There are no other members.";
                }
                dr.Close();
                dr.Dispose();
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            v_names = "Error in retriving the name";
        }
        return v_names;

    }
    
    
}
