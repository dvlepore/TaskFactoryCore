using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace FactoryBase
{
    public interface IFactory
    {
        void Start();
        void Stop();
        void buildTasks();
        void executeTask(string interval);
    }
}
