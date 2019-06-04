using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class MessageLog : MonoBehaviour {
	
	public GameObject messagePrefab;
	public LinkedList<string> previous;
	private Transform content;


	// Use this for initialization
	void Start () {
		content = transform.RecursiveFind("Content");
		previous = new LinkedList<string>();
		previous.AddFirst("");
		SetMessage("");
	}
	

	//Append message so user can see entire log always
	public void SetMessage(string contents) {
		if (contents != "") {
		    previous.AddFirst(contents);
			GameObject o = Instantiate(messagePrefab, content);
			o.GetComponentInChildren<TextMeshProUGUI>().text = contents;
		}
	}
}
