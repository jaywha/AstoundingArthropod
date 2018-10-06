using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vPickupItem : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip[] _audioClips;
    public GameObject _particle;
    private Text _textNumPickups;
    [HideInInspector]
    public Text _textWin;
    public static Text statText;
    private static bool _audioIndex = false;
    public static int NumberPizzasPickedUp = 0;
    private bool PickedUp = false;
    public static bool Level1Complete = false;
    public static bool Level2Complete = false;
    public static bool Level3Complete = false;
    public static int TOTAL_LVL1 = 27;
    public static int TOTAL_LVL2 = 5;
    public static int TOTAL_LVL3 = 5;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        var objs = Resources.FindObjectsOfTypeAll(typeof(Text));
        foreach (var holder in objs)
        {
            if (holder.name.Equals("txtNumPickups"))
            {
                _textNumPickups = (Text)holder;
            }
            else if (holder.name.Equals("lblVictory"))
            {
                _textWin = (Text)holder;
            }
        }

        statText = _textNumPickups;

        var x = Random.Range(-0.1f, 0.1f);
        var y = Random.Range(-0.1f, 0.1f);
        var z = Random.Range(-0.1f, 0.1f);

        gameObject.transform.Translate(x < 0.0f ? 0.05f : x
                                        , y < 0.0f ? 0.05f : y
                                        , z < 0.0f ? 0.05f : z);
    }

    void OnTriggerEnter(Collider other)
    {
        NumberPizzasPickedUp += 1;

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers) r.enabled = false;

        if (NumberPizzasPickedUp == TOTAL_LVL1 && !Level1Complete)
        {
            PickedUp = true;
            ChangeLevel(1);
        }
        else if (NumberPizzasPickedUp == TOTAL_LVL2 && Level1Complete && !Level2Complete)
        {
            PickedUp = true;
            ChangeLevel(2);
        }
        else if (other.CompareTag("Player") && !PickedUp)
        {
            PickedUp = true;
            _audioSource.PlayOneShot(_audioClips[_audioIndex ? 0 : 1]);
            _textNumPickups.text = NumberPizzasPickedUp.ToString();
            _audioIndex = _audioIndex ? false : true;
            Destroy(gameObject, _audioClips[_audioIndex ? 0 : 1].length);
        }
    }

    void ChangeLevel(int LevelCompleted)
    {
        var textWinRect = _textWin.GetComponent<RectTransform>();
        textWinRect.anchoredPosition = new Vector3(-6.3f, 81.2f, 0.0f);
        switch (LevelCompleted)
        {
            case 1:
                Level1Complete = true;
                break;
            case 2:
                Level2Complete = true;
                _textWin.text = "P I Z Z A\nT I M E\nV I C T O R Y\nGo to the red door!\nPress \"E\" once there.";
                break;
            case 3:
                Level3Complete = true;
                break;
            default:
                break;
        }
        _audioSource.PlayOneShot(_audioClips[2]);
        Destroy(gameObject, _audioClips[2].length);
    }
}