using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuReturn : MonoBehaviour {

    public GameObject canvasLanscape;
    public GameObject canvasPortrait;

    public Text text;

    void Update() {
        if (Screen.orientation == ScreenOrientation.Landscape ||
            Screen.orientation == ScreenOrientation.LandscapeLeft ||
            Screen.orientation == ScreenOrientation.LandscapeRight) {
            Debug.LogError("Landscape");
            text.text = ("Landscape");
            canvasLanscape.SetActive(true);
            canvasPortrait.SetActive(false);
        }
        if (Screen.orientation == ScreenOrientation.Portrait || 
            Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
            text.text = ("portrait");
            canvasLanscape.SetActive(false);
            canvasPortrait.SetActive(true);
        }
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
