using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Player
/// </summary>
public class Player
{
    int jersey_number;
    String dob;
    String player_name;

    public Player()
    {
        
    }
    public void setData(int a, String b, String c)
    {
        jersey_number = a;
        dob = b;
        player_name = c;
    }

}