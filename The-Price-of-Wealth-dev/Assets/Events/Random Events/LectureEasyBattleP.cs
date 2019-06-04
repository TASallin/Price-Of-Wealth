using System.Collections.Generic;

public class LectureEasyBattleP : BattleEvent {
	
	public LectureEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 4) {
			enemies = new Character[] {new Instructor()};
			text = "Instructor";
		} else if (seed < 8) {
			enemies = new Character[] {new TeachingAssistant()};
			text = "TA";
		} else {
			enemies = new Character[] {new Researcher()};
			text = "Researcher";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}