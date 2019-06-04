public class Robber : Character {
	
	int cycle;
	bool briefcase;
	
	public Robber() {
	    health = 50; maxHP = 50; strength = 5; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 13; accuracy = 13; dexterity = 5; evasion = 0; type = "Robber"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = true; recruitable = false;
        CreateDrops(); cycle = 0; briefcase = false;
    }
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (cycle == 0) {
			cycle++;
			if (num < 7) {
				return Rob ();
			} else {
				return MindGames();
			}
		} else {
			return Retreat();
		}
	}
	
	public TimedMethod[] Rob () {
		if (briefcase) {
			briefcase = false;
			return DestroyBriefcase();
		}
		TimedMethod[] stealPart;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			stealPart = Party.StealItem();
			if (Party.BagContains(new Briefcase())) {
				briefcase = true;
			}
		} else {
			stealPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " mugged you"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 8, GetAccuracy(), true, true, false}), stealPart[0]};
	}
	
	public TimedMethod[] Retreat () {
		if (GetGooped()) {
			System.Random rng = new System.Random();
			if (rng.Next(10) < 7) {
				return Attack();
			} else {
				return Escape();
			}
		}
		cycle = 0;
		if (Party.enemyCount < 2) {
			return Attack();
		}
		Party.enemySlot = 2;
		return new TimedMethod[] {new TimedMethod(0, "EnemySwitch", new object[] {1, 2}),
	    	new TimedMethod(60, "Log", new object[] {ToString() + " vanished from sight"})};
	}
	
	public TimedMethod[] Ambush () {
		Party.enemySlot = 1;
		if (Party.playerCount > 1) {
    		int steps = new System.Random().Next(Party.playerCount - 1);
	    	for (int i = 0; i < 4; i++) {
		    	if (Party.members[i] != null && Party.members[i].GetAlive() && i != Party.playerSlot - 1) {
			    	if (steps == 0) {
				   	return new TimedMethod[] {new TimedMethod(0, "SwitchTo", new object[] {i + 1}), new TimedMethod(0, "EnemySwitch", new object[] {1,2}),
   							new TimedMethod(60, "Log", new object[] {ToString() + " ambushed " + Party.GetPlayer().ToString()}),
						    new TimedMethod(60, "StagnantAttack", new object[] {false, 8, 13, GetAccuracy(), true, true, false})};
    				} else {
	    				steps--;
		    		}
		    	}
    		}
     	}
		return new TimedMethod[] {new TimedMethod(0, "EnemySwitch", new object[] {2}),
			new TimedMethod(60, "Log", new object[] {ToString() + " \"ambushed\" " + Party.GetPlayer().ToString()}),
			new TimedMethod(60, "StagnantAttack", new object[] {false, 4, 6, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] MindGames () {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			Party.GetPlayer().GainCharge(-3);
			Party.GetPlayer().status.Stun(2);
			GainEvasion(5);
			GainGuard(3);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " gave a sinister threat"})};
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " gave a sinister threat...but it was futile"})};
		}
	}
	
	public TimedMethod[] Attack () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked angrily"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 7, 12, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Escape () {
		status.gooped = false;
		GainEvasion(6);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " escaped the goop"})};
	}
	
	public TimedMethod[] DestroyBriefcase() {
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			for (int i = 0; i < 10; i++) {
				Item current = Party.GetItem(i);
			    if (current != null && current.GetType().Equals(new Briefcase().GetType())) {
				    Party.GetItems()[i] = null;
					break;
			    }
			}
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " smashed the briefcase"}),
		        new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		        new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 5, GetAccuracy(), true, true, false})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " went for the briefcase"}),
		        new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		        new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 5, GetAccuracy(), true, true, false})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Pizza(), new ProteinBar(), new Milk(), new Coffee(), new Textbook(), new Whistle(),
		    new Automatic(), new Tazer(), new Donut(), new Briefcase(), new Metronome(), new Tuba(), new USB(), new Antibiotics(),
	    	new MysteryGoo(), new MysterySolution(), new ToxicSolution()}, ItemDrops.Amount(2, 4));
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 6 + rng.Next(4);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Robber - A veteran criminal who makes use of stealth",
		    "This one won't try to run. He has decided we have seen too much"};
	}
}