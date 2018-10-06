using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vMainMenuController : MonoBehaviour {

    public Button[] menuButtons;
    public AudioSource menuAudioPlayer;

	// Use this for initialization
	void Start () {
        menuAudioPlayer.Play();
        menuButtons[0].onClick.AddListener(StartButtonClick);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void StartButtonClick()
    {
        menuAudioPlayer.Stop();
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }
}
