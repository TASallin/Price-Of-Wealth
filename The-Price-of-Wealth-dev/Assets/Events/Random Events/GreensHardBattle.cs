using System.Collections.Generic;

public class GreensHardBattle : BattleEvent {
	
	public GreensHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new ShuttleDriver(), new Criminal(), new Criminal(), new Criminal()};
			text = "Bank robbery";
		} else if (seed < 4) {
			enemies = new Character[] {new Administrator(), new ShuttleDriver()};
			text = "Traveling  boss";
		} else if (seed < 6) {
			enemies = new Character[] {new FootballPlayer(), new MusicMajor(), new PsychMajor(), new MechanicalEngineer()};
			text = "Tailgate party";
		} else if (seed < 8) {
			enemies = new Character[] {new HistoryMajor(), new AerospaceEngineer(), new AerospaceEngineer(), new AerospaceEngineer()};
			text = "Air striker";
		} else {
			enemies = new Character[] {new Conductor(), new PizzaCultist(), new Criminal(), new MusicMajor()};
			text = "Rock concert";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}