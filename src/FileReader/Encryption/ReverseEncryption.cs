using System.Linq;

namespace Exercise_3.FileReader.Encryption
{
    public class ReverseEncryption : IReverseEncryption
    {
        public string Encrypt(string value)
        {
            return new string(value.Reverse().ToArray());
        }
    }
}