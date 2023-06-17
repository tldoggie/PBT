using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PBT.Items
{
    public class TheWeapon : ModItem
    {
        DamageClass MeleeMace = DamageClass.Melee;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ash's Flaming Cross"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("Don't ask him what he was using it for");
        }

        public override void SetDefaults()
        {
            Item.damage = 95;
            Item.DamageType = MeleeMace;
            Item.width = 20;
            Item.height = 20;
            Item.scale = 2;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = 1;
            Item.value = 50000;
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ThreeProngCultivator>(), 1);
            recipe.AddIngredient(ItemID.Ruler, 1);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}