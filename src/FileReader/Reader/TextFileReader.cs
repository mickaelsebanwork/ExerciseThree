using System.IO;

namespace Exercise_3.FileReader.Reader
{
    public class TextFileReader : ITextFileReader
    {
        public string Read(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}