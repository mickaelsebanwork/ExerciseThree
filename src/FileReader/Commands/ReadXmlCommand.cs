using Exercise_3.FileReader.Encryption;
using Exercise_3.FileReader.Reader;

namespace Exercise_3.FileReader.Commands
{
    public class ReadXmlCommand : PrintCommand
    {
        public ReadXmlCommand(IXmlFileReader fileReader, INoEncryption encryption)
            : base(fileReader, encryption)
        {
        }

        protected override ReadOperationType ReadOperationType => ReadOperationType.XmlFile;
        protected override EncryptionType AccessOperationType => EncryptionType.NoEncryption;
        protected override UserRoleType RoleMinType => UserRoleType.RegularUser;
    }
}