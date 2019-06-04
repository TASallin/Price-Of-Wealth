using System.Collections.Generic;

public class CommonsEasyBattleP : BattleEvent {
	
	public CommonsEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Representative()};
			text = "Representative";
		} else if (seed < 4) {
			enemies = new Character[] {new TeachingAssistant()};
			text = "TA";
		} else if (seed < 6) {
			enemies = new Character[] {new Janitor()};
			text = "Janitor";
		} else if (seed < 8) {
			enemies = new Character[] {new Chef()};
			text = "Chef";
		} else if (seed == 8) {
			enemies = new Character[] {new PizzaCultist()};
			text = "Cultist";
		} else {
			enemies = new Character[] {new ShuttleDriver()};
			text = "Shuttle driver";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}