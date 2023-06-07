using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PBT.Projectiles;
namespace PBT.Items
{
	public class discraft : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("1993 Ultrastar Discraft Frisbee"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("USA Ultimate Approved");
		}

		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 1;
			Item.height = 1;
			Item.scale = 0.75f;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 5000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item7;
			Item.shoot = ModContent.ProjectileType<discraftprojectile>();
			Item.shootSpeed = 30;
			Item.accessory = false;
			Item.autoReuse = false;
			Item.crit = 18;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			//recipe.AddIngredient(ItemID.PinkGel, 2);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}