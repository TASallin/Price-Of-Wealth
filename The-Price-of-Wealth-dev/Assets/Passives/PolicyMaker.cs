public class PolicyMaker : Passive {
	
	public PolicyMaker (Character c) {self = c; name = "PolicyMaker"; description = "Sets a policy for the round if not in the lead";}
	
	public override TimedMethod[] Check(bool player) {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		string message;
		if (num == 0) {
			foreach(Character c in Party.members) {
				if (c != null && c.GetAlive()) {
	    			Status.NullifyDefense(c);
		    		c.GainCharge(3);
				}
		 	}
			foreach(Character c in Party.enemies) {
				if (c != null && c.GetAlive()) {
			    	Status.NullifyDefense(c);
			    	c.GainCharge(3);
		    	}
			}
			message = self.ToString() + " mandated a policy of aggression";
		} else if (num == 1) {
			foreach(Character c in Party.members) {
				if (c != null && c.GetAlive()) {
	    			Status.NullifyAttack(c);
		    		c.GainGuard(3);
				}
		 	}
			foreach(Character c in Party.enemies) {
				if (c != null && c.GetAlive()) {
			    	Status.NullifyAttack(c);
			    	c.GainGuard(3);
		    	}
			}
			message = self.ToString() + " mandated a policy of safety";
		} else if (num == 2) {
			foreach(Character c in Party.enemies) {
				if (c != null && c.GetAlive()) {
			        c.GainPower(1);
			    	c.GainDefense(1);
		    	}
			}
			message = self.ToString() + " mandated a corrupt policy to benefit their supporters";
		} else {
			foreach(Character c in Party.enemies) {
				if (c != null && c.GetAlive() && c != self) {
			        c.SetHealth(System.Math.Max(1, c.GetHealth() - 5));
		    	}
			}
			self.Heal((Party.enemyCount - 1) * 2);
			message = self.ToString() + " mandated a policy of sacrifice to your president";
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message})};
	}
}