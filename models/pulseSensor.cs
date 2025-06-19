using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace investigation_game.models
{
    public class pulseSensor: Sensor
    {
        public override string name { get; protected set; } = "Pulse Sensor";
        int sessionCounter;
        public pulseSensor() : base()
        {
            sessionCounter = 0;

        }

        public override bool Activate(Sensor sensor)
        {
            sessionCounter++;
            if (sessionCounter > 3)
            {
                return false;    
            }
            return base.Activate(sensor);
        } 
    }
}
