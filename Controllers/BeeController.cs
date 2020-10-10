using BeeTracker2.Models;
using BeeTracker2.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeeTracker2.Controllers
{
    public class BeeController
    {
        public List<Bee> GetBees(List<Bee> currentBees)
        {
            List<Bee> bees = currentBees ?? new List<Bee>();

            if (bees.Any()) { return bees; }

            foreach (BeeType beeType in ((BeeType[])Enum.GetValues(typeof(BeeType))))
            {
                for (int i = 0; i < BeeConstants.BEE_TYPE_COUNT; i++)
                {
                    bees.Add(new Bee(beeType));
                }
            }

            return bees;
        }

        public void Damage(int damagePercentage, ref Bee bee)
        {
            if (!bee.IsDead)
            {
                bee.Health -= (damagePercentage / bee.Health) * 100;
                SetLifeStatus(ref bee);
            }
        }

        private void SetLifeStatus(ref Bee bee)
        {
            if (bee.Health < bee.HealthResistance)
            {
                bee.IsDead = true;
            }
        }
    }
}