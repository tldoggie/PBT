using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace PBT.Projectiles
{
    public class poopdiscprojectile : ModProjectile
    {
        private Vector2 mousepos;
        private bool dropping = false;
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

        public override void OnSpawn(IEntitySource source)
        {
            if (Projectile.owner == Main.myPlayer)
            {
                mousepos = Main.MouseWorld;
            }
        }
        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (!dropping)
            {
                if (Projectile.Distance(mousepos) > 25f) Projectile.velocity = Projectile.DirectionTo(mousepos) * 25f;
                else Projectile.velocity = Projectile.DirectionTo(mousepos) * Projectile.Distance(mousepos);
                Projectile.rotation = Projectile.velocity.ToRotation();
                if (Projectile.Distance(mousepos) < 1f)
                {
                    dropping = true;
                    Projectile.ai[0] = 0;
                }
            }
            if (dropping && Projectile.ai[0] < 40f)
            {
                Projectile.scale = Projectile.scale + (1f / 40f);
                Projectile.width = (Projectile.width + 1);
                if (Projectile.ai[0] % 5 == 0) Projectile.height = Projectile.height + 1;
                Projectile.netUpdate = true;
                Projectile.rotation = 0;
                Projectile.velocity = new Vector2(0, 0);
            }
            if (dropping && Projectile.ai[0] >= 40f)
            {

                Projectile.damage = 125;
                Projectile.rotation = 0;
                Projectile.velocity = new Vector2(0, 18f);
            }
            base.AI();
        }
    }
}