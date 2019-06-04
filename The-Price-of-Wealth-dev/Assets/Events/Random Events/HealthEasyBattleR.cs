using System.Collections.Generic;

public class HealthEasyBattleR : BattleEvent {
	
	public HealthEasyBattleR() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 5) {
			enemies = new Character[] {new PreMed()};
			text = "Pre-Med";
		} else if (seed == 5) {
			enemies = new Character[] {new PsychMajor()};
			text = "Psychology";
		} else if (seed == 6) {
			enemies = new Character[] {new ChemistryMajor()};
			text = "Chemistry";
		} else if (seed == 7) {
			enemies = new Character[] {new CulinaryMajor()};
			text = "Culinary";
		} else if (seed == 8) {
			enemies = new Character[] {new MathMajor()};
			text = "Math";
		} else {
			enemies = new Character[] {new CJMajor()};
			text = "Criminal justice";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}