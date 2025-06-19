using investigation_game.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation_game.factorys
{
    interface IIranuanAgentFactory
    {
        public IranianAgent Create();
    }

    public class FootSoliderFactory
    {
        public IranianAgent Create()
        {
            List<Sensor> sensors;
            sensors = CreateSensors.CreateSumOfSensors(2);
            IranianAgent footSolider = new IranianAgent(sensors);
            return footSolider;
        }
    }

    public class SquadLeaderFactory : IIranuanAgentFactory
    {
        public IranianAgent Create()
        {
            List<Sensor> sensors;
            sensors = CreateSensors.CreateSumOfSensors(4);
            SquadLeader squadLeader = new SquadLeader(sensors);
            return squadLeader;
        }
    }

    //public class IranianAgentFactory
    //{
        //public static IranianAgent CreateAnAgent(string type)
        //{
        //    int numSensors;
        //    switch (type)
        //    {
        //        case "Audio Sensor":
        //            numSensors = 2;
        //            break;
        //    }
        //    List<Sensor> sensors;
        //    sensors = SensorFactory.CreateSumOfSensors(2);
        //    IranianAgent iranianAgent = new IranianAgent(sensors);
        //    return iranianAgent;
        //}
    //}
}
