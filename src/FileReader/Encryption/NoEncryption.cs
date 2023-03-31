namespace Exercise_3.FileReader.Encryption
{
    public class NoEncryption : INoEncryption
    {
        public string Encrypt(string value)
        {
            return value;
        }
    }
}