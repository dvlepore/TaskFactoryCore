using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryBase
{
    public abstract class AFactory : IFactory
    {
        public string collectorId { get; set; }
        public abstract void buildTasks();
        public abstract void executeTask(string interval);
        public abstract void Start();
        public abstract void Stop();
        public AFactory(string collectorid)
        {
            this.collectorId = collectorId;
        }
    }
}
