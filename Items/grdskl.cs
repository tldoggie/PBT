using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using SoundID = Terraria.ID.SoundID;

namespace PBT.Items
{
    public class grdskl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hekllo Wirkd!"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("This is a advanced modded sword.");
        }

        public override void SetDefaults()
        {
            Item.mech = true;
            Item.makeNPC = number();
            Item.damage = 19;
            Item.DamageType = DamageClass.MagicSummonHybrid;
            Item.width = 100;
            Item.height = 20;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.useStyle = 3;
            Item.knockBack = 30;
            Item.value = 10001;
            Item.rare = 11;
            Item.UseSound = SoundID.DD2_MonkStaffGroundImpact;
            Item.shoot = 932;
            Item.shootSpeed = 3;
            Item.autoReuse = true;
        }

        private int number()
        {
            return new Random().Next(-65, 668);
        }

        /*
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            return true;
        }*/

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Vector2 velocity, int type, int damage, float knockback)
        {
            NPC.NewNPC(new EntitySource_ItemUse(player, source.Item), (int)position.X, (int)position.Y, new Random().Next(-65, 669));
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.Register();
        }
    }
}
