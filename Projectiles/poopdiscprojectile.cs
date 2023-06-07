using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace PBT.Projectiles
{
	public class poopdiscprojectile : ModProjectile
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
			Projectile.penetrate = -1;
		}

        // Additional hooks/methods here.
        public override void AI()
        {
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] < 30f)
            {
				Projectile.rotation = Projectile.velocity.ToRotation();

			}
			if (Projectile.ai[0] >= 30f && Projectile.ai[0] < 70f)
			{
				Projectile.scale = Projectile.scale + (1f / 40f);
				Projectile.width = (Projectile.width + 1);
				if (Projectile.ai[0] % 5 == 0) Projectile.height = Projectile.height + 1;
				Projectile.netUpdate = true;
				Projectile.rotation = 0;
				Projectile.velocity = new Vector2(0, 0);
			}
			if (Projectile.ai[0] >= 70f)
            {

				Projectile.damage = 125;
				Projectile.rotation = 0;
				Projectile.velocity = new Vector2(0, 10);
            }
			base.AI();
        }
    }
}