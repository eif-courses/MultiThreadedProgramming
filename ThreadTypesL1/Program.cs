// See https://aka.ms/new-console-template for more information

using ThreadTypesL1;

// Two types of Threads 
// Foreground by default 
// Background threads you can set using property isBackground = true
// Background exits when main thread finish they task

Thread.CurrentThread.Name = "Main thread";

// You must run application multiple times to see difference
// because is hard to make infinity loop menu for it :)


Console.WriteLine("1. Foreground Thread.");
Console.WriteLine("2. Background Thread.");
Console.WriteLine("3. WithoutThreads (Multiple Tasks).");
Console.WriteLine("4. UsingThreads (Multiple Tasks).");
Console.WriteLine("0. Exit Application.");
Console.WriteLine("Enter option:");

int option = Convert.ToInt32(Console.ReadLine());

switch (option)
{
    case 1:
        // Wait until all threads finish they jobs
        // We use Console.Readline() for text thread;
        ForegroundThread.Invoke();
        break;
    case 2:
        // Alive until Main Thread exits
        BackgroundThread.Invoke();
        break;
    case 3:
        MultipleTasksWithoutThread.Invoke();
        break;
    case 4:
        MultipleTasksUsingThreads.Invoke();
        break;
    default:
        Console.WriteLine("Option not exists!");
        break;
}
Console.WriteLine($"{Thread.CurrentThread.Name}: Hello, World!");