using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public static class vLeaderboardManager {

    private static string LeaderboardURL = "http://dreamlo.com/lb/S015VoJJK0axVX8tW-3MbQ_14WDzqYmEaAUmi3x1GH8Q";
    public static string PlayerName = "Arthropod";

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Format: add/NAME:Carmine/SCORE:1000/TIME:90 </remarks>
    public static IEnumerator AddScore()
    {
        var score = vTrackingTimer.times.Aggregate((curr, next) => 100 - (curr + next) % 100);
        var web = new WWW(LeaderboardURL + "/add/" + PlayerName + "/" + score + "/" + vTrackingTimer.FormatTime(score) + "/");
        
        Debug.Log("Total times added: "+score);
        yield return web;
        Debug.Log("[WWW Response] --> " + Encoding.UTF8.GetString(web.bytes));
    }
}
