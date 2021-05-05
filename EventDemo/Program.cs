using System;
					
public class Program
{
	public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
        bl.ProcessCompleted += bl_EventHandlerTwo;
        bl.StartProcess();
    }

    // event handler
    public static void bl_ProcessCompleted(EventData e)
    {      
        Console.WriteLine("I'm an event handler!");
        Console.WriteLine($"You wrote {e.input}");
        Console.WriteLine("Process Completed!");
    }
    public static void bl_EventHandlerTwo(EventData e)
    {
        Console.WriteLine("I'm another event handler!");
    } 
}

public delegate void Notify(EventData e);  // delegate
                    

public class EventData : EventArgs 
{
    public string input;

}
public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; // event

    public void StartProcess()
    {
        EventData e = new EventData();

        Console.WriteLine("Process Started!");
		Console.WriteLine("Write something");
        e.input = Console.ReadLine();

        OnProcessCompleted(e);
    }


    protected virtual void OnProcessCompleted(EventData e)
    {
        ProcessCompleted?.Invoke(e);
    }
}
