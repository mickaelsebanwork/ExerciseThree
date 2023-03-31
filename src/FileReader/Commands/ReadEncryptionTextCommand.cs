using Exercise_3.FileReader.Encryption;
using Exercise_3.FileReader.Reader;

namespace Exercise_3.FileReader.Commands
{
    public class ReadEncryptionTextCommand : PrintCommand
    {
        public ReadEncryptionTextCommand(ITextFileReader fileReader, IReverseEncryption encryption)
            : base(fileReader, encryption)
        {
        }

        protected override ReadOperationType ReadOperationType => ReadOperationType.TextFile;
        protected override EncryptionType AccessOperationType => EncryptionType.ReverseEncryption;
        protected override UserRoleType RoleMinType => UserRoleType.RegularUser;
    }
}