using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vDoorScript : MonoBehaviour {

    public GameObject _door;
    public AudioClip _audioClip;
    private Text _textWin;
    private bool _unlocked = false;
    private bool _opened = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(vPickupItem.NumberPizzasPickedUp == vPickupItem.TOTAL_LVL1 && !_unlocked)
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

        if (Input.GetKeyDown(vThirdPersonInput.interactInput) && _unlocked && !_opened)
        {
            _opened = true;
            transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            transform.Translate(-10.0f, 0.0f, 1.0f);
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
