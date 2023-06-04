using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PBT.Items
{
	public class blank : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("blank"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is a advanced modded sword.");
		}

		public override void SetDefaults()
		{
			Item.damage = 50000;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 100;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = 2;
			Item.knockBack = 30;
			Item.value = 10000;
			Item.rare = 7;
			Item.UseSound = SoundID.DD2_GoblinScream;
			Item.shoot = 932;
			Item.shootSpeed = 3;
			Item.accessory = true;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddIngredient(ItemID.WoodBreastplate, 2);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}