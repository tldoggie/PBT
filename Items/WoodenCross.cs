using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PBT.Items
{
    public class WoodenCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ash's Wooden Cross"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("The rusty nails add an extra punch");
        }

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.scale = 2;
            Item.useTime = 75;
            Item.useAnimation = 75;
            Item.useStyle = 1;
            Item.knockBack = 15;
            Item.value = 5000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}