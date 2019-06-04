using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSprites : MonoBehaviour {
    
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject[] sprites;
	public Vector3 leadPositionP;// = new Vector3(-564, -20, 0);
	public Vector3 leadPositionE;// = new Vector3(500, -20, 0);
	public Sprite accuracy, apathy, blind, charge, defense, dexterity, evasion, goop, guard, healing, heart, none, nullAttack, nullDefense, poison,
	    power, regeneration, skip, sleep, strength, stun;
	public Dictionary<string, Sprite> decode;
	
	// Use this for initialization
	void Start () {
		sprites = new GameObject[] {player1, player2, player3, player4, enemy1, enemy2, enemy3, enemy4};
		for (int i = 0; i < 8; i++) {
			if (i < 4 && Party.members[i] != null) {
				sprites[i].SetActive(true);
			} else if (i >= 4 && Party.enemies[i - 4] != null) {
				sprites[i].SetActive(true);
				//sprites[i].transform.Find("Image").localScale = new Vector3(-1, 1, 1);
			} else {
				sprites[i].SetActive(false);
			}
		}
		decode = new Dictionary<string, Sprite>();
		decode.Add("accuracy", accuracy); decode.Add("apathy", apathy); decode.Add("blind", blind); decode.Add("charge", charge); decode.Add("defense", defense);
		decode.Add("dexterity", dexterity); decode.Add("evasion", evasion); decode.Add("goop", goop); decode.Add("guard", guard);
		decode.Add("healing", healing); decode.Add("heart", heart); decode.Add("none", none); decode.Add("nullAttack", nullAttack);
		decode.Add("nullDefense", nullDefense); decode.Add("poison", poison); decode.Add("power", power); decode.Add("regeneration", regeneration);
		decode.Add("skip", skip); decode.Add("sleep", sleep); decode.Add("strength", strength); decode.Add("stun", stun);
	}
	
	// Update is called once per frame
	void Update () {
		//sprites = new GameObject[] {player1, player2, player3, player4, enemy1, enemy2, enemy3, enemy4};
		for (int i = 0; i < 8; i++) {
			if (i < 4 && Party.members[i] != null) {
				sprites[i].SetActive(true);
			} else if (i >= 4 && Party.enemies[i - 4] != null) {
				sprites[i].SetActive(true);
			} else {
				sprites[i].SetActive(false);
			}
		}
	}
	
	public void Switch (int a, int b) {
	    Vector3 tempMove = sprites[a].GetComponent<CharSprite>().moveTo;
		sprites[a].GetComponent<CharSprite>().moveTo = sprites[b].GetComponent<CharSprite>().moveTo;
		sprites[b].GetComponent<CharSprite>().moveTo = tempMove;
	}
	
	public void Switch(bool player, int a, int b) {
		if (player) {
		    Switch(a - 1, b - 1);
		} else {
			Switch(a + 3, b + 3);
		}
	}
	
	public void Log(string message, int index) {
		if (sprites[index].activeSelf) {
    		sprites[index].GetComponent<CharSprite>().LogSprite(message, decode["none"]);
		}
	}
	
	public void LogSprite(string message, int index, string sprite) {
		if (sprites[index].activeSelf) {
    		sprites[index].GetComponent<CharSprite>().LogSprite(message, decode[sprite]);
		}
	}
	
	public void UnfreezeAll() {
		foreach (GameObject sprite in sprites) {
			sprite.GetComponent<CharSprite>().freezeHealth = false;
		}
	}
	
	public void ChangeHP(int damage, int index) {
		sprites[index].GetComponent<CharSprite>().ChangeHP(damage);
	}
	
	public bool GoodToGo() {
		foreach (GameObject g in sprites) {
			if (g.activeSelf && !g.GetComponent<CharSprite>().GoodToGo()) {
				return false;
			}
		}
		return true;
	}
}
