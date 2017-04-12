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
            //Waiting on Image
            if (timerImageFound >= 0) {
                if(Screen.orientation == ScreenOrientation.Landscape) {
                    trackAreaImageLandscape.color = Color.green;
                    directionsTextLandscape.SetActive(true);
                } else {
                    trackAreaImagePortrait.color = Color.green;
                    directionsTextPortrait.SetActive(true);
                }                                            
            }
            //When Image Appears
            if (timerImageFound <= 0) {
                footballAssets.SetActive(true);
                if (Screen.orientation == ScreenOrientation.Portrait) {
                    trackAreaPortrait.SetActive(false);
                    directionsTextPortrait.SetActive(false);
                } else {
                    trackAreaLandscape.SetActive(false);
                    directionsTextLandscape.SetActive(false);
                }
            }
        }
        //When tracker is lost.
        if (!trackFound) {
            partyAssets.SetActive(true);
            timerImageFound = 4f;
            footballAssets.SetActive(false);
            if (Screen.orientation == ScreenOrientation.Portrait) {
                trackAreaPortrait.SetActive(true);
                trackAreaImagePortrait.color = Color.red;
                directionsTextPortrait.SetActive(false);
            } else {
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
