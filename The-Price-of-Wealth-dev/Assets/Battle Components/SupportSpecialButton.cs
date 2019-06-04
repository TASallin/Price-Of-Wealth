using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SupportSpecialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public Special special;
	public int index;

	private TextMeshProUGUI label;
	private Button button;

	private void Awake() {
		label = gameObject.GetComponentInChildren<TextMeshProUGUI>();
		button = GetComponent<Button>();
	}
	
	// Use this for initialization
	void Start () {
		button.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {}	
	
	void OnEnable () {
		if (Party.members[index] != null) {
		    Special current = Party.members[index].GetSupportSpecial();
		    label.text = current.GetName();
	    	special = current;
    		if (Party.GetSP() < current.GetCost() || !Party.members[index].GetAlive() || Party.members[index].status.stunned > 0 
			    || Party.members[index].status.asleep > 0 || Party.members[index].status.possessed > 0) {
			    button.interactable = false;
		    } else {
	    		button.interactable = true;
    		}
		} else {
			button.interactable = false;
			label.text = "Slot empty";
		}
	}
	
	public void OnClick () {
		BattleStatic.instance.SupportSpecial(special, index);
	}

	public void OnPointerEnter(PointerEventData e) {
		Description();
	}

	public void OnPointerExit(PointerEventData e) {
		Hide();
	}
	
	public void Description () {
		if (special != null) {
			SpecialStatic.description.GetComponent<TextMeshProUGUI>().text =
    			Party.members[index].ToString() + " - " + special.ToString();
		}
	}
	public void Hide () {
		SpecialStatic.description.GetComponent<TextMeshProUGUI>().text = "";
	}
}