using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	
	public Item item;
	public int index;
	public GameObject messageLog;
	
	public ItemButton(Item item) {this.item = item;}

	private TextMeshProUGUI label;
	private Button button;
	
	void Awake() {
		label = gameObject.GetComponentInChildren<TextMeshProUGUI>();
		button = GetComponent<Button>();
	}

	void Start () {
		if (Battle.inBattle) {
	      index = ItemStatic.instance.indexes.Dequeue();
		} else if (Dungeon.inDungeon || Dungeon.inOverworld) {
				index = Dungeon.instance.bagMenu.GetComponent<ItemSpace>().indexes.Dequeue();
		}
		
		item = Party.GetItem(index);
		label.text = item.GetName();
		
		try {
		    messageLog = gameObject.transform.parent.parent.Find("Message Log").gameObject;
		} catch {
			messageLog = null;
		}
		if (!Battle.inBattle & !item.usableOut) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData e) {
		Description();
	}

	public void OnPointerExit(PointerEventData e) {
		Hide();
	}
	
	public void Consume () {
        Destroy(gameObject);		
	}
	
	public void Clicked () {
		Party.UseItem(index);
		try {
			if (Battle.inBattle) {
	        BattleStatic.instance.UseItem(item);
			} else if (Dungeon.inDungeon || Dungeon.inOverworld) {
					Dungeon.instance.UseItem(item);
			}
	    } catch {
			gameObject.transform.parent.parent.gameObject.GetComponent<Dungeon>().UseItem(item);
		}
	}
	
	void OnDestroy () {
	}
	
	public void Description () {
		if (Battle.inBattle) {
			ItemStatic.description.text = item.GetDescription();
		} else if (Dungeon.inDungeon || Dungeon.inOverworld) {
			Dungeon.instance.bagMenu.transform.RecursiveFind("Description").gameObject.GetComponent<TextMeshProUGUI>().text = item.GetDescription();
		}
	}
	
    public void Hide () {
		if (Battle.inBattle) {
			ItemStatic.description.text = "";
		} else if (Dungeon.inDungeon || Dungeon.inOverworld) {
			Dungeon.instance.bagMenu.transform.RecursiveFind("Description").gameObject.GetComponent<TextMeshProUGUI>().text = "";
		}
	}
}
