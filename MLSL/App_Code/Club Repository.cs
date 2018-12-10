using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Club_Repository
/// </summary>
public class Club_Repository
{
    public List<Club> ClubData { get; private set; }

    public Club_Repository()
    {
        ClubData = new List<Club>();
    }
}