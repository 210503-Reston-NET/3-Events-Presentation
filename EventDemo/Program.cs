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
    public static void bl_ProcessCompleted()
    {
        Console.WriteLine("Process Completed!");
    }
}

public delegate void Notify();  // delegate
                    
public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; // event

    public void StartProcess()
    {
        Console.WriteLine("Process Started!");
        
        
        // add new code here
		Console.WriteLine("Press any key to continue");
        string input = Console.ReadLine();
        
        
        OnProcessCompleted();
    }


    protected virtual void OnProcessCompleted()
    {
        ProcessCompleted?.Invoke();
    }
}
