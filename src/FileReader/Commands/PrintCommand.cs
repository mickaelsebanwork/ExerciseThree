using System;
using Exercise_3.FileReader.Encryption;
using Exercise_3.FileReader.Reader;

namespace Exercise_3.FileReader.Commands
{
    public abstract class PrintCommand : IPrintCommand
    {
        private readonly IEncryption _encryption;
        private readonly IFileReader _fileReader;

        protected PrintCommand(IFileReader fileReader, IEncryption encryption)
        {
            _fileReader = fileReader;
            _encryption = encryption;
        }

        protected abstract ReadOperationType ReadOperationType { get; }
        protected abstract EncryptionType AccessOperationType { get; }
        protected abstract UserRoleType RoleMinType { get; }

        public bool CanAccess(Request request)
        {
            return request.UserRoleType >= RoleMinType;
        }

        public bool CanHandle(Request request)
        {
            return request.ReadOperationType == ReadOperationType && request.EncryptionType == AccessOperationType;
        }

        public string Handle(Request request)
        {
            if (!CanAccess(request) || !CanHandle(request))
            {
                throw new InvalidOperationException();
            }

            return _encryption.Encrypt(_fileReader.Read(request.FilePath));
        }
    }
}