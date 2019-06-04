using System.Collections.Generic;

public class CommonsHardBattle : BattleEvent {
	
	public CommonsHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Janitor(), new Janitor(), new Janitor(), new Janitor()};
			text = "Coven of cleaner";
		} else if (seed < 4) {
			enemies = new Character[] {new TeachingAssistant(), new PsychMajor(), new PoliticalScientist(), new HistoryMajor()};
			text = "Help session";
		} else if (seed < 6) {
			enemies = new Character[] {new CulinaryMajor(), new DanceMajor(), new MechanicalEngineer(), new ShuttleDriver()};
			text = "Catch the bus";
		} else if (seed < 8) {
			enemies = new Character[] {new Chef(), new PizzaCultist(), new ChemistryMajor(), new MusicMajor()};
			text = "Devious trap";
		} else {
			enemies = new Character[] {new Administrator(), new Instructor(), new SecurityHologram()};
			text = "Forbidden room";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}