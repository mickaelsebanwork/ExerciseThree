using System.IO;

namespace Exercise_3.FileReader.Reader
{
    public class JsonFileReader : IJsonFileReader
    {
        public string Read(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}