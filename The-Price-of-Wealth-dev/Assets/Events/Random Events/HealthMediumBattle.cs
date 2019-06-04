using System.Collections.Generic;

public class HealthMediumBattle : BattleEvent {
	
	public HealthMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed == 0) {
			enemies = new Character[] {new Doctor(), new Researcher()};
			text = "Medical research";
		} else if (seed == 1) {
			enemies = new Character[] {new PreMed(), new PsychMajor()};
			text = "Rehab help";
		} else if (seed == 2) {
			enemies = new Character[] {new Criminal(), new Cop()};
			text = "Criminal and Cop";
		} else if (seed == 3) {
			enemies = new Character[] {new Cop(), new Doctor()};
			text = "Medical emergency";
		} else if (seed == 4) {
			enemies = new Character[] {new Representative(), new Doctor()};
			text = "Doctors approve";
		} else if (seed == 5) {
			enemies = new Character[] {new Researcher(), new Slime()};
			text = "Unethical research";
		} else if (seed == 6) {
			enemies = new Character[] {new Doctor(), new PreMed()};
			text = "Medical apprentice";
		} else if (seed == 7) {
			enemies = new Character[] {new PsychMajor(), new PizzaCultist()};
			text = "Mental therapy";
		} else if (seed == 8) {
			enemies = new Character[] {new ChemistryMajor(), new PreMed(), new MathMajor()};
			text = "Undergraduate R&D";
		} else {
			enemies = new Character[] {new Instructor(), new TeachingAssistant(), new PreMed()};
			text = "Class trip";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}