using System.Collections.Generic;

public class HealthEasyBattleP : BattleEvent {
	
	public HealthEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 4) {
			enemies = new Character[] {new Doctor()};
			text = "Doctor";
		} else if (seed < 6) {
			enemies = new Character[] {new Researcher()};
			text = "Researcher";
		} else if (seed < 8) {
			enemies = new Character[] {new Instructor()};
			text = "Instructor";
		} else if (seed == 8) {
			enemies = new Character[] {new Slime()};
			text = "Slime";
		} else {
			enemies = new Character[] {new Criminal()};
			text = "Criminal";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}