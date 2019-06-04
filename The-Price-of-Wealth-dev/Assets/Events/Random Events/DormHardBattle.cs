using System.Collections.Generic;

public class DormHardBattle : BattleEvent {
	
	public DormHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Criminal(), new PizzaCultist(), new Janitor(), new Criminal()};
			text = "Betrayed by a mole";
		} else if (seed < 4) {
			enemies = new Character[] {new MathMajor(), new MechanicalEngineer(), new AerospaceEngineer(), new CSMajor()};
			text = "Math study group";
		} else if (seed < 6) {
			enemies = new Character[] {new ChemistryMajor(), new CulinaryMajor(), new PsychMajor(), new BusinessMajor()};
			text = "Suspicious hobby";
		} else if (seed < 8) {
			enemies = new Character[] {new FootballPlayer(), new EnglishMajor(), new DanceMajor(), new PreMed()};
			text = "Polar opposites";
		} else {
			enemies = new Character[] {new HistoryMajor(), new CJMajor(), new MusicMajor(), new PoliticalScientist()};
			text = "Hall council";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}