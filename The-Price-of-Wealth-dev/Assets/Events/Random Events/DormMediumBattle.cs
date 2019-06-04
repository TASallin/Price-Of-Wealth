using System.Collections.Generic;

public class DormMediumBattle : BattleEvent {
	
	public DormMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Criminal(), new Criminal()};
			text = "Partners in crime";
		} else if (seed == 2) {
			enemies = new Character[] {new CSMajor(), new FootballPlayer()};
			text = "Excercise and sedentary";
		} else if (seed == 3) {
			enemies = new Character[] {new BusinessMajor(), new PsychMajor()};
			text = "Material and philosophical";
		} else if (seed == 4) {
			enemies = new Character[] {new MusicMajor(), new EnglishMajor()};
			text = "Audio and visual";
		} else if (seed == 5) {
			enemies = new Character[] {new MechanicalEngineer(), new MathMajor()};
			text = "Practice and theory";
		} else if (seed == 6) {
			enemies = new Character[] {new CJMajor(), new PreMed()};
			text = "Intense and chill";
		} else if (seed == 7) {
			enemies = new Character[] {new CulinaryMajor(), new PizzaCultist()};
			text = "Oblivious to corruption";
		} else if (seed == 8) {
			enemies = new Character[] {new Cop(), new Janitor()};
			text = "Basic staff";
		} else {
			enemies = new Character[] {new PoliticalScientist(), new HistoryMajor(), new AerospaceEngineer()};
			text = "Tri-mates";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}