using System.Collections.Generic;

public class CommonsEasyBattleR : BattleEvent {
	
	public CommonsEasyBattleR() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed  == 0) {
			enemies = new Character[] {new ChemistryMajor()};
			text = "Chemistry";
		} else if (seed == 1) {
			enemies = new Character[] {new MechanicalEngineer()};
			text = "Mechanical engineer";
		} else if (seed == 2) {
			enemies = new Character[] {new CSMajor()};
			text = "Computer science";
		} else if (seed == 3) {
			enemies = new Character[] {new PoliticalScientist()};
			text = "Pol-Sci";
		} else if (seed == 4) {
			enemies = new Character[] {new BusinessMajor()};
			text = "Business";
		} else if (seed == 5) {
			enemies = new Character[] {new DanceMajor()};
			text = "Dance";
		} else if (seed == 6) {
			enemies = new Character[] {new CJMajor()};
			text = "Criminal justice";
		} else if (seed == 7) {
			enemies = new Character[] {new HistoryMajor()};
			text = "History";
		} else if (seed == 8) {
			enemies = new Character[] {new CulinaryMajor()};
			text = "Culinary";
		} else {
			enemies = new Character[] {new PreMed()};
			text = "Pre-Med";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}