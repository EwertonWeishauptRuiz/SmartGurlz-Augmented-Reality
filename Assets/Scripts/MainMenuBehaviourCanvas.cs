using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviourCanvas : MonoBehaviour {

    public GameObject canvasLanscape;
    public GameObject canvasPortrait;
	
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.Landscape) {
            Debug.LogError("Landscape");
            canvasLanscape.SetActive(true);
            canvasPortrait.SetActive(false);
        }
        if (Screen.orientation == ScreenOrientation.Portrait) {
            canvasLanscape.SetActive(false);
            canvasPortrait.SetActive(true);
        }
    }

    public void GoToLevels() {
        SceneManager.LoadScene("Levels");
    }

    public void GoToClothes() {
        SceneManager.LoadScene("Clothes");
    }

    public void GoToBirds() {
        SceneManager.LoadScene("LevelsBird");
    }

}
