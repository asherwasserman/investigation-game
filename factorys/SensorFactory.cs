using investigation_game.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation_game.factorys
{
    interface ISensorFactory
    {
        public Sensor CreateSensor();
    }
    public class BasicSensorFactory:ISensorFactory
    {
        public Sensor CreateSensor()
        {
            Sensor sensor;
            sensor = new();
            return sensor;
        }
    }

    public class PulseSensorFactory: ISensorFactory
    {
        public Sensor CreateSensor()
        {
            pulseSensor pulseSensor = new();
            return pulseSensor;
        }
    }

    public static class CreateSensors
    {
        public static List<Sensor> CreateSumOfSensors(int num)
        {           
            List<Sensor> sensors = new();
            for (int i = 0; i < num; i++)
            {
                Random rand = new();
                int number = rand.Next(2);
                BasicSensorFactory bsf = new();
                PulseSensorFactory psf = new();
                switch (number)
                {
                    case 0:
                        Sensor sensor = bsf.CreateSensor();
                        sensors.Add(sensor);
                        break;
                    case 1:
                        Sensor pulseSensor = psf.CreateSensor();
                        sensors.Add(pulseSensor);
                        break;
                }
            }
            return sensors;
        }
    }
}
