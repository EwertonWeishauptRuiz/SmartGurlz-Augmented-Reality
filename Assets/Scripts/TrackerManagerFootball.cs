using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;



public class TrackerManagerFootball : MonoBehaviour, ITrackableEventHandler {

    private TrackableBehaviour mTrackableBehaviour;

    public GameObject footballAssets;
    public GameObject trackAreaLandscape;
    public GameObject trackAreaPortrait;
    public UnityEngine.UI.Image trackAreaImageLandscape;
    public UnityEngine.UI.Image trackAreaImagePortrait;

    public bool trackFound;

    public float timerImageFound;

    public GameObject directionsTextPortrait;
    public GameObject directionsTextLandscape;

    public GameObject partyAssets;
    public float vibrateTime;
    void Start() {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (trackFound) {
            partyAssets.SetActive(false);
            timerImageFound -= Time.deltaTime;
            vibrateTime -= Time.deltaTime;
            if(vibrateTime >= 0) {
                Handheld.Vibrate();
            }
            //Waiting on Image
            if (timerImageFound >= 0) {
                if (Screen.orientation == ScreenOrientation.Landscape ||
                    Screen.orientation == ScreenOrientation.LandscapeLeft ||
                    Screen.orientation == ScreenOrientation.LandscapeRight) {
                    trackAreaImageLandscape.color = Color.green;
                    directionsTextLandscape.SetActive(true);;
                }
                if (Screen.orientation == ScreenOrientation.Portrait ||
                    Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
                    trackAreaImagePortrait.color = Color.green;
                    directionsTextPortrait.SetActive(true);
                }                                            
            }
            //When Image Appears
            if (timerImageFound <= 0) {
                footballAssets.SetActive(true);
                if (Screen.orientation == ScreenOrientation.Portrait ||
                    Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
                    trackAreaPortrait.SetActive(false);
                    directionsTextPortrait.SetActive(false);
                }
                if (Screen.orientation == ScreenOrientation.Landscape ||
                    Screen.orientation == ScreenOrientation.LandscapeLeft ||
                    Screen.orientation == ScreenOrientation.LandscapeRight) {
                    trackAreaLandscape.SetActive(false);
                    directionsTextLandscape.SetActive(false);
                }
            }
        }
        //When tracker is lost.
        if (!trackFound) {
            partyAssets.SetActive(true);
            timerImageFound = 4f;
            vibrateTime = 0.5f;
            footballAssets.SetActive(false);
            if (Screen.orientation == ScreenOrientation.Portrait ||
                Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
                trackAreaPortrait.SetActive(true);
                trackAreaImagePortrait.color = Color.red;
                directionsTextPortrait.SetActive(false);
            }
            if (Screen.orientation == ScreenOrientation.Landscape ||
                Screen.orientation == ScreenOrientation.LandscapeLeft ||
                Screen.orientation == ScreenOrientation.LandscapeRight) {
                trackAreaImageLandscape.color = Color.red;
                trackAreaLandscape.SetActive(true);
                directionsTextLandscape.SetActive(false);
            }
        }
    }

    public void OnTrackableStateChanged(
                                TrackableBehaviour.Status previousStatus,
                                TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            //When target is found            
            trackFound = true;
        }
        if (newStatus == TrackableBehaviour.Status.NOT_FOUND) {
            // When target is lost
            trackFound = false;
        }
    }
}
