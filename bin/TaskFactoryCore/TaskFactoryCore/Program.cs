using Factory;
using System;

namespace TaskFactoryCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TaskBuilder taskBuilder = new TaskBuilder();
            taskBuilder.init();
        }
    }
}
