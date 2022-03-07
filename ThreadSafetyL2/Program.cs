// See https://aka.ms/new-console-template for more information

namespace ThreadSafety;

public static class Program
{
    private static async Task Main()
    {
        Console.WriteLine("======================WITHOUT==============================");
        //Wall.BuildWallWithoutLock();

        Console.WriteLine("=======================LOCK=============================");
        //Wall.BuildWallWithLock();
        await ExampleFromDocsWithLock();
        
        // TODO Make more examples and give more Info about those methods
        
        // Pulse(Object) - Notifies a thread in the waiting queue of a change in the locked object's state.
        // PulseAll(Object)	- Notifies all waiting threads of a change in the object's state.
        
        // 1. Monitor Wait
        // 2. More methods Pulse and PulseAll => in Java Notify, NotifyAll
        
        
        Console.WriteLine("======================MONITOR==============================");
       // Wall.BuildWallWithMonitor();
    }
    
    // Thred Docs : https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-6.0
    
    // EXAMPLE FROM DOCS: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock
    private static async Task ExampleFromDocsWithLock()
    {
        // C# DOCS EXAMPLE WITH MONEY UPDATE
        var account = new Account(1000);
        var tasks = new Task[100];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() => Update(account));
        }
        await Task.WhenAll(tasks);
        Console.WriteLine($"Account's balance is {account.GetBalance()}");
        
        // Output:
        // Account's balance is 2000
    }

    private static void Update(Account account)
    {
        decimal[] amounts = {0, 2, -3, 6, -2, -1, 8, -5, 11, -6};
        foreach (var amount in amounts)
        {
            if (amount >= 0)
            {
                account.Credit(amount);
            }
            else
            {
                account.Debit(Math.Abs(amount));
            }
        }
    }
}