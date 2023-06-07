using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PBT.Buffs
{
    public class HeyBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            // DisplayName.SetDefault("NUH UH");
        }
        
        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            tip = "Can't use Hey!";
        }
    }
}
