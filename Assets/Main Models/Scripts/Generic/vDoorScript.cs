using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vDoorScript : MonoBehaviour
{

    public GameObject _door;
    public AudioClip _audioClip;
    private Text _textWin;
    private bool _unlocked = false;
    private bool _opened = false;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Door Init: I'm the " + tag + ".");
    }

    // Update is called once per frame
    void Update()
    {
        if ((_door.CompareTag("GreenDoor") && vPickupItem.Level1Complete && vPickupItem.NumberPizzasPickedUp == vPickupItem.TOTAL_LVL1)
            || (_door.CompareTag("RedDoor") && vPickupItem.Level2Complete && vPickupItem.NumberPizzasPickedUp == vPickupItem.TOTAL_LVL2)
            && !_unlocked)
        {
            _unlocked = true;
            var objs = Resources.FindObjectsOfTypeAll(typeof(Text));
            foreach (var holder in objs)
            {
                if (holder.name.Equals("lblVictory"))
                {
                    _textWin = (Text)holder;
                }
            }
        }

        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.down*-8.0f;
        float seconds;

        if (Input.GetKeyDown(vThirdPersonInput.interactInput) && _unlocked && !_opened)
        {
            _opened = true;
            seconds = Time.time;
            transform.position = Vector3.Lerp(start, end, Time.time/(seconds+Time.deltaTime));
            _door.GetComponent<AudioSource>().PlayOneShot(_audioClip);

            var textWinRect = _textWin.GetComponent<RectTransform>();
            textWinRect.anchoredPosition = new Vector3(-6.3f, -381.2f, 0.0f);
            vPickupItem.NumberPizzasPickedUp = 0;
            vPickupItem.statText.text = "0";
            vTrackingTimer.time = 0;

            vThirdPersonInput.StaticOMO.GetComponent<AudioSource>().Stop();
            vThirdPersonInput.StaticOMO.GetComponent<AudioSource>().PlayOneShot(vThirdPersonInput.StaticAudio[0]);
        }
    }
}
