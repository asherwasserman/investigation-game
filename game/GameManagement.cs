using investigation_game.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace investigation_game.game
{
    public static class GameManagement
    {

        public static void StartPlay()
        {           
            IranianAgent iranianAgent;
            iranianAgent = IranianAgentFactory.CreateAnAgent();
            while (true)
            {
                AttemptedHarm(iranianAgent);
                int vulnerability = iranianAgent.CompatibilityChecker();
                int sumOfSensors = iranianAgent.getSumOfSensors();
                Console.WriteLine($"You hit ({vulnerability}/{sumOfSensors})");
                if (vulnerability == sumOfSensors)
                {
                    break;
                }

                else
                {

                    continue;
                }
            }
            
        }

        public static void AttemptedHarm(IranianAgent iranianAgent)
        {
            int num = GettingANumberFromTheUser(iranianAgent.getSumOfSensors());
            Sensor sensor = CreateSensorByName();
            iranianAgent.SnapSensor(num, sensor);
        }

        private static int GettingANumberFromTheUser(int sum)
        {
            bool valueError = true;
            int num = 0;
            while (valueError)
            {
                Console.WriteLine("Where would you like to attach the sensor?");                
                bool isANumber = int.TryParse(Console.ReadLine(), out num);
                if (!isANumber || num >= sum)
                {
                    Console.WriteLine("value not correct");
                    Console.WriteLine("please try again!");
                    continue;
                }
                else
                {
                    valueError = false;
                }
            }
            return num;
        }

        private static Sensor CreateSensorByName()
        {
            Sensor sensor = null;
            List<string> names = new List<string>()
            {
                "Heart Rate Sensor",
                "Accelerometer",
                "Gyroscope",
                "GPS Sensor",
                "Microphone",
                "Thermal Camera",
                "Infrared Sensor",
                "Air Quality Sensor",
                "Facial Recognition Sensor",
                "RFID Scanner"
            };
            while (true)
            {
                Console.WriteLine("Enter the name of the sensor you want to associate with the agent.");
                string input = Console.ReadLine()!;
                if (names.Contains(input))
                {
                    sensor = new Sensor(input);
                    break;
                }
                else
                {
                    Console.WriteLine($"No named sensor exists{input}. ");
                    Console.WriteLine("please Enter a valid name. ");
                }
                
            }
            return sensor;

        }
    }
}
