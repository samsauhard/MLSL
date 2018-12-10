//Student Name: SAUHARD
//Student Id : 300986150
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class clubdetails : System.Web.UI.Page
{

    //Declaration of SQL Connection,Reader and Command
    SqlConnection conn;
    SqlCommand comm;
    SqlDataReader reader;
    String s;   

    //Executes When Page Loads
    protected void Page_Load(object sender, EventArgs e)
    {
        //Fetching Registration ID from Club Page Redirection URL
        s = Request.QueryString["club"];

        //If requested page is not a Postback Request, Then fetch values from database 
        if (!IsPostBack)
        {

            //To Create Database Connection
            BindList();

            //Sql Query Stored in SqlCommand instance
            comm = new SqlCommand("SELECT * FROM Clubs where registration_number = @id", conn);
            comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            comm.Parameters["@id"].Value = s;
            conn.Open();
            reader = comm.ExecuteReader();

            //Assigning Data source to Data List
            this.clubsDetailedList.DataSource = reader;

            //Binding Data to Data List
            this.clubsDetailedList.DataBind();

            reader.Close();
            conn.Close();

            //To Create Database Connection
            BindList();

            comm = new SqlCommand("SELECT * FROM Players where club_registration_number = @id", conn);
            comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            comm.Parameters["@id"].Value = s;
            conn.Open();
            reader = comm.ExecuteReader();

            //Assigning Data Source to Grid View
            GridView1.DataSource = reader;

            //Binding Data to Grid View
            GridView1.DataBind();

            reader.Close();
            conn.Close();
        }
    }
    


    protected void clubDetailedListDisplay(object source, DataListCommandEventArgs e)
    {
        // Which button was clicked?
        if (e.CommandName == "deleteClub")
        {
            if (!Request.IsAuthenticated)
            {
                Button1.Visible = true;
                Label4.Visible = true;
            }
            else
            {

                BindList();

                //Deleting Club Data
                comm = new SqlCommand("delete from Clubs where registration_number=@id ", conn);
                comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
                comm.Parameters["@id"].Value = e.CommandArgument;
                conn.Open();
                comm.ExecuteScalar();
                conn.Close();

                //Deleting all the Players Associated with Club
                comm = new SqlCommand("delete from players where club_registration_number=@id ", conn);
                comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
                comm.Parameters["@id"].Value = e.CommandArgument;
                conn.Open();
                comm.ExecuteScalar();
                conn.Close();


                //Deleting Club Matches
                comm = new SqlCommand("delete from matches where homeid=@id or awayid=@id ", conn);
                comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
                comm.Parameters["@id"].Value = e.CommandArgument;
                conn.Open();
                comm.ExecuteScalar();
                conn.Close();

                //Redirects to Clubs Page
                Response.Redirect("Clubs.aspx");
            }
        }
        else if (e.CommandName == "goBack")
        {
            //Redirects to Clubs Page
            Response.Redirect("Clubs.aspx");
        }

    }

    void BindList()
    {
        String connectionString = ConfigurationManager.ConnectionStrings["ClubConnection"].ConnectionString;
        conn = new SqlConnection(connectionString);
    }


    protected void editPlayer(object sender, GridViewEditEventArgs e )
    {
        if (Request.IsAuthenticated)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindList();

            comm = new SqlCommand("SELECT * FROM Players where club_registration_number = @id", conn);
            comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            comm.Parameters["@id"].Value = s;
            conn.Open();
            reader = comm.ExecuteReader();

            //Assigning Data Source to Grid View
            GridView1.DataSource = reader;

            //Binding Data to Grid View
            GridView1.DataBind();

            reader.Close();
            conn.Close();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void updatePlayer(object sender, GridViewUpdateEventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            TextBox playerName1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("playerName");
            String pname = playerName1.Text;
            System.Diagnostics.Debug.Print(playerName1.Text);
            TextBox playerBirth1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("playerBirth");
            System.Diagnostics.Debug.Print(playerBirth1.Text);
            String pbirth = playerBirth1.Text;
            TextBox jersey = (TextBox)GridView1.Rows[e.RowIndex].FindControl("playerJersey");
            String jerseyno = jersey.Text;

            BindList();
            //Sql Query Stored in SqlCommand instance
            comm = new SqlCommand("UPDATE Players SET name=@name,date_of_birth=@birth WHERE (jersey_number = @jno and club_registration_number = @id)", conn);
            comm.Parameters.Add("@jno", System.Data.SqlDbType.VarChar);
            comm.Parameters["@jno"].Value = jerseyno;
            comm.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
            comm.Parameters["@name"].Value = pname;
            comm.Parameters.Add("@birth", System.Data.SqlDbType.VarChar);
            comm.Parameters["@birth"].Value = pbirth;
            comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            comm.Parameters["@id"].Value = s;
            conn.Open();
            reader = comm.ExecuteReader();
            reader.Close();
            conn.Close();

            //To Create Database Connection
            BindList();

            comm = new SqlCommand("SELECT * FROM Players where club_registration_number = @id", conn);
            comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            comm.Parameters["@id"].Value = s;
            conn.Open();
            reader = comm.ExecuteReader();

            //Assigning Data Source to Grid View
            GridView1.DataSource = reader;

            GridView1.DataBind();

            reader.Close();
            conn.Close();
            Response.Redirect("clubdetails.aspx?club=" + s);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void playerCancelEdit(Object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindList();

        comm = new SqlCommand("SELECT * FROM Players where club_registration_number = @id", conn);
        comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
        comm.Parameters["@id"].Value = s;
        conn.Open();
        reader = comm.ExecuteReader();

        //Assigning Data Source to Grid View
        GridView1.DataSource = reader;

        GridView1.DataBind();

        reader.Close();
        conn.Close();
    }

    protected void playerDelete(Object sender, GridViewDeleteEventArgs e)
    {
        if (Request.IsAuthenticated)
        {

            BindList();
            //Sql Query Stored in SqlCommand instance
            comm = new SqlCommand("delete from Players WHERE jersey_number = @jno", conn);
            comm.Parameters.Add("@jno", System.Data.SqlDbType.VarChar);
            comm.Parameters["@jno"].Value = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            conn.Open();
            reader = comm.ExecuteReader();
            conn.Close();

            BindList();
            comm = new SqlCommand("SELECT * FROM Players where club_registration_number = @id", conn);
            comm.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            comm.Parameters["@id"].Value = s;
            conn.Open();
            reader = comm.ExecuteReader();

            //Assigning Data Source to Grid View
            GridView1.DataSource = reader;

            GridView1.DataBind();

            reader.Close();
            conn.Close();
            Response.Redirect("clubdetails.aspx?club=" + s);

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}