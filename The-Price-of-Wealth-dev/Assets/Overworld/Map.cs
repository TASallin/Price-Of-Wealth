using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

    public GameObject map;
	public GameObject spotlight;
	public static string selectedLocation;
	public static string currentPosition;
	public HelpMenu help;


	public Button tower, diningHall, researchLab, stadium, artCenter, healthBuilding, lectureHalls;

	// Use this for initialization
	void Start () {
		if (Areas.location == "overworld") {
			map.SetActive(true);
			
			spotlight.SetActive(false);
		} else {
			map.SetActive(false);
			spotlight.SetActive(true);
			spotlight.GetComponent<AreaSpotlight>().SetLocation(Areas.location);
		}
		/*
		if (!Areas.tutorialPlayed) {
			Areas.tutorialPlayed = true;
			help.Open();
		}
		*/
		map.transform.Find("Current Location").gameObject.GetComponent<Text>().text = "Current location: " + currentPosition;
		DeactivateCurrentLocation(currentPosition);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void Select (string location) {
		selectedLocation = location;
	}

	public void DeactivateCurrentLocation(string loc) {
		switch(loc) {
			case "tower":
				tower.interactable = false;
				break;
			case "dining":
				diningHall.interactable = false;
				break;
			case "research":
				researchLab.interactable = false;
				break;
			case "sports":
				stadium.interactable = false;
				break;
			case "art":
				artCenter.interactable = false;
				break;
			case "health":
				healthBuilding.interactable = false;
				break;
			case "lecture":
				lectureHalls.interactable = false;
				break;

		}
	}
}
