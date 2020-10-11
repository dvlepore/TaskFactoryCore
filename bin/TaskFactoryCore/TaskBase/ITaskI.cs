using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace TaskBase
{
    public interface ITaskI
    {
        string taskInterval { get; set; }

        void processTask();
    }
}
