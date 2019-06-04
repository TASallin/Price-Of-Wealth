using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TravelButton : MonoBehaviour {
    
	public GameObject map;
	public GameObject spotlight;

	public bool returnButton = false;
	// Use this for initialization
	void Start () {
		if (returnButton) {
			GetComponentInChildren<TextMeshProUGUI>().text = "Return to the " + Areas.GetLocationFormatted(Map.currentPosition);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick () {
		Areas.location = Map.selectedLocation;
		spotlight.GetComponent<AreaSpotlight>().SetLocation(Map.selectedLocation);
		if (Map.selectedLocation == Map.currentPosition || returnButton) {
			spotlight.GetComponent<AreaSpotlight>().Display();
		} else {
			Map.currentPosition = Map.selectedLocation;
			//map.transform.Find("Current Location").gameObject.GetComponent<Text>().text = "Current location: " + Map.currentPosition;
			gameObject.GetComponent<OverworldEncounters>().Battle();
			//spotlight.GetComponent<AreaSpotlight>().Display();
		}
	}
}
