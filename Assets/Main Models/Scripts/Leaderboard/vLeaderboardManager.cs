using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class vLeaderboardManager : MonoBehaviour {

    private static string LeaderboardURL = "http://dreamlo.com/lb/S015VoJJK0axVX8tW-3MbQ_14WDzqYmEaAUmi3x1GH8Q";
    public static string PlayerName = "Arthropod";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Format: add/NAME:Carmine/SCORE:1000/TIME:90 </remarks>
    public static void AddScore()
    {
        var score = vTrackingTimer.times.Aggregate((curr, next) => 100 - (curr + next) % 100);
        using (var web = new WWW(LeaderboardURL+"/add/"+PlayerName+"/"+score+"/"+vTrackingTimer.FormatTime(score)+"/"))
        {
            Debug.Log("Total times added: "+score);
            Debug.Log("[WWW Response] --> "+Encoding.UTF8.GetString(web.bytes));
        }
    }
}
