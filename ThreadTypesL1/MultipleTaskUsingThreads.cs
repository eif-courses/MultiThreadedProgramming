namespace ThreadTypesL1
{
    public class MultipleTasksUsingThreads
    {
        static void DownloadImage()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}, downloading image... ");
            Thread.Sleep(3000); // Download complete
            SendMessage();
        }
        static void SendMessage()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}, sending image... ");
        }
        
        static void Calculating()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}, calculating a+b... ");
        }
        
        
        // Invoking Methods on Main Thread
        public static void Invoke()
        {
            var imageThread = new Thread(DownloadImage)
            {
                Name = "ImageDownloader Thread"
            };
            var calculation = new Thread(Calculating)
            {
                Name = "Calculation Thread"
            };
            
            imageThread.Start();
            calculation.Start();
        }
    }
}
