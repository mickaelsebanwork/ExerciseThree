using Exercise_3.FileReader.Encryption;
using Exercise_3.FileReader.Reader;

namespace Exercise_3.FileReader.Commands
{
    public class ReadTextCommand : PrintCommand
    {
        public ReadTextCommand(ITextFileReader fileReader, INoEncryption encryption) : base(fileReader, encryption)
        {
        }

        protected override ReadOperationType ReadOperationType => ReadOperationType.TextFile;
        protected override EncryptionType AccessOperationType => EncryptionType.NoEncryption;
        protected override UserRoleType RoleMinType => UserRoleType.GuestUser;
    }
}