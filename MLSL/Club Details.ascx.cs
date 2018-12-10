//Student Name: Sauhard
//Student Id: 300986150
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Club_Details : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public String ClubCity{

        get
        {
          return ClubCityTextBox.Text;
         }
        
        set
        {
            ClubCityTextBox.Text = value;
        }

        }



    public String ClubName
    {

        get
        {
            return ClubNameTextBox.Text;
        }
        set
        {
            ClubNameTextBox.Text = value;
        }




    }
}