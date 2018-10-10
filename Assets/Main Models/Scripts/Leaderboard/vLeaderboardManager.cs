using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Net;
using UnityEngine;

public static class vLeaderboardManager {

    private static string LeaderboardURL = "http://dreamlo.com/lb/S015VoJJK0axVX8tW-3MbQ_14WDzqYmEaAUmi3x1GH8Q";
    public static string PlayerName = "Arthropod";

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Format: add/NAME:Carmine/SCORE:1000/TIME:90 </remarks>
    public static string AddScore()
    {
        var score = vTrackingTimer.times.Aggregate((curr, next) => 100 - (curr + next) % 100);
        using (var web = new WebClient())
        {
            if (PlayerName.Equals("Arthropod")) PlayerName += (new System.Random()).Next();
            web.OpenReadAsync(new Uri(LeaderboardURL + "/add/" + PlayerName + "/" + score + "/" + vTrackingTimer.FormatTime(score) + "/"));
        }
        return PlayerName;
    }
}
