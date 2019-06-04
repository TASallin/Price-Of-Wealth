using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpace : MonoBehaviour {
	
	public GameObject button;
	public int index;
	public Queue<int> indexes = new Queue<int>();
	public Transform container;
	public GameObject cancelButton;
	public GameObject description;
	// Use this for initialization
	void Start () {}
	
	public void OnEnable () {
	    foreach (Transform child in container) {
		    if (child.gameObject != cancelButton && child.gameObject != description) {
			    Destroy(child.gameObject);
		    }
	    }
	    index = 0;
	    while (index < 10) {
	    	if (Party.GetItem(index) != null) {
		    	indexes.Enqueue(index);
			    Instantiate(button, container);
		    }
			index++;
		}
	}		
	
	public void Cancel() {
		if (Battle.inBattle) {
			Battle.instance.Cancel(transform.name);
		} else if (Dungeon.inOverworld || Dungeon.inDungeon) {
			Dungeon.instance.CloseBag();
		}
	}
}
