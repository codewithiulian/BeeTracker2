using BeeTracker2.Controllers;
using BeeTracker2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeeTracker2
{
    public partial class _Default : Page
    {
        private BeeController BeeController => new BeeController();

        private List<Bee> bees;

        public List<Bee> Bees
        {
            get { return bees ?? Session["bees"] as List<Bee>; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bees = BeeController.GetBees(Bees);
                DefineBeesSession(bees);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBeesGrid();
            }
        }

        private void BindBeesGrid()
        {
            gvBees.DataSource = Bees;
            gvBees.DataBind();
        }

        protected void LnkDamage_Click(object sender, EventArgs e)
        {
            Guid beeId = Guid.Parse((sender as LinkButton).CommandArgument);
            List<Bee> bees = Bees;
            Bee bee = bees.Where(b => b.ID == beeId).FirstOrDefault();
            int damage = new Random().Next(81);

            bee.Damage(damage);

            DefineBeesSession(bees);

            BindBeesGrid();
        }

        private void DefineBeesSession(List<Bee> bees)
        {
            Session["bees"] = bees;
        }
    }
}