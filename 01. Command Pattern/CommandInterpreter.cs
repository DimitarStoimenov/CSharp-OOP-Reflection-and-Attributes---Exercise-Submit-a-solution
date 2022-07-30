using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputInfo = args.Split();

            string commandtype = inputInfo[0] + "Command";

            string[] commandArgs = inputInfo.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name == commandtype).FirstOrDefault();

            
            if (type == null)
            {
                throw new InvalidOperationException("Invalid command") ;
            }

            ICommand command = (ICommand)Activator.CreateInstance(type);
            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
