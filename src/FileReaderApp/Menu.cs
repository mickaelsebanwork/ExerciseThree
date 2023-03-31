using System;
using System.Linq;
using Exercise_3.FileReader;

namespace Exercise_3.FileReaderApp
{
    public static class Menu
    {
        public static void Run(IFilePrinter filesService)
        {
            Console.Clear();
            Console.WriteLine(" ######################################## ");
            Console.WriteLine(" ######## Welcome to File Reader ######## ");
            Console.WriteLine(" ######################################## ");
            Console.WriteLine(Environment.NewLine);

            var operation = ReadInputOption<ReadOperationType>("operation");
            var accessOperation = ReadInputOption<EncryptionType>("access operation");
            var userRole = ReadInputOption<UserRoleType>("roles");
            var fileName = ReadUserInputs();

            var filePrinterRequest = new Request(fileName, accessOperation, operation, userRole);

            try
            {
                var fileContent = filesService.Print(filePrinterRequest);
                Console.WriteLine(fileContent);
                Console.ReadKey();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException");
            }

            Console.ReadKey();
        }

        private static T ReadInputOption<T>(string desc) where T : Enum
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"#### List of available of {desc}s \n");

            string selected;
            var dictionary = Enum.GetValues(typeof(T)).Cast<T>()
                .ToDictionary(x => Convert.ToInt32(x), uao => uao.ToString());

            foreach (var (key, value) in dictionary)
            {
                Console.WriteLine($" {value} -- Option: {key}");
            }

            Console.WriteLine();

            do
            {
                Console.WriteLine($" ## write your {desc}, please ## ");
                selected = Console.ReadLine();
            } while (!dictionary.ContainsKey(Convert.ToInt32(selected)));

            var result = Convert.ToInt32(selected);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"You selected: {dictionary.First(k => k.Key == result).Value} \n");

            return (T)Enum.ToObject(typeof(T), result);
        }

        private static string ReadUserInputs()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("## Write the file full path, please \n");
            Console.WriteLine(Environment.NewLine);
            return Console.ReadLine();
        }
    }
}