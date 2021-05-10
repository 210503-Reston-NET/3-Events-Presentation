
using System;
					
public class Program
{
	public static void Main()
    {
        EventDemonstration ed = new EventDemonstration();
        ed.EventCompleted += ed_EventCompleted; // register the event with an event handler


        int bottles = 5;

        Console.WriteLine("There are 5 bottles on the wall. Taking them down and passing around...");
        while(bottles > 0)
		{
			Console.WriteLine(--bottles + " bottles left on the wall...");
	    }

        if (bottles <= 0) 
        {
            Console.WriteLine("Oh no! There are no more bottles...");
            ed.Wait();
            bottles = 5;
            Console.WriteLine(bottles + " bottles left on the wall");

        }

    }

    // event handler
    public static void ed_EventCompleted(object sender, EventArgs e)
    {
        
        Console.WriteLine("Congratulations! You completed an event and replenished the bottles on the wall!");

    }
}


public delegate void Notify();  // delegate
                    
public class EventDemonstration
{
    public event EventHandler EventCompleted; // event

    public void Wait()
    {
        bool repeat = true;

        
		Console.WriteLine("Would you like to go to the store and buy some more?");

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
					Console.WriteLine("No more bottles for you then...");
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

