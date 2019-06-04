using System.Collections.Generic;

public class DormEasyBattleP : BattleEvent {
	
	public DormEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 3) {
			enemies = new Character[] {new Criminal()};
			text = "Criminal";
		} else if (seed < 5) {
			enemies = new Character[] {new TeachingAssistant()};
			text = "TA";
		} else if (seed < 7) {
			enemies = new Character[] {new Janitor()};
			text = "Janitor";
		} else if (seed == 7) {
			enemies = new Character[] {new PizzaCultist()};
			text = "Cultist";
		} else if (seed == 8) {
			enemies = new Character[] {new Cop()};
			text = "Cop";
		} else {
			enemies = new Character[] {new ShuttleDriver()};
			text = "Shuttle driver";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}