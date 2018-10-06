using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vTrackingTimer : MonoBehaviour {

    public Text timerText;
    [HideInInspector]
    public static float time;
    private bool toggleColor = false;

	// Update is called once per frame
	void Update () {
        if(vPickupItem.NumberPizzasPickedUp >= vPickupItem.TOTAL_LVL1
            || (vPickupItem.Level1Complete && vPickupItem.NumberPizzasPickedUp >= vPickupItem.TOTAL_LVL2))
        {
            timerText.color = toggleColor ? Color.green : Color.red;
            toggleColor = toggleColor ? false : true;
            return;
        }

        time += Time.deltaTime;

        var seconds = time % 60;
        var minutes = Mathf.Floor(time / 60) % 60;        

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
