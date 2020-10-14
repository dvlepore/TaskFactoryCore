using Factory;
using System;
namespace TaskFactoryCore
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskBuilder taskBuilder = new TaskBuilder();
            taskBuilder.init();
        }
    }
}
