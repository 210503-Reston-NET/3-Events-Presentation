
using System;
					
public class Program
{
	public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.EventCompleted += bl_EventCompleted; // register with an event


        int bottles = 5;

        Console.WriteLine("There are 5 bottles on the wall. Taking them down and passing around...");
        while(bottles >= 0)
		{
			Console.WriteLine(bottles);
			bottles--;
	    }

        if (bottles <= 0) 
        {
            Console.WriteLine("Oh no! There are no more bottles...");
            bl.Wait();
        }

        
		
		


    }

    // event handler
    public static void bl_EventCompleted(object sender, EventArgs e)
    {
        Console.WriteLine("Congratulations! You completed an event and replenished the bottles!");
    }
}


public delegate void Notify();  // delegate
                    
public class ProcessBusinessLogic
{
    public event EventHandler EventCompleted; // event

    public void Wait()
    {
        bool repeat = true;

        
		Console.WriteLine("Would you like to replenish the bottles on the wall?");

        do
		{
			Console.WriteLine("Respond: 'yes' or 'no'");
			string input = Console.ReadLine();
			switch (input)
			{
				case "yes":
                    repeat = false;
					break;
				case "no":
					Console.WriteLine("No bottles for you then...");
					Console.WriteLine("How about now?");
					break;
				default:
					Console.WriteLine("invalid response");
					break;
			}
		} while (repeat);
        
        
        OnEventCompleted(EventArgs.Empty);
    }


    protected virtual void OnEventCompleted(EventArgs e)
    {
        EventCompleted?.Invoke(this, e);
    }
}
