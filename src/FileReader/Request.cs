namespace Exercise_3.FileReader
{
    public sealed class Request
    {
        public Request(string filePath, EncryptionType encryptionType, ReadOperationType readOperationType,
            UserRoleType userRoleType)
        {
            FilePath = filePath;
            EncryptionType = encryptionType;
            ReadOperationType = readOperationType;
            UserRoleType = userRoleType;
        }

        public string FilePath { get; }

        public EncryptionType EncryptionType { get; }

        public ReadOperationType ReadOperationType { get; }

        public UserRoleType UserRoleType { get; }
    }
}