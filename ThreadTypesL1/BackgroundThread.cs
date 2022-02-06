namespace ThreadTypesL1
{
    public class BackgroundThread
    {
        static void ImageLoader()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(1200);
            }
        }
        // Invoking threads
        public static void Invoke()
        {
            var textRequest = new Thread(ImageLoader)
            {
                Name = "Background Thread",
                IsBackground = true
            };

            textRequest.Start();
        }
    }
}
