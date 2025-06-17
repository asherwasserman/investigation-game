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
        int sessionCounter;
        public pulseSensor(string name) : base(name)
        {
            sessionCounter = 0;
        }

        public override bool Activate(Sensor sensor)
        {
            sessionCounter++;
            if (sessionCounter == 4)
            {
                return false;    
            }
            return base.Activate(sensor);
        } 
    }
}
