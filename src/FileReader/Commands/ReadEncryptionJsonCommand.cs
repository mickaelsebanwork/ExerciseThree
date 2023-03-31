using Exercise_3.FileReader.Encryption;
using Exercise_3.FileReader.Reader;

namespace Exercise_3.FileReader.Commands
{
    public class ReadEncryptionJsonCommand : PrintCommand
    {
        public ReadEncryptionJsonCommand(IJsonFileReader fileReader, IReverseEncryption encryption)
            : base(fileReader, encryption)
        {
        }

        protected override ReadOperationType ReadOperationType => ReadOperationType.JsonFile;
        protected override EncryptionType AccessOperationType => EncryptionType.ReverseEncryption;
        protected override UserRoleType RoleMinType => UserRoleType.Admin;
    }
}