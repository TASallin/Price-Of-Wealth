using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AreaButton : MonoBehaviour {	

    public TextMeshProUGUI info;
	public GameObject loading;
	
	public void Enter (string location) {
		Areas.location = location;
		loading.SetActive(true);
		SceneManager.LoadScene("Dungeon");
	}
	
	public void OnHover(string location) {
		string extra;
		if (Areas.cleared[location]) {
			extra = "Cleared";
		} else {
			extra = Areas.scouting[location];
		}
		info.text = "This Area: " + extra;
	}
	
	public void OffHover() {
		info.text = "This Area: ";
	}
}
