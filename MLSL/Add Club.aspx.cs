//Code by: SAUHARD 
//Student ID: 300986150

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Add_Club : System.Web.UI.Page
{ 
    //Declaration of SQL Connection,Reader and Command
    SqlConnection conn;
    SqlCommand comm;
    SqlDataReader reader;
    
    //Executes When Page Loads
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
    {
        String region = " ";
        switch (e.PostBackValue)
        {
            case "Canada":
                region = "Canada";
                break;
            case "United States":
                region = "United States";
                break;
            case "Argentina":
                region = "Argentina";
                break;
            case "Brazil":
                region = "Brazil";
                break;
            case "China":
                region = "China";
                break;
            case "India":
                region = "India";
                break;
            case "Africa":
                region = "Africa";
                break;
            case "Russia":
                region = "Russia";
                break;
        }
        Country.Text = "You clicked the " + region + " region.";
    }
    //Function to Save Club. This function is called when User Clicks on Save Club Button
    protected void saveClubOnClick(object sender, EventArgs e)
    {
        //Try Block to Catch Sql Exception
        try
        {
            if (Request.IsAuthenticated)
            {
              
            
            //To Create Database Connection
            BindList();
        
        //Sql Query Stored in SqlCommand instance
        comm = new SqlCommand("INSERT INTO clubs values(@name, @city, @registration_number, @address)", conn);
        
        //Addition of Parameters to be used in SQL Query
        comm.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
        comm.Parameters.Add("@city", System.Data.SqlDbType.VarChar);
        comm.Parameters.Add("@registration_number", System.Data.SqlDbType.VarChar);
        comm.Parameters.Add("@address", System.Data.SqlDbType.VarChar);

        //Assigning Values to Parameters
        comm.Parameters["@name"].Value = ClubDetails.ClubName;
        comm.Parameters["@city"].Value = ClubDetails.ClubCity;
        comm.Parameters["@registration_number"].Value = registrationNumberClub.Text;
        comm.Parameters["@address"].Value = ClubAddress.Text;

        //Opening Connection
        conn.Open();
        
        //Executing Query
        comm.ExecuteNonQuery();

        //Closing Connection
        conn.Close();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
        }

        catch (SqlException)
        {
            //Add Players to a Club if the Club is already present. If User enters Registration Number of already registered club.
            //Exception is Raised and Club Data is Fetched. The option of Adding Players is set to an Active state.
            BindList();
            comm = new SqlCommand("select * from Clubs where registration_number=@registration_number", conn);
            comm.Parameters.Add("@registration_number", System.Data.SqlDbType.VarChar);
            comm.Parameters["@registration_number"].Value = registrationNumberClub.Text;
            conn.Open();

            //Data Fetched is Stored in Reader Record by Recors 
            reader = comm.ExecuteReader();

            //Reading Data Untill there is no data present in reader
            if (reader.Read())
            {

                //Sending Club Data to Frontend from Reader
                ClubDetails.ClubName= reader["name"].ToString();
                ClubDetails.ClubCity = reader["city"].ToString();
                registrationNumberClub.Text = reader["registration_number"].ToString();
                ClubAddress.Text = reader["address"].ToString();
                conn.Close();
                reader.Close();
            }
        }
    
    //Panel which allows to Add Players to club is set to Active State
    PanelPlayer.Visible = true;

    }
    protected void savePlayerOnClick(object sender, EventArgs e)
    {
        BindList();
        comm = new SqlCommand("INSERT INTO players values(@club_registration_number, @name, @date_of_birth, @jersey_number)", conn);
        comm.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
        comm.Parameters.Add("@jersey_number", System.Data.SqlDbType.VarChar);
        comm.Parameters.Add("@club_registration_number", System.Data.SqlDbType.VarChar);
        comm.Parameters.Add("@date_of_birth", System.Data.SqlDbType.VarChar);
        comm.Parameters["@name"].Value = PlayerName.Text;
        comm.Parameters["@jersey_number"].Value = JerseyNumber.Text;
        comm.Parameters["@club_registration_number"].Value = registrationNumberClub.Text;
        comm.Parameters["@date_of_birth"].Value = Convert.ToDateTime(DateOfBirth.Text).ToShortDateString();
        conn.Open();
        comm.ExecuteNonQuery();
    }

    // All fields are cleared and Adding of Players to Club or Adding a New Club is aborted.
    
    protected void cancelClubOnClick(object sender, EventArgs e)
    {
        ClubDetails.ClubName = " ";
        ClubDetails.ClubCity = " ";
        registrationNumberClub.Text = " ";
        ClubAddress.Text = " ";
        PanelPlayer.Visible = false;
    }

    // All fields are cleared for Panel Player
    protected void cancelPlayerOnClick(object sender, EventArgs e)
    {
        PlayerName.Text = " ";
        DateOfBirth.Text = " ";
        JerseyNumber.Text = " ";
    }

    //Creates a Connection to Database
    void BindList()
    {
        String connectionString = ConfigurationManager.ConnectionStrings["ClubConnection"].ConnectionString;
        conn = new SqlConnection(connectionString);
    }
}