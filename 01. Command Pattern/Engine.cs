﻿using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string result = commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ie)
                {

                    Console.WriteLine(ie.Message);
                }
            }
        }
    }
}
