using System;
using System.Collections.Generic;
using System.Linq;
using Exercise_3.FileReader.Commands;

namespace Exercise_3.FileReader
{
    public sealed class FilePrinter : IFilePrinter
    {
        private readonly IEnumerable<IPrintCommand> _printCommands;

        public FilePrinter(IEnumerable<IPrintCommand> printCommands)
        {
            _printCommands = printCommands;
        }

        public string Print(Request request)
        {
            var command = _printCommands.SingleOrDefault(printCommand => printCommand.CanHandle(request));
            if (command is null)
            {
                throw new InvalidOperationException();
            }

            if (!command.CanAccess(request))
            {
                throw new UnauthorizedAccessException();
            }

            return command.Handle(request);
        }
    }
}