//Student Name: SAUHARD
//StudentId: 300986150
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Match_Scheduling : System.Web.UI.Page
{
    //Declaration of SQL Connection,Reader and Command
    SqlConnection conn;
    SqlCommand comm;
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        BindList();

        // Do not Load DropDown Data if the Request is Postback 
        if (!IsPostBack)
        { 
            ErrorOutput.Text = "Both Home and Away Team Cannot be same";
           
            comm = new SqlCommand("SELECT * FROM Clubs ", conn);
            conn.Open();
            reader = comm.ExecuteReader();
            HomeClubdDropdown.DataSource = reader;
            HomeClubdDropdown.DataValueField = "registration_number";
            HomeClubdDropdown.DataTextField = "name";
            HomeClubdDropdown.DataBind();
            reader.Close();
            conn.Close();
            comm = new SqlCommand("SELECT * FROM Clubs", conn);
            conn.Open();
            reader = comm.ExecuteReader();
            AwayClubDropdown.DataSource = reader;
            AwayClubDropdown.DataValueField = "registration_number";
            AwayClubDropdown.DataTextField = "name";
            AwayClubDropdown.DataBind();
            reader.Close();
            conn.Close();
        }

            // Load Matches on Every Request
            comm = new SqlCommand("SELECT * FROM matches", conn);
            conn.Open();
            reader = comm.ExecuteReader();
            GridViewFixtures.DataSource = reader;
            GridViewFixtures.DataBind();
            reader.Close();
            conn.Close();
    }


    protected void dateSelectionCalanderOnDayRender(object sender, DayRenderEventArgs e)
    {
        //Get All Match Days
        comm = new SqlCommand("SELECT * FROM matches", conn);
        conn.Open();
        reader = comm.ExecuteReader();
        while (reader.Read())
        {
            String home = reader["home"].ToString();
            String away = reader["away"].ToString();
            DateTime matchdate = Convert.ToDateTime(reader["matchdate"].ToString());
            if (e.Day.Date == matchdate)
            {
                // Set all matchdays to Green
                e.Cell.BackColor = Color.Green;
            }
            else
            { }
        }
        if (e.Day.Date >= DateTime.Now.Date)
        { }
        else
        {
            //Disable all past days
            e.Day.IsSelectable = false;
        }
        conn.Close();
        reader.Close();

        //Select Match dates for both clubs selected in the home and away dropdown
        comm = new SqlCommand("SELECT matchdate FROM matches where homeid=@homeid or awayid=@awayid or homeid=@awayid or awayid=@homeid", conn);
        conn.Open();
        comm.Parameters.Add("@homeid", System.Data.SqlDbType.VarChar);
        comm.Parameters["@homeid"].Value = HomeClubdDropdown.SelectedValue;
        comm.Parameters.Add("@awayid", System.Data.SqlDbType.VarChar);
        comm.Parameters["@awayid"].Value = AwayClubDropdown.SelectedValue;
        reader = comm.ExecuteReader();
        while (reader.Read())
        {   
            DateTime matchdate = Convert.ToDateTime(reader["matchdate"].ToString());

            //Club Cannot have match within 2 days of a match and disable these days
            if (e.Day.Date == matchdate || e.Day.Date == matchdate.AddDays(1) || e.Day.Date == matchdate.AddDays(2) || e.Day.Date == matchdate.AddDays(-2) || e.Day.Date == matchdate.AddDays(-1))
            {

                //Disable Date and Set Color to Red
                e.Day.IsSelectable = false;
                e.Cell.BackColor = Color.Red;
            }
            else
            { }
        }
        conn.Close();
        reader.Close();       
    }
    public void Selection_Change(Object sender, EventArgs e)
    {
        //Display Selected Date
        String CheckDateDate = DateSelectionCalander.SelectedDate.ToShortDateString();
        SelectedDate.Text = "The selected date is " + DateSelectionCalander.SelectedDate.ToShortDateString();
    }
    protected void scheduleMatch(object sender, EventArgs e)
    {
        //Validation on Dropdown
        if (HomeClubdDropdown.SelectedItem.Text == AwayClubDropdown.SelectedItem.Text)
        {
            ErrorOutput.Text = "Home and Away Cannot be same";
        }
        else
        {
            ErrorOutput.Text = "";

            //Validation on Calendar Selection
            if (DateSelectionCalander.SelectedDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
            {
                ErrorOutput.Text = "Select Date";
            }
            else
            {
                //Insert into Database
                comm = new SqlCommand("INSERT INTO matches values(@box1, @box2, @date,@homeid,@awayid)", conn);
                comm.Parameters.Add("@date", System.Data.SqlDbType.VarChar);
                comm.Parameters["@date"].Value = DateSelectionCalander.SelectedDate.ToShortDateString();
                comm.Parameters.Add("@box1", System.Data.SqlDbType.VarChar);
                comm.Parameters["@box1"].Value = HomeClubdDropdown.SelectedItem.Text;
                comm.Parameters.Add("@box2", System.Data.SqlDbType.VarChar);
                comm.Parameters["@box2"].Value = AwayClubDropdown.SelectedItem.Text;
                comm.Parameters.Add("@homeid", System.Data.SqlDbType.VarChar);
                comm.Parameters["@homeid"].Value = HomeClubdDropdown.SelectedValue;
                comm.Parameters.Add("@awayid", System.Data.SqlDbType.VarChar);
                comm.Parameters["@awayid"].Value = AwayClubDropdown.SelectedValue;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();

                //Get Matches Again from Database after Insertion of a Match
                comm = new SqlCommand("SELECT * FROM matches", conn);
                conn.Open();
                reader = comm.ExecuteReader();
                GridViewFixtures.DataSource = reader;
                GridViewFixtures.DataBind();
                reader.Close();
                conn.Close();
            }
        }

    }
    void BindList()
    {
        String connectionString = ConfigurationManager.ConnectionStrings["ClubConnection"].ConnectionString;
        conn = new SqlConnection(connectionString);
    }
    protected void DropDownListSelectedIndexChanged(object sender, EventArgs e)
    {
        if (HomeClubdDropdown.SelectedItem.Text == AwayClubDropdown.SelectedItem.Text)
        {
            ErrorOutput.Text = "Both Home and Away Team Cannot be same";
        }
        else
        {
            ErrorOutput.Text = "";
        }
    }
}