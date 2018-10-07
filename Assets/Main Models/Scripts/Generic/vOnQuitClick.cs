using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vOnQuitClick : MonoBehaviour {

	public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
