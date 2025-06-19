using investigation_game.factorys;
using investigation_game.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace investigation_game.game
{
    public  class GameManagement
    {
        private Dictionary<string, int> AgentsExposed;

        public  void StartPlay()
        {
            bool checker = true;
            while (checker)
            {
                IranianAgent iranianAgent = ChooseAgent();
                PlayingAgainstAnAgent(iranianAgent);
                Console.WriteLine("1. Another round with an agent \n2. exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "2":
                        checker = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("We look forward to seeing you in the next game.");
        }
        public  void PlayingAgainstAnAgent(IranianAgent iranianAgent)
        {     
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

        public void AttemptedHarm(IranianAgent iranianAgent)
        {
            int num = GettingANumberFromTheUser(iranianAgent.getSumOfSensors());
            Sensor sensor = CreateSensorByName();
            iranianAgent.SnapSensor(num, sensor);
        }

        private  int GettingANumberFromTheUser(int sum)
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

        private  Sensor CreateSensorByName()
        {
            Sensor sensor = null;
            List<string> names = new List<string>()
            {
                "audio sensor",
                "pulse sensor"
            };
            while (true)
            {
                Console.WriteLine("Enter the name of the sensor you want to associate with the agent.");
                string input = Console.ReadLine()!;
                input.ToLower();
                if (names.Contains(input))
                {
                    switch (input)
                    {
                        case "audio sensor":
                            sensor = new Sensor();
                            break;
                        case "pulse sensor":
                            sensor = new pulseSensor();
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"No named sensor exists '{input}'. ");
                    Console.WriteLine("please Enter a valid name. ");
                }
                
            }
            return sensor;

        }
        public IranianAgent ChooseAgent()
        {
            IranianAgent iranianAgent = null;
            List<string> names = new List<string>()
            {
                "foot soldier",
                "squad leader"
            };
            while (true)
            {                
                Console.WriteLine("Please enter the type of agent you want to expose.");
                string input = Console.ReadLine()!;
                input.ToLower();
                if (names.Contains(input))
                {
                    FootSoliderFactory fsf = new();
                    SquadLeaderFactory slf = new();
                    switch (input)
                    {
                        case ("foot soldier"):
                            iranianAgent = fsf.Create();
                            break;

                        case ("squad leader"):
                            iranianAgent = slf.Create();
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"There is no agent named '{input}'");
                }
            }
            return iranianAgent;
            

            //    FootSoliderFactory fsf = new();
            //    SquadLeaderFactory slf = new();
            //    IranianAgent iranianAgent = null;
            //    Console.WriteLine("Please enter the type of agent you want to expose.");
            //    string input = Console.ReadLine()!;
            //    input.ToLower();
            //    switch (input)
            //    {
            //        case ("foot soldier"):
            //            iranianAgent = fsf.CreateAgent();
            //            break;

            //        case ("squad leader"):
            //            iranianAgent = slf.CreateAgent();
            //            break;
            //    }
              // return iranianAgent;
            //}
        }
    }
}
