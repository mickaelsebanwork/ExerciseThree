using Exercise_3.FileReader;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise_3.FileReaderApp
{
    public static class DependencyInjection
    {
        public static ServiceProvider Build()
        {
            var collection = new ServiceCollection();
            collection.SetupApplication();
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}