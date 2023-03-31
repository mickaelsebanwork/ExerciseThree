namespace Exercise_3.FileReader.Commands
{
    public interface IPrintCommand
    {
        bool CanAccess(Request request);
        bool CanHandle(Request request);
        string Handle(Request request);
    }
}