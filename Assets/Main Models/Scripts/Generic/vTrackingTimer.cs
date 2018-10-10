using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vTrackingTimer : MonoBehaviour
{

    public Text timerText;
    [HideInInspector]
    public static float time;
    private bool toggleColor = false;
    [HideInInspector]
    public static float[] times = new float[3];

    private bool lvl1Time = false;
    private bool lvl2Time = false;
    private bool lvl3Time = false;

    // Update is called once per frame
    void Update()
    {
        if (vPickupItem.NumberPizzasPickedUp >= vPickupItem.TOTAL_LVL1
            || (vPickupItem.Level1Complete && vPickupItem.NumberPizzasPickedUp >= vPickupItem.TOTAL_LVL2)
            || (vPickupItem.Level1Complete && vPickupItem.Level2Complete && vPickupItem.NumberPizzasPickedUp >= vPickupItem.TOTAL_LVL3))
        {
            timerText.color = toggleColor ? Color.green : Color.red;
            toggleColor = toggleColor ? false : true;
            if (vPickupItem.NumberPizzasPickedUp == vPickupItem.TOTAL_LVL1 && !lvl1Time) {
                times[0] = time; lvl1Time = true;
            }
            else if (vPickupItem.Level1Complete && vPickupItem.NumberPizzasPickedUp == vPickupItem.TOTAL_LVL2 && !lvl2Time) {
                times[1] = time; lvl2Time = true;
            }
            else if (vPickupItem.Level1Complete && vPickupItem.Level2Complete && vPickupItem.NumberPizzasPickedUp == vPickupItem.TOTAL_LVL3 && !lvl3Time) {
                times[2] = time; lvl3Time = true;
            }

            return;
        }

        time += Time.deltaTime;

        timerText.text = FormatTime(time);
    }

    public static string FormatTime(float timeIn)
    {
        var seconds = timeIn % 60;
        var minutes = Mathf.Floor(timeIn / 60) % 60;

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
