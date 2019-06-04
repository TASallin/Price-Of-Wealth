public class TimedMethod {
    
	//The number of frames this method will be called for before the next one is called. Ex: If you want text to display for 1 second, put 60
    public int delay;
	//The name of the method to be called
    public string method;
	//The inputs to the method. If it is no-args, put null
    public object[] args;

    public TimedMethod(int delay, string method, object[] args) {
        this.delay = delay; this.method = method; this.args = args;
    }	
	
	public TimedMethod(int delay, string method) {
		this.delay = delay; this.method = method; this.args = null;
	}
	
	public TimedMethod(string method) {
		this.delay = 0; this.method = method; this.args = null;
	}
}