using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PBT.Projectiles
{
    public class HeyProjectile : ModProjectile
    {
        public override void SetStaticDefaults() 
        {
            // DisplayName.SetDefault("Concentrated Ash");    
        }

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = ProjAIStyleID.GemStaffBolt;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = 30;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 600;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //base.OnHitNPC(target, damage, knockback, crit);
            target.AddBuff(BuffID.Ichor, 420);
            SoundEngine.PlaySound(new($"{nameof(PBT)}/Sounds/Hey"));
        }
    }
}
