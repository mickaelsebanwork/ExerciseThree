using System.Collections.Generic;
using AutoFixture;
using Exercise_3.FileReader;
using Exercise_3.FileReader.Commands;
using Exercise_3.FileReader.Encryption;
using Exercise_3.FileReader.Reader;
using Moq;

namespace Exercise_3.Tests
{
    public sealed class FilePrinterFixture
    {
        public FilePrinterFixture()
        {
            var fixture = new Fixture();
            ExpectedText = fixture.Create<string>();
            FilePath = fixture.Create<string>();

            TextFileReader = new Mock<ITextFileReader>();
            TextFileReader.Setup(x => x.Read(FilePath))
                .Returns(ExpectedText);

            JsonFileReader = new Mock<IJsonFileReader>();
            JsonFileReader.Setup(x => x.Read(FilePath))
                .Returns(ExpectedText);

            XmlFileReader = new Mock<IXmlFileReader>();
            XmlFileReader.Setup(x => x.Read(FilePath))
                .Returns(ExpectedText);

            ReverseEncryption = new Mock<IReverseEncryption>();
            ReverseEncryption.Setup(x => x.Encrypt(ExpectedText)).Returns(ExpectedText);

            NoEncryption = new Mock<INoEncryption>();
            NoEncryption.Setup(x => x.Encrypt(ExpectedText)).Returns(ExpectedText);

            Sut = new FilePrinter(new List<PrintCommand>
            {
                new ReadEncryptionJsonCommand(JsonFileReader.Object, ReverseEncryption.Object),
                new ReadEncryptionTextCommand(TextFileReader.Object, ReverseEncryption.Object),
                new ReadEncryptionXmlCommand(XmlFileReader.Object, ReverseEncryption.Object),
                new ReadJsonCommand(JsonFileReader.Object, NoEncryption.Object),
                new ReadTextCommand(TextFileReader.Object, NoEncryption.Object),
                new ReadXmlCommand(XmlFileReader.Object, NoEncryption.Object)
            });
        }

        public Mock<IXmlFileReader> XmlFileReader { get; }
        public Mock<IJsonFileReader> JsonFileReader { get; }

        public string ExpectedText { get; }
        public string FilePath { get; }
        public Mock<INoEncryption> NoEncryption { get; }
        public Mock<IReverseEncryption> ReverseEncryption { get; }
        public FilePrinter Sut { get; }
        public Mock<ITextFileReader> TextFileReader { get; }
    }
}