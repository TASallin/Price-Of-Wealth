using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TacticButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public Special special;
	public int index;
	public static Special[] options = new Special[] {new QuickChange(), new Roll(), new PowerStrike(), new Breakthrough()};
	

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
		Special current = options[index];
		label.text = current.GetName();
		special = current;
	if (Party.GetSP() < current.GetCost() || Party.GetPlayer().status.asleep > 0 || Party.GetPlayer().status.stunned > 0) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
	}

	public void OnPointerEnter(PointerEventData e) {
		Description();
	}

	public void OnPointerExit(PointerEventData e) {
		Hide();
	}
	
	public void OnClick () {
		BattleStatic.instance.UseSpecial(special);
	}
	
	public void Description () {
		SpecialStatic.description.GetComponent<TextMeshProUGUI>().text = special.ToString();
	}
	
	public void Hide () {
		SpecialStatic.description.GetComponent<TextMeshProUGUI>().text = "";
	}
}