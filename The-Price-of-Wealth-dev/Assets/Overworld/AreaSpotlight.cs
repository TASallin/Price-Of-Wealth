using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreaSpotlight : MonoBehaviour {
    
	public string location;
	public GameObject map;
	public Text currentName;
	public Button shop;
	public Button investigate;
	public GameObject loading;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Enter () {
		Areas.location = location;
		loading.SetActive(true);
		SceneManager.LoadScene("Dungeon");
	}
	
	public void SetLocation(string location) {
		this.location = location;
		currentName.text = Areas.GetLocationFormatted(location);
		if (Areas.cleared[location]) {
			shop.gameObject.SetActive(true);
			investigate.gameObject.SetActive(true);
			Areas.currentShop = Areas.shops[location];
		} else {
			shop.gameObject.SetActive(false);
			investigate.gameObject.SetActive(false);
		}
	}
	
	public void Shop () {
		loading.SetActive(true);
		SceneManager.LoadScene("Shop");
	}
	
	public void Invest () {
		Event e = Investigate.Get(location);
		Dungeon.investigated = e;
		loading.SetActive(true);
		SceneManager.LoadScene("Dungeon");
	}
	
	public void ToMap () {
		location = null;
		Areas.location = "overworld";
		gameObject.SetActive(false);
		map.SetActive(true);
	}
	
	public void Display () {
		gameObject.SetActive(true);
		map.SetActive(false);
	}
}
