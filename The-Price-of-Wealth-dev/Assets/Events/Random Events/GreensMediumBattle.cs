using System.Collections.Generic;

public class GreensMediumBattle : BattleEvent {
	
	public GreensMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Administrator()};
			text = "Administrator";
		} else if (seed < 4) {
			enemies = new Character[] {new AerospaceEngineer(), new AerospaceEngineer()};
			text = "2 AEs";
		} else if (seed == 4) {
			enemies = new Character[] {new MusicMajor(), new BusinessMajor()};
			text = "Buskers";
		} else if (seed == 5) {
			enemies = new Character[] {new Criminal(), new ShuttleDriver()};
			text = "Getaway driver";
		} else if (seed == 6) {
			enemies = new Character[] {new ShuttleDriver(), new ShuttleDriver()};
			text = "Rotating drivers";
		} else if (seed == 7) {
			enemies = new Character[] {new ShuttleDriver(), new AerospaceEngineer()};
			text = "Wheels and rockets";
		} else if (seed == 8) {
			enemies = new Character[] {new Cop(), new CJMajor(), new Criminal()};
			text = "Chase scene";
		} else {
			enemies = new Character[] {new Coach(), new CulinaryMajor(), new FootballPlayer()};
			text = "Sports cookout";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}