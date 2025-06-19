using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation_game.models
{
    public class IranianAgent
    {        
        protected static List<Sensor> sensors = new List<Sensor>();
        protected Sensor[] AttachedSensors;
        protected List<int> PinnedPlaces = new List<int>();
        public IranianAgent(List<Sensor> Sensors)
        {
            sensors = Sensors;
            AttachedSensors = new Sensor[sensors.Count];
        }
        

        public virtual int CompatibilityChecker()
        {
            Sensor sensor;
            int numAttachedSensors = 0;
            PinnedPlaces = new List<int>();
            for (int i = 0; i < sensors.Count; i++)
            {
                sensor = AttachedSensors[i];
                if (sensor != null)
                {
                    if (sensor.Activate(sensors[i]))
                    {
                        PinnedPlaces.Add(i);
                        numAttachedSensors++;
                    }
                }                
            }
            return numAttachedSensors;
        }

        public int getSumOfSensors()
        {
            return sensors.Count;
        }

        public void SnapSensor(int num, Sensor sensor)
        {
            AttachedSensors[num] = sensor; 
        }

        public virtual void Attack()
        {

        }
    }

    public class IranianAgentFactory
    {
        
    }
}
