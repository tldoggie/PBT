using Microsoft.Xna.Framework;
using PBT.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace PBT.Items
{
    public class Hey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hey!");
            Tooltip.SetDefault("Jumpscare your enemies");
        }
        public override void SetDefaults()
        {
            Item.SetWeaponValues(500, 0, 40);
            Item.DamageType = DamageClass.Magic;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 5;
            Item.rare = 5;
            Item.value = 15000;
            Item.autoReuse = false;
            Item.mana = 30;
            Item.shoot = ModContent.ProjectileType<Projectiles.HeyProjectile>();
            Item.shootSpeed = 10;
        }
        public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
        {
            if (player.HasBuff(ModContent.BuffType<HeyBuff>())) reduce = 30;
            else reduce = 0;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.HasBuff(ModContent.BuffType<HeyBuff>())) return false;
            else
            {
                //base.Shoot(player, source, position, velocity, type, damage, knockback);
                SoundEngine.PlaySound(SoundID.Item8);
                player.AddBuff(ModContent.BuffType<HeyBuff>(), 300);
                return true;
            }
        }

        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<AshCore>());
            r.AddIngredient(ItemID.CrossNecklace);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
