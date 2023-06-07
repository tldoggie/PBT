using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PBT.Projectiles;
namespace PBT.Items
{
	public class frisbee : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wooden Frisbee"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("lock in");
		}

		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 1;
			Item.height = 1;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 1000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item7;
			Item.shoot = ModContent.ProjectileType<frisbeeprojectile>();
			Item.shootSpeed = 25;
			Item.accessory = false;
			Item.autoReuse = false;
			Item.crit = 12;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PinkGel, 2);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}