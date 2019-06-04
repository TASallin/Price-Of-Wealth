using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpMenu : MonoBehaviour {

    public TextMeshProUGUI text;
	public Button right;
	public Button left;
	public GameObject otherMenu;
	public int index;
	public string[] textArray;
	
	// Use this for initialization
	void Start () {
		textArray = new string[] {
		"<u><b>Welcome to The Price of Wealth</b></u>\n\n<b>Story</b>\nSomeone nefarious has possessed the country through money\n" +
		"As a broke college student, you were unaffected by the curse\n" +
		"You must assemble a team and collect gear to defeat the villain and his 3 subordinates to destroy the source of the possession\n" +
		"First you will want to build your team and gather supplies in your starting location\n" +
		"If your player character reaches 0 hp, it's game over, but you can continue if party members fall\n" +
		"That's it! (You can access this menu now or by clicking the help icon at the top of the screen)",
		
		"<u><b>Stats</b></u>\n\n<b>Strength:</b> Permanent attack power\n<b>Power:</b> Attack power that lasts for the battle\n<b>Charge:</b> Attack power that lasts for 1 attack\n" +
		"<b>Defense:</b> Defense power that lasts for the battle\n<b>Guard:</b> Defense power that lasts for 1 attack\n" +
		"<b>Accuracy:</b> Character's attack will miss if it isn't higher than the target's Evasion\n" +
		"<b>Evasion:</b> Decreases by the attacker's accuracy when the character dodges\n" + 
		"<b>Dexterity:</b> Evasion increases by this number when the character fails to dodge a move\n",
		
		"<u><b>Status Conditions</b></u>\n\n<b>Asleep:</b> Character can not take actions until awoken (randomly or through damage)\n" +
	    "<b>Stunned</b> - Character can not take actions for a number of turns\n" +
		"<b>Poisoned</b> - While in the lead, character takes damage at the start of their turn\n" +
		"<b>Gooped</b> - Character can not take defensive actions or switch out. Skip turn to clean\n" +
		"<b>Blinded</b> - Accuracy is reduced, recovering by 1 each turn\n" +
		"<b>Apathy</b> - While in the lead, Character has a chance to skip their team's turn\n",
		
		"<u><b>Status Conditions</b></u>\n\n" +
		"<b>Regeneration</b> - Character recovers hp every turn\n" +
		"<b>Average</b> - Attack and Defense stats cannot be altered\n" +
		"<b>Rotating</b> - Team switches to their next member at the start of the round\n" +
        "<b>Firewall</b> - Characters that switch in or out take damage\n" + 
        "<b>Possession</b> - Character cannot be recruited\n",
        
        "<u><b>Battle Actions</b></u>\n\n<b>Attack</b> - Attack for at least your strength in attack power\n" +
        "<b>Special:</b> Use a technique that costs SP. SP is gained from defeating enemies\n" +
        "A Primary Special can only be used in the lead. A Support Special can be used from any position\n" +
		"A tactical special can be used by any member of the party\n" +
		"<b>Item:</b> Use an item\nDefense: Pull up the defense menu\nBlock: Gain 5 guard, decreasing in value with successive use\n" +
		"<b>Dodge:</b> Gain 5 evasion\nRun: Run from the battle. The enemy team will take 1 more turn. Currently, you can't run in buildings (will change)\n",
		
		"<u><b>Battle Actions</b></u>\n\n" +
		"<b>Party:</b> Pull up the party menu and see details for the party and enemy team\n" +
		"<b>Switch:</b> put another character in the lead. This consumes a turn\n" +
		"<b>Recruit:</b> Attempt to bring the enemy to your side. They must be alone and not-possessed (college students are not-possessed)",
		
		"<u><b>Battle Mechanics</b></u>\n\nEach round consists of a passive check, the player turn, then the enemy turn\n" +
		"The battle ends when all enemies are neutralized in some way, a boss is defeated, or the player character is defeated\n" +
		"The player character is the powerful one you get at the start of the game that should get a special graphic eventually\n" +
		"At the end of the battle, you gain items from defeated enemies unless the player team fled\n" +
		"This will get more detailed later",
		
		"<u><b>Party and Bag</b></u>\n\nYour party has room for 4 characters. You can still recruit characters on a full party, but someone will have to leave\n" +
		"Each character has a random quirk which acts as a second passive\n" +
		"Your bag can hold up to 10 items. Most items are consumed upon use, but some can be used repeatedly or have passive effects\n" +
		"Some items can only be used in combat or out of combat, or on certain characters\n",
		
		"<u><b>Exploration</b></u>\n\nThe overworld map shows all the locations you can visit and will show paths that connect them\n" +
		"Traveling to a location starts a random battle\nAt a location, you can enter or investigate\n" +
		"Investigating causes a random event to occur\nEntering takes you to the dungeon, where you will face a sequence of events then a boss\n" +
		"You are free to use items, specials, and leave an area between events\n" +
		"After beating the boss and taking the final reward, you will have cleared the area and a trading post will open there\n",
		
		"<u><b>Exploration</b></u>\n\n" +
		"<b>Trading Post</b> - You can trade items and SP for other items, recruits, and services\n" +
		"<b>Time</b> - All random events and progressing through locations increments a hidden counter\n" +
	    "Random events will become more difficult as this counter progresses"};
		index = 0;
		text.text = textArray[index];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ScrollRight () {
		index++;
		text.text = textArray[index];
		if (index == textArray.Length - 1) {
			right.interactable = false;
		}
		left.interactable = true;
	}
	
	public void ScrollLeft () {
		index--;
		text.text = textArray[index];
		if (index == 0) {
			left.interactable = false;
		}
		right.interactable = true;
	}
	
	public void Open () {
		gameObject.SetActive(true);
		otherMenu.SetActive(false);
	}
	
	public void Close () {
		gameObject.SetActive(false);
		otherMenu.SetActive(true);
	}
}
