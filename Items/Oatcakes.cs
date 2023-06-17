using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace PBT.Items
{
    public class Oatcakes : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsFood[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.DefaultToFood(22, 22, BuffID.WellFed, 21600);
            Item.rare = 1;
            Item.value = 2500;
        }
    }
}
