using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vMainMenuController : MonoBehaviour {

    public Camera mainCamera;
    public Button menuButton;
    public InputField menuTextbox;
    public AudioSource menuAudioPlayer;
    public static string playerName;

    private static float degreeTurn = 93.0f;

    // Use this for initialization
    void Start() {
        if(menuAudioPlayer != null) menuAudioPlayer.Play();

        var elementToCheck = "";

        if (menuButton != null) elementToCheck = menuButton.tag;
        else if (menuTextbox != null) elementToCheck = menuTextbox.tag;
        else
        {
            Debug.Log(string.Format("This gameobject doesn't have a button or text to bind main menu actions to! Name [{0}] Tag [{1}]", this.name, this.tag));
            return;
        }

        switch (elementToCheck) {
            case "StartButton":
                menuButton.onClick.AddListener(StartButtonClick);
                break;
            case "SettingsButton":
                menuButton.onClick.AddListener(delegate { SwitchMenuClick(degreeTurn); });
                break;
            case "GoBackButton":
                menuButton.onClick.AddListener(delegate { SwitchMenuClick(-degreeTurn); });
                break;
            case "PlayerNameTextbox":
                menuTextbox.onEndEdit.AddListener(delegate { ParseTextboxInput(menuTextbox.text); });
                break;
            default:
                Debug.Log(string.Format("Registered button click without onClick Listener. Tag [{0}]", menuButton.tag));
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {}

    void StartButtonClick()
    {
        if (menuAudioPlayer != null) menuAudioPlayer.Stop();
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }

    void SwitchMenuClick(float degrees)
    {
        mainCamera.transform.Rotate(0.0f, degrees, 0.0f);
    }

    void ParseTextboxInput(string inputText)
    {
        vLeaderboardManager.PlayerName = inputText;
        Debug.Log(string.Format("Current Player Name Updated to {0}!", vLeaderboardManager.PlayerName));
    }
}
