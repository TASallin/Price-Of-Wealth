using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class Areas {
	
	//public static Queue<Event> tower;
	//public static Queue<Event> dining;
	//public static Queue<Event> research;
	//public static Queue<Event> lecture;
	//public static Queue<Event> sports;
	//public static Queue<Event> art;
	//public static Queue<Event> health;
	//public static Event[] tower1;
	//public static Event[] dining1;
	//public static Event[] research1;
	//public static Event[] lecture1;
	//public static Event[] sports1;
	//public static Event[] art1;
	//public static Event[] health1;
	public static string location;
	public static Event followUp;
	public static Inventory currentShop;
	public static Dictionary<string, bool> cleared;
	public static Dictionary<string, Inventory> shops;
	public static Dictionary<string, string> scouting;
	public static List<int> bossLocations;
	public static bool defeatedP;
	public static bool defeatedC;
	public static bool defeatedG;
	public static bool tutorialPlayed;
	public static int storyIndex;
	public static bool frat;
	
	public static void Initialize () {
		//EventGetter.BeginGame();
		//tower1 = EventGetter.CreateTower();
		//dining1 = EventGetter.CreateDining();
		//research1 = EventGetter.CreateResearch();
	    //sports1 = EventGetter.CreateSports();
		//art1 = EventGetter.CreateArts();
		//health1 = EventGetter.CreateHealth();
		//lecture1 = EventGetter.CreateLecture();
		bossLocations = new List<int>();
		//EventGetter.PlaceBosses(tower1, dining1, research1, sports1, art1, health1, lecture1);
		//tower = new Queue<Event>(tower1);
		//dining = new Queue<Event>(dining1);
		//research = new Queue<Event>(research1);
		//sports = new Queue<Event>(sports1);
		//art = new Queue<Event>(art1);
		//health = new Queue<Event>(health1);
		//lecture = new Queue<Event>(lecture1);
		DungeonMapData.Initialize();
		followUp = null;
		Time.timeUnit = 0;
		storyIndex = 0;
		cleared = new Dictionary<string, bool>(); cleared.Add("tower", false); cleared.Add("dining", false); cleared.Add("research", false);
	    cleared.Add("sports", false); cleared.Add("art", false); cleared.Add("health", false); cleared.Add("lecture", false);
		scouting = new Dictionary<string, string>(); scouting.Add("tower", "No Info"); scouting.Add("dining", "No Info"); scouting.Add("research", "No Info");
	    scouting.Add("sports", "No Info"); scouting.Add("art", "No Info"); scouting.Add("health", "No Info"); scouting.Add("lecture", "No Info");
		shops = new Dictionary<string, Inventory>(); shops.Add("tower", new Inventory("tower")); shops.Add("dining", new Inventory("dining"));
		shops.Add("research", new Inventory("research")); shops.Add("sports", new Inventory("sports")); shops.Add("art", new Inventory("art"));
		shops.Add("health", new Inventory("health")); shops.Add("lecture", new Inventory("lecture"));
		shops[IndexToWord(bossLocations[0])].scoutMessage = "The trail of this areas boss leads back to " + IndexToWord(bossLocations[3]);
		shops[IndexToWord(bossLocations[0])].scoutArea = IndexToWord(bossLocations[3]);
		shops[IndexToWord(bossLocations[0])].scoutShorten = "Final Boss Here";
		shops[IndexToWord(bossLocations[1])].scoutMessage = "The trail of this areas boss leads back to " + IndexToWord(bossLocations[3]);
		shops[IndexToWord(bossLocations[1])].scoutArea = IndexToWord(bossLocations[3]);
		shops[IndexToWord(bossLocations[1])].scoutShorten = "Final Boss Here";
		shops[IndexToWord(bossLocations[2])].scoutMessage = "The trail of this areas boss leads back to " + IndexToWord(bossLocations[3]);
		shops[IndexToWord(bossLocations[2])].scoutArea = IndexToWord(bossLocations[3]);
		shops[IndexToWord(bossLocations[2])].scoutShorten = "Final Boss Here";
		shops[IndexToWord(bossLocations[3])].scoutMessage = "HACKER! YOU SHOULDN'T SEE THIS!";
		shops[IndexToWord(bossLocations[3])].scoutArea = IndexToWord(bossLocations[3]);
		shops[IndexToWord(bossLocations[3])].scoutShorten = "Final Boss Here";
		shops[IndexToWord(bossLocations[4])].scoutMessage = "It seems suspicious activity was seen in " + IndexToWord(bossLocations[0]);
		shops[IndexToWord(bossLocations[4])].scoutArea = IndexToWord(bossLocations[0]);
		shops[IndexToWord(bossLocations[4])].scoutShorten = "Dangerous Enemy Detected";
		shops[IndexToWord(bossLocations[5])].scoutMessage = "It seems suspicious activity was seen in " + IndexToWord(bossLocations[1]);
		shops[IndexToWord(bossLocations[5])].scoutArea = IndexToWord(bossLocations[1]);
		shops[IndexToWord(bossLocations[5])].scoutShorten = "Dangerous Enemy Detected";
		shops[IndexToWord(bossLocations[6])].scoutMessage = "It seems suspicious activity was seen in " + IndexToWord(bossLocations[2]);
		shops[IndexToWord(bossLocations[6])].scoutArea = IndexToWord(bossLocations[2]);
		shops[IndexToWord(bossLocations[6])].scoutShorten = "Dangerous Enemy Detected";
		defeatedP = false;
		defeatedC = false;
		defeatedG = false;
		Battle.inBattle = false;
		Dungeon.fled = false;
		tutorialPlayed = false;
		frat = true;
		location = Map.currentPosition;
		Score.Reset();
		Investigate.Initialize();
	}
	
	/**
	public static Event Next() {
		switch (location) {
			case "tower": 
			    if (tower.Count == 0) {
					cleared["tower"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return tower.Dequeue();
			    }
				break;
			case "dining": 
		    	if (dining.Count == 0) {
					cleared["dining"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return dining.Dequeue();
			    }
			    break;
			case "research": 
		    	if (research.Count == 0) {
					cleared["research"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return research.Dequeue();
			    }
			    break;
			case "sports": 
		    	if (sports.Count == 0) {
					cleared["sports"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return sports.Dequeue();
			    }
			    break;
            case "art": 
		    	if (art.Count == 0) {
					cleared["art"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return art.Dequeue();
			    }
			    break;
            case "health": 
		    	if (health.Count == 0) {
					cleared["health"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return health.Dequeue();
			    }
			    break;
            case "lecture": 
		    	if (lecture.Count == 0) {
					cleared["lecture"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return lecture.Dequeue();
			    }
			    break;				
		}
		return null;
	}
	*/
	
	public static void SetLocation(int i) {
		string loc = IndexToWord(i);
		//Debug.Log(loc);
		Map.selectedLocation = loc;
		Map.currentPosition = loc;
	}
	
	public static string IndexToWord(int i) {
		switch (i) {
			case 0: return "tower";
			case 1: return "dining";
			case 2: return "research";
			case 3: return "sports";
			case 4: return "art";
			case 5: return "health";
		    case 6: return "lecture";
			case 7: return "tutorial";
		}
        return "Wrong answer";		
	}

	public static string GetLocationFormatted(string loc) {
		loc = (loc == null) ? location : loc;
		switch(loc) {
			case "tower"	: return "Tower";
			case "dining"	: return "Dining Hall";
			case "research"	: return "Research Lab";
			case "sports"	: return "Stadium";
			case "art"		: return "Art Center";
			case "health"	: return "Health Building";
		    case "lecture"	: return "Lecture Halls";
			case "tutorial" : return "The Kitchen";
		}
		return "BAD";
	}
}