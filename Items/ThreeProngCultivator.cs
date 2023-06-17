using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PBT.Items
{
    public class ThreeProngCultivator : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ash Core");
            // Tooltip.SetDefault("Pure essence of Ash");
        }

        public override void SetDefaults() 
        { 
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.scale = 1;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = 40000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
    }
}