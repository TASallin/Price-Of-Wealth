using System.Collections.Generic;

public class GreensEasyBattleP : BattleEvent {
	
	public GreensEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new ShuttleDriver()};
			text = "Shuttle driver";
		} else if (seed < 4) {
			enemies = new Character[] {new Cop()};
			text = "Cop";
		} else if (seed < 6) {
			enemies = new Character[] {new Representative()};
			text = "Representative";
		} else if (seed == 6) {
			enemies = new Character[] {new Criminal()};
			text = "Criminal";
		} else if (seed == 7) {
			enemies = new Character[] {new Researcher()};
			text = "Researcher";
		} else if (seed == 8) {
			enemies = new Character[] {new TeachingAssistant()};
			text = "TA";
		} else {
			enemies = new Character[] {new Coach()};
			text = "Coach";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}