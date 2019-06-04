using System.Collections.Generic;

public class LectureMediumBattle : BattleEvent {
	
	public LectureMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Instructor(), new TeachingAssistant()};
			text = "Head TA";
		} else if (seed < 4) {
			enemies = new Character[] {new Instructor(), new Researcher()};
			text = "Faculty";
		} else if (seed == 4) {
			enemies = new Character[] {new CSMajor(), new CSMajor()};
			text = "2 CS";
		} else if (seed == 5) {
			enemies = new Character[] {new MathMajor(), new AerospaceEngineer()};
			text = "Rocket science";
		} else if (seed == 6) {
			enemies = new Character[] {new TeachingAssistant(), new HistoryMajor()};
			text = "Sparce recitation";
		} else if (seed == 7) {
			enemies = new Character[] {new Instructor(), new Instructor()};
			text = "Double lecturers";
		} else if (seed == 8) {
			enemies = new Character[] {new ChemistryMajor(), new MathMajor(), new PsychMajor()};
			text = "Science students";
		} else {
			enemies = new Character[] {new CulinaryMajor(), new MusicMajor(), new EnglishMajor()};
			text = "Humanities students";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}