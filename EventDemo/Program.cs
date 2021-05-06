using System;
					
public class Program
{
	public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
        bl.AnotherEvent += bl_EventHandlerTwo;
        bl.DateEvent += bl_DateEventHandler;
        bl.StartProcess();
    }

    // Bool Event handler
    public static void bl_ProcessCompleted(object sender, bool IsSuccessful)
    {
        Console.WriteLine("Process " + (IsSuccessful? "Completed Successfully": "failed"));
    }

    // Another Event Handler
    public static void bl_EventHandlerTwo(object sender, EventArgs e) {
        Console.WriteLine("Another Event Processed");
    }

    // Date Event Handler
    public static void bl_DateEventHandler(object sender, DateEventArgs date) {
        Console.WriteLine("Completion Time: " + date.CompletionTime.ToLongDateString());
    }
}
public class DateEventArgs : EventArgs {
        public DateTime CompletionTime {get; set;}
    }
public class ProcessBusinessLogic
{
    public event EventHandler<bool> ProcessCompleted; // Created event using .net built-in EventHandler with bool

    public event EventHandler AnotherEvent; // Creates second event

    public event EventHandler<DateEventArgs> DateEvent; // Creates date event

    public void StartProcess()
    {
        Console.WriteLine("Process Registered with Event!");
        bool repeat = true;
        do {
	        Console.WriteLine("[1] Fail Process");
            Console.WriteLine("[2] Process Succeed");
            Console.WriteLine("[3] Raise new event");
            Console.WriteLine("[4] Pass Date Through Event");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                repeat = false;
                OnProcessCompleted(false); // Bool Event Data
                break;

                case "2":
                repeat = false;
                OnProcessCompleted(true); // Bool Event Data
                break;

                case "3":
                    repeat = false;
                    AnotherEventRaised(EventArgs.Empty);
                    break;

                case "4":
                    repeat = false;
                    var date = new DateEventArgs();
                    date.CompletionTime = DateTime.Now;
                    DateEventRaised(date);

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

    protected virtual void AnotherEventRaised(EventArgs e) {
        AnotherEvent?.Invoke(this, e);
    }

    protected virtual void DateEventRaised(DateEventArgs date) {
        DateEvent?.Invoke(this, date); 
    }
}
