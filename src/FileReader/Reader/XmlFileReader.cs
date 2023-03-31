using System.IO;
using System.Text;
using System.Xml;

namespace Exercise_3.FileReader.Reader
{
    public class XmlFileReader : IXmlFileReader
    {
        public string Read(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var mStream = new MemoryStream();
                var writer = new XmlTextWriter(mStream, Encoding.Unicode);
                var document = new XmlDocument();

                document.Load(fileStream);

                writer.Formatting = Formatting.Indented;

                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                mStream.Position = 0;

                var sReader = new StreamReader(mStream);

                var formattedXml = sReader.ReadToEnd();
                return formattedXml;
            }
        }
    }
}