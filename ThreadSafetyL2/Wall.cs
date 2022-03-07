namespace ThreadSafety;

// Build a wall with multi threaded solution (Concurrently)
public static class Wall
{
    private static readonly object Locker = new();
    private static readonly List<string>? Blocks = default;
    private static int _xPos;
    private static int _yPos;
    
    private static void AddBlockWithoutThread(string name)
    {
            Blocks?.Add(name);
            Console.WriteLine($"Block added by {name} at posX {_xPos} : {_yPos}");
            // Critical section
            _xPos += 10;
            _yPos += 1;
        
    }
    // ==================== USING LOCK ===========================
    private static void AddBlockUsingLock(string name)
    {
        lock (Locker)
        {
            Blocks?.Add(name);
            Console.WriteLine($"Block added by {name} at posX {_xPos} : {_yPos}");
            // Critical section
            _xPos += 10;
            _yPos += 1;
        }
    }
    // ==================== USING MONITOR ===========================
    // Extra method!!! Monitor.Enter(Object, Boolean) method overload
    // Same as lock keyword but you can use Exception handling
    // and finally with ensure monitor is released 
    private static void AddBlockUsingMonitor(string name)
    {
        // When selecting an object on which to synchronize,
        // you should lock only on private or internal objects.
        // Locking on external objects might result in deadlocks,
        // because unrelated code could choose the same objects to lock
        // on for different purposes.
        try
        {
            Monitor.Enter(Locker);
            Blocks?.Add(name);
            Console.WriteLine($"Block added by {name} at posX {_xPos} : {_yPos}");
            // Critical section
            _xPos += 10;
            _yPos += 1;
            throw new AggregateException("PROBLEM HERE");
        }
        catch (AggregateException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Monitor.Exit(Locker);
        }       

       
    }
    public static void BuildWallWithoutLock()
    {
        // Why Sleep is not best approach for synchronization???
        // Because Lock is better :)
        for (var i = 0; i < 10; i++)
        {
            var i1 = i;
            new Thread(() => AddBlockWithoutThread($"Thread {i1}, adding block...")).Start();
        }
    }
    public static void BuildWallWithLock()
    {
        // Why Sleep is not best approach for synchronization???
        // Because Lock is better :)
        for (var i = 0; i < 10; i++)
        {
            var i1 = i;
            new Thread(() => AddBlockUsingLock($"Thread {i1}, adding block...")).Start();
        }
    }
    public static void BuildWallWithMonitor()
    {
        for (var i = 0; i < 10; i++)
        {
            var i1 = i;
            new Thread(() => AddBlockUsingMonitor($"Thread {i1}, adding block...")).Start();
        }
        
    }
}