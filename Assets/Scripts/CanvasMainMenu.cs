using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMainMenu : MonoBehaviour {

    public void FootballLoader() {
        SceneManager.LoadScene("ClothesPackages");
    }

    public void LevelsLoader() {
        SceneManager.LoadScene("LevelsAR");
    }
}
