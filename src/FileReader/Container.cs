using Exercise_3.FileReader.Commands;
using Exercise_3.FileReader.Encryption;
using Exercise_3.FileReader.Reader;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise_3.FileReader
{
    public static class Container
    {
        public static IServiceCollection SetupApplication(this IServiceCollection services)
        {
            return services
                .AddSingleton<IFilePrinter, FilePrinter>()
                .AddSingleton<IPrintCommand, ReadEncryptionJsonCommand>()
                .AddSingleton<IPrintCommand, ReadEncryptionTextCommand>()
                .AddSingleton<IPrintCommand, ReadEncryptionXmlCommand>()
                .AddSingleton<IPrintCommand, ReadJsonCommand>()
                .AddSingleton<IPrintCommand, ReadTextCommand>()
                .AddSingleton<IPrintCommand, ReadXmlCommand>()
                .AddSingleton<INoEncryption, NoEncryption>()
                .AddSingleton<IReverseEncryption, ReverseEncryption>()
                .AddSingleton<ITextFileReader, TextFileReader>()
                .AddSingleton<IXmlFileReader, XmlFileReader>()
                .AddSingleton<IJsonFileReader, JsonFileReader>();
        }
    }
}