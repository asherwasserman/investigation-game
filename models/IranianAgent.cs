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
        private static List<Sensor> sensors = new List<Sensor>();
        private Sensor[] AttachedSensors;
        public IranianAgent(List<Sensor> Sensors)
        {
            sensors = Sensors;
            AttachedSensors = new Sensor[sensors.Count];
        }
        

        public int CompatibilityChecker()
        {
            Sensor sensor;
            int numAttachedSensors = 0;
            for (int i = 0; i < sensors.Count; i++)
            {
                sensor = AttachedSensors[i];
                if (sensor != null)
                {
                    if (sensor.Activate(sensors[i]))
                    {
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

        public void RemoveSensor(int num)
        {
            AttachedSensors[num] = null;
        }
    }

    public class IranianAgentFactory
    {
        public static IranianAgent CreateAnAgent()
        {
            List<Sensor> sensors;
            sensors = SensorFactory.CreateSumOfSensors(2);
            IranianAgent iranianAgent = new IranianAgent(sensors);
            return iranianAgent;
        }
    }
}
