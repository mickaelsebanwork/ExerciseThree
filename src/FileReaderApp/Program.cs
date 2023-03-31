using Exercise_3.FileReader;

namespace Exercise_3.FileReaderApp
{
    public static class Program
    {
        private static void Main()
        {
            var serviceProvider = DependencyInjection.Build();
            var filePrinter = (IFilePrinter)serviceProvider.GetService(typeof(IFilePrinter));
            try
            {
                while (true)
                {
                    Menu.Run(filePrinter);
                }
            }
            finally
            {
                serviceProvider.Dispose();
            }
        }
    }
}