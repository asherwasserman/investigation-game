using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation_game.models
{
    public class SquadLeader: IranianAgent
    {
        public int numAttacks;
        public SquadLeader(List<Sensor> sensors) : base(sensors)
        {
            numAttacks = 0;
        }

        public override int CompatibilityChecker()
        {
            numAttacks++;
            return base.CompatibilityChecker();
        }

        public override void Attack()
        {
            if (numAttacks == 3)
            {
                if (PinnedPlaces != null)
                {
                    Random rand = new Random();
                    int num = rand.Next(PinnedPlaces.Count);
                    RemoveSensor(num);
                }                  
            }
        }

        public void RemoveSensor(int num)
        {
            AttachedSensors[num] = null;
        }

    }
}
