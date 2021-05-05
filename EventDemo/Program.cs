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
    public static void bl_ProcessCompleted(object sender, bool IsSuccessful)
    {
        Console.WriteLine("Process " + (IsSuccessful? "Completed Successfully": "failed"));
    }
}

public class ProcessBusinessLogic
{
    public event EventHandler<bool> ProcessCompleted; // event using .net built-in EventHandler with bool

    public void StartProcess()
    {
        Console.WriteLine("Process Registered with Event!");
        bool repeat = true;
        do {
	        Console.WriteLine("Should Process Fail? Y/N");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                repeat = false;
                OnProcessCompleted(false); // Bool Event Data
                break;

                case "N":
                repeat = false;
                OnProcessCompleted(true); // Bool Event Data
                break;
                
                default:
                Console.WriteLine("Invalid Response");
                break;
            }
        } while(repeat);
    }

    protected virtual void OnProcessCompleted(bool IsSuccessful)
    {
        ProcessCompleted?.Invoke(this, IsSuccessful); // Invoke Event
    }
}
