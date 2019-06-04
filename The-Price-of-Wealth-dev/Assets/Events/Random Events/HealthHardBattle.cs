using System.Collections.Generic;

public class HealthHardBattle : BattleEvent {
	
	public HealthHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new BusinessMajor(), new FootballPlayer(), new ChemistryMajor(), new DanceMajor()};
			text = "Hospital patients";
		} else if (seed < 4) {
			enemies = new Character[] {new PreMed(), new EnglishMajor(), new Janitor(), new Doctor()};
			text = "Medical drama";
		} else if (seed < 6) {
			enemies = new Character[] {new Doctor(), new Doctor(), new Doctor(), new Doctor()};
			text = "Quad-doctor";
		} else if (seed < 8) {
			enemies = new Character[] {new PreMed(), new Doctor(), new Researcher(), new ChemistryMajor()};
			text = "Medical lab";
		} else {
			enemies = new Character[] {new PizzaCultist(), new Criminal(), new Slime(), new Doctor()};
			text = "Burglary for the cult";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}