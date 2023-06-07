using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PBT.Items
{
    public class AshCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ash Core");
            // Tooltip.SetDefault("Pure essence of Ash");
        }

        public override void SetDefaults()
        {
            Item.rare = 4;
            Item.value = 2000;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AshBlock, 50);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
