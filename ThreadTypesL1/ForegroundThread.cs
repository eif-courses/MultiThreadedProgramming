namespace ThreadTypesL1
{
    public class ForegroundThread
    {
  
        static void TextLoader()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}, enter text: ");
                string? data = Console.ReadLine();
                Console.WriteLine($"Thank you for response! you message: {data}");

            }
        }

        // Invoking threads
        public static void Invoke()
        {

            var textRequest = new Thread(TextLoader)
            {
                Name = "Foreground Thread"
            };
            
            textRequest.Start();
        }
    }
}
