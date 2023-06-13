using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace PBT.Projectiles
{
	public class discraftprojectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Discraft Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.maxPenetrate = 5;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
				Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
				if (Projectile.ai[0] >= 45f) {
					Projectile.Kill();
					return false;
				}
				/*if (Projectile.ai[0] <= 2.5f)
				{
					Projectile.Kill();
					return false;
				}*/
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
        public override void AI()
        {
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 45f)
			{
				Projectile.netUpdate = true;
				if (Projectile.Distance(Main.player[Projectile.owner].Center) > 18f) Projectile.velocity = Projectile.DirectionTo(Main.player[Projectile.owner].Center) * 18f;
				else Projectile.velocity = Projectile.DirectionTo(Main.player[Projectile.owner].Center) * (Projectile.Distance(Main.player[Projectile.owner].Center));
				if (Projectile.Distance(Main.player[Projectile.owner].Center) < 1f) Projectile.Kill();
			}
			base.AI();
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
			if (target == Main.player[Projectile.owner])
            {
				Projectile.Kill();
            }
            else base.OnHitPlayer(target, info);
        }
    }
}