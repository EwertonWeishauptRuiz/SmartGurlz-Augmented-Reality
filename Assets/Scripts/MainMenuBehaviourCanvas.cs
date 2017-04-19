using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviourCanvas : MonoBehaviour {

    public GameObject canvasLanscape;
    public GameObject canvasPortrait;
	void Update () {
        if (Screen.orientation == ScreenOrientation.Landscape ||
            Screen.orientation == ScreenOrientation.LandscapeLeft ||
            Screen.orientation == ScreenOrientation.LandscapeRight) {
            canvasLanscape.SetActive(true);
            canvasPortrait.SetActive(false);
        } else {
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
