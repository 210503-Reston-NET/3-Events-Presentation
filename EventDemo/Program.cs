using System;
					
public class Program
{
	public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.Event += bl_EmptyEventHandler; // Register Empty Event
        bl.BoolEvent += bl_BoolEventHandler; // Register bool event
        bl.ThresholdEvent += bl_DateEventHandler; // Register Date Event
        bl.StartProcess();
    }

    // Bool Event handler
    public static void bl_BoolEventHandler(object sender, bool IsSuccessful)
    {
        Console.WriteLine("Process " + (IsSuccessful? "Completed Successfully": "failed"));
    }

    // Another Event Handler
    public static void bl_EmptyEventHandler(object sender, EventArgs e) {
        Console.WriteLine("Empty Event Processed");
    }

    // Threshold Event Handler
    public static void bl_DateEventHandler(object sender, ThresholdEventArgs date) {
        Console.WriteLine("Threshold: " + date.Threshold);
        Console.WriteLine("Completion Time: " + date.CompletionTime.ToLongDateString());
    }
}

// Custom EventArgs
public class ThresholdEventArgs : EventArgs {
        public DateTime CompletionTime {get; set;}
        public int Threshold {get; set;}
    }
public class ProcessBusinessLogic
{

    public event EventHandler Event; // Creates empty event using .Net built-in EventHandler
    public event EventHandler<bool> BoolEvent; // Created event with bool

    public event EventHandler<ThresholdEventArgs> ThresholdEvent; // Creates threshold event

    public void StartProcess()
    {
        Console.WriteLine("Process Registered with Events!");
        bool repeat = true;
        do {
            Console.WriteLine("[1] Raise Empty Event");
	        Console.WriteLine("[2] Pass");
            Console.WriteLine("[3] Fail");
            Console.WriteLine("[4] Threshold Event");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    repeat = false;
                    EmptyEventRaised(EventArgs.Empty); // Empty Event Data
                    break;

                case "2":
                    repeat = false;
                    BoolEventRaised(true); // Bool Event Data
                    break;

                case "3":
                    repeat = false;
                    BoolEventRaised(false); // Bool Event Data
                    break;

                case "4":
                    repeat = false;
                    var data = new ThresholdEventArgs();
                    data.CompletionTime = DateTime.Now;
                    for (int i = 0; i < 5; i++)
                    {
                        data.Threshold = i;
                    }
                    ThresholdEventRaised(data); // Date Event Data

                    break;

                
                default:
                Console.WriteLine("Invalid Response");
                break;
            }
        } while(repeat);
    }

    protected virtual void BoolEventRaised(bool IsSuccessful)
    {
        BoolEvent?.Invoke(this, IsSuccessful); // Invoke bool Event
    }

    protected virtual void EmptyEventRaised(EventArgs e) {
        Event?.Invoke(this, e); // Invoke Another Event
    }

    protected virtual void ThresholdEventRaised(ThresholdEventArgs date) {
        ThresholdEvent?.Invoke(this, date); // Invoke Date Event
    }
}