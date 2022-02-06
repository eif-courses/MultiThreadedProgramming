namespace ThreadTypesL1
{
    public class MultipleTasksUsingThreads
    {
        static void DownloadImage()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}, downloading image... ");
            Thread.Sleep(3000);
        }
        static void SendMessage()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}, sending image... ");
        }
        // Invoking Methods on Main Thread
        public static void Invoke()
        {
            var imageThread = new Thread(DownloadImage)
            {
                Name = "ImageDownloader Thread"
            };
            var messageThread = new Thread(SendMessage)
            {
                Name = "MessageSender Thread"
            };
            imageThread.Start();
            messageThread.Start();
        }
    }
}
