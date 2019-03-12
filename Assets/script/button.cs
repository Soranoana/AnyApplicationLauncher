using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void OnLauncherButtonFromMenu() {
        SceneManager.LoadScene("Launcher");
    }

    public void OnUploadButtonFromMenu() {
        SceneManager.LoadScene("Upload");
    }

    public void OnLauncherButtonFromLauncher() {
        SceneManager.LoadScene("Menu");
    }

    public void OnUploadButtonFromUpload() {
        SceneManager.LoadScene("Menu");
    }
}
