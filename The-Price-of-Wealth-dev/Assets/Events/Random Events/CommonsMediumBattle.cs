using System.Collections.Generic;

public class CommonsMediumBattle : BattleEvent {
	
	public CommonsMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed == 0) {
			enemies = new Character[] {new Administrator()};
			text = "Administrator";
		} else if (seed == 1) {
			enemies = new Character[] {new Representative(), new Chef()};
			text = "Edible marketing";
		} else if (seed == 2) {
			enemies = new Character[] {new Janitor(), new Chef()};
			text = "Clean restraunt";
		} else if (seed == 3) {
			enemies = new Character[] {new PoliticalScientist(), new PsychMajor()};
			text = "Promoting change";
		} else if (seed == 4) {
			enemies = new Character[] {new CJMajor(), new PizzaCultist()};
			text = "Vigilante work";
		} else if (seed == 5) {
			enemies = new Character[] {new PreMed(), new Representative()};
			text = "Flu shots";
		} else if (seed == 6) {
			enemies = new Character[] {new Janitor(), new PizzaCultist()};
			text = "After hours lurker";
		} else if (seed == 7) {
			enemies = new Character[] {new TeachingAssistant(), new TeachingAssistant()};
			text = "TA desk";
		} else if (seed == 8) {
			enemies = new Character[] {new MathMajor(), new ChemistryMajor(), new BusinessMajor()};
			text = "Study gathering";
		} else {
			enemies = new Character[] {new Chef(), new Slime(), new Slime()};
			text = "Unsanitary cooking";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}