using PBT.Items;
using PBT.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace PBT.Npcs
{
    [AutoloadHead]
    public class FrisbeeMerchant : ModNPC
    {
        private static Profiles.DefaultNPCProfile NPCProfile;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.SpawnsWithCustomName[Type] = true;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 1;
            NPCID.Sets.AttackTime[Type] = 60;
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Love)
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Hate)
                .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Cyborg, AffectionLevel.Hate)
            ; // < Mind the semicolon!
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }
        public override bool CanChat()
        {
            return true;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Enjoyes the frisbee, ultimate frisbee, etc.")
            });
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string> {
                "Robin",
                "Eric Zaslow",
                "Henry Zaslow",
                "Nate"
            };
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new();

            chat.Add("I don't trust you with my Beach Bowl disc.");
            chat.Add("This is why I don't trust Rowan. He's always doing stupid things like that.");
            chat.Add("Real ones played frisbee");
            chat.Add("Come to the park. NOW");
            chat.Add("Ash was too pussy to join the pickup game.");
            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = Language.GetTextValue("LegacyInterface.28"); //This is the key to the word "Shop"
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Shop";
            }
        }

        public override void AddShops()
        {
            new NPCShop(Type)
                .Add<frisbee>()
                .Add<discraft>()
                .Add<poopdisc>()
                .Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 2f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 1;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<discraftprojectile>();
            attackDelay = 1;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)
        { // Requirements for the town NPC to spawn.
            for (int k = 0; k < Main.maxPlayers; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }
            }

            return true;
        }
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }
    }
}
