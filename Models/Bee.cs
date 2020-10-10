using BeeTracker2.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeeTracker2.Models
{
    public class Bee
    {
        public Guid ID { get; set; }
        public float Health { get; set; }
        public BeeType Type { get; set; }
        public bool IsDead { get; set; }
        public float HealthResistance { get; private set; }

        public Bee(BeeType beeType)
        {
            ID = Guid.NewGuid();
            Health = 100.0F;
            Type = beeType;
            IsDead = false;
            HealthResistance = ComputeHealthResistance(beeType);
        }

        private float ComputeHealthResistance(BeeType beeType)
        {
            switch (beeType)
            {
                case BeeType.Worker:
                    return BeeConstants.WORKER_HEALTH_RESISTANCE;
                case BeeType.Queen:
                    return BeeConstants.QUEEN_HEALTH_RESISTANCE;
                case BeeType.Drone:
                    return BeeConstants.DRONE_HEALTH_RESISTANCE;
                default:
                    return 0.0F;
            }
        }
    }
}