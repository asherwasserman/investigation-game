using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace investigation_game.models
{
    public  class Sensor
    {
        public virtual string name { get; protected set; } = "Audio Sensor";
        public virtual bool Activate(Sensor sensor)
        {            
            if (this.name == sensor.name)
            {
                return true;      
            }

            else
            {
                return false;
            }            
        }    
    }

    //public class SensorFactory
    //{
    //    public static Sensor CreateASensor()
    //    {
    //        List<string> sensors = new List<string>
    //        {
    //            "Heart Rate Sensor",
    //            "Accelerometer",
    //            "Gyroscope",
    //            "GPS Sensor",
    //            "Microphone",
    //        };
    //        Random rand = new Random();
    //        Sensor newSensor = new Sensor(sensors[rand.Next(sensors.Count)]);
    //        return newSensor;
    //    }

    //    public static List<Sensor> CreateSumOfSensors(int num)
    //    {
    //        List<Sensor> sensors = new List<Sensor>();
    //        Sensor sensor;
    //        for (int i = 0; i < num; i++)
    //        {
    //            sensor = SensorFactory.CreateASensor();
    //            sensors.Add(sensor);
    //        }
    //        return sensors;
    //    }
    //}
}
