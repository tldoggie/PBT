using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace PBT.Projectiles
{
	public class frisbeeprojectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frisbee Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 100;
			Projectile.aiStyle = ProjAIStyleID.Boomerang;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.maxPenetrate = 3;
			AIType = ProjectileID.WoodenBoomerang;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
				Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

				// If the projectile hits the left or right side of the tile, reverse the X velocity
				if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}

				// If the projectile hits the top or bottom side of the tile, reverse the Y velocity
				if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			return false;
			
		}

		// Additional hooks/methods here.
	}
}