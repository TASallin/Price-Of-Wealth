using System.Collections.Generic;

public class LectureHardBattle : BattleEvent {
	
	public LectureHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new TeachingAssistant(), new TeachingAssistant(), new TeachingAssistant(), new TeachingAssistant()};
			text = "Grading team";
		} else if (seed < 4) {
			enemies = new Character[] {new Instructor(), new Researcher(), new TeachingAssistant(), new SecurityHologram()};
			text = "Secret meeting";
		} else if (seed < 6) {
			enemies = new Character[] {new MathMajor(), new EnglishMajor(), new ChemistryMajor(), new HistoryMajor()};
			text = "Main subjects";
		} else if (seed < 8) {
			enemies = new Character[] {new Instructor(), new CJMajor(), new PoliticalScientist(), new DanceMajor()};
			text = "Full lecture";
		} else {
			enemies = new Character[] {new TeachingAssistant(), new CSMajor(), new PreMed(), new MechanicalEngineer()};
			text = "Busy recitation";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}