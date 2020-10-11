using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBase
{
    public abstract class  ATask : ITaskI
    {
        public string taskID { get; set; }
        public string taskInterval { get; set; }

        public abstract void processTask();
    }
}
