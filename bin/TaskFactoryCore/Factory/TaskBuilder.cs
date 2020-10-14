using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Timers;
using Factory.Models;
using FactoryBase;
using DBModules;
using Factory.DB;
namespace Factory
{
    public class TaskBuilder
    {
        private static System.Timers.Timer timer_short = null;
        private static System.Timers.Timer timer_med = null;
        private static System.Timers.Timer timer_long = null;
        List<Interval> intervals = new List<Interval>();
        Dictionary<string, IFactory> factories = new Dictionary<string, IFactory>();
        DBInstance dBManager = null;
        public TaskBuilder()
        {
            init();
        }
        public void init()
        {
            DBConfig.DBConn = "Server=localhost;Port=5432;Database=DVD;User id=postgres;Password=Starfish123";
            DBConfig.Provider = "Npgsql";
            dBManager = DBInstance.init();
            dBManager.getallActors();
            createTimers();
        }

        private void createTimers()
        {
            Interval shortInterval = intervals.FirstOrDefault(i => i.intervalType == "short");
            timer_short = new Timer(60000 * shortInterval.period);
            timer_short.AutoReset = true;
            timer_short.Elapsed += new ElapsedEventHandler(shortElapse);
            timer_short.Enabled = true;

            Interval mediuminterval = intervals.FirstOrDefault(i => i.intervalType == "medium");
            timer_med = new Timer(60000 * mediuminterval.period);
            timer_med.AutoReset = true;
            timer_med.Elapsed += new ElapsedEventHandler(mediumElapse);
            timer_med.Enabled = true;
        }

        private void mediumElapse(object sender, ElapsedEventArgs e)
        {
            foreach (IFactory factory in factories.Values)
            {
                factory.executeTask("medium");
            }
        }

        private void shortElapse(object sender, ElapsedEventArgs e)
        {
            foreach(IFactory factory in factories.Values)
            {
                factory.executeTask("short");
            }
        }

        public void Start()
        {
            foreach(IFactory c in factories.Values)
            {
                c.buildTasks();
            }
        }

        public void Stop()
        {

        }
    }
}
