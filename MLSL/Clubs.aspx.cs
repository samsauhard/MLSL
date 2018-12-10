//Student Name: Sauhard
//Student Id: 300986150
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clubs : System.Web.UI.Page
{
    //Declaration of SQL Connection,Reader and Command
    SqlConnection conn;
    SqlCommand comm;
    SqlDataReader reader;

    //Executes When Page Loads
    protected void Page_Load(object sender, EventArgs e)
        {
     //   if (!this.Page.User.Identity.IsAuthenticated)
    //    {
    //        FormsAuthentication.RedirectToLoginPage();
    //    }
    //    else
      //  {

       // }
        //If requested page is not a Postback Request, Then fetch values from database
        if (!IsPostBack)
            {
                //Display Clubs
                BindList();
                comm = new SqlCommand("SELECT * FROM Clubs", conn);
                conn.Open();
                reader = comm.ExecuteReader();
                this.clubsList.DataSource =reader;
                this.clubsList.DataBind();
                reader.Close();
                conn.Close();
            }
        }

     void BindList()
        {       
            String connectionString = ConfigurationManager.ConnectionStrings["ClubConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

    protected void clubListDisplay(object source, DataListCommandEventArgs e)
    {
        //Show Details of new page
        if (e.CommandName == "getDetails")
        {
            string queryString =e.CommandArgument.ToString();

            //Passing query string with URL
            Response.Redirect("clubdetails.aspx?club=" + queryString);
        }
    }
}