namespace ThreadTypesL1
{
    public class MultipleTasksWithoutThread
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
            DownloadImage();
            SendMessage();
        }

    }
}