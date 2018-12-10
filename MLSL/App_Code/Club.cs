using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Club
/// </summary>
public class Club
{
    public String c_name { get; set; }
    public String c_city { get; set; }
    public String c_address { get; set; }
    public String c_registration_number { get; set; }
    public List<Player> Players { get; set; }

    public Club()
    {
        Players = new List<Player>();
    }

    public void setData(String a, String b, String c, String d)
    {
        c_name = a;
        c_city = b;
        c_address = c;
        c_registration_number = d;

    }

   
}