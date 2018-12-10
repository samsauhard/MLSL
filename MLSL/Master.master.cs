using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master : System.Web.UI.MasterPage
{
    SqlConnection conn;
    SqlCommand comm;
    SqlDataReader reader;
    String matches;
    protected void Page_Load(object sender, EventArgs e)
    {
        String connectionString = ConfigurationManager.ConnectionStrings["ClubConnection"].ConnectionString;
        if (!IsPostBack)
        { 
        matches = " ";
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("SELECT * FROM matches", conn);
        conn.Open();
        reader = comm.ExecuteReader();
        
        while (reader.Read())
        {
           matches+= reader["matchdate"] + "-" + reader["home"] + "  VS  " + reader["away"] + "<br/>";
               
        }

        print_matches.Text = matches;
        reader.Close();
        conn.Close();
        }
        matches = " ";
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("SELECT * FROM matches", conn);
        conn.Open();
        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            matches += reader["matchdate"] + "-" + reader["home"] + "  VS  " + reader["away"] + "<br/>";

        }

        print_matches.Text = matches;
        reader.Close();
        conn.Close();
    }

}
