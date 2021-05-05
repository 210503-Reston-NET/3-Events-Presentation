using System;
					
public class Program
{
	public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
        bl.StartProcess();
    }

    // event handler
    public static void bl_ProcessCompleted(object sender, EventArgs e)
    {
        Console.WriteLine("Process Completed!");
    }
}

public class ProcessBusinessLogic
{
    public event EventHandler ProcessCompleted; // event

    public void StartProcess()
    {
        Console.WriteLine("Process Started!");
	    Console.WriteLine("Press any key to continue");
        Console.ReadLine();

        OnProcessCompleted(EventArgs.Empty); // No Event data
    }


    protected virtual void OnProcessCompleted(EventArgs e)
    {
        ProcessCompleted?.Invoke(this, e); // Invoke Event
    }
}
