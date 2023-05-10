using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.Audio;
//	This is needed in order to use Blocking's player-specific fields.
using static CombatTweaks.BlockingPlayer;

namespace CombatTweaks
{
    public class BlockingGlobalNPC : GlobalNPC
    {
		public int npcGuardTimer = 0;
		public override bool InstancePerEntity => true;
		
		public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
		{
			//Parrying
			if (BlockingConfig.Instance.NPCParryWhitelist.Contains(new NPCDefinition(npc.type)))
			{
				if (Main.rand.Next(2) == 0)
				{
					if (CombatTweaksConfigClient.Instance.enableSoundsParrying)
					{
						SoundEngine.PlaySound(Parry, npc.position);
					}
					modifiers.FinalDamage.Flat = 0;
					NPC.immuneTime = 200;
				}
			}
			//Guarding
			if (BlockingConfig.Instance.NPCGuardWhitelist.Contains(new NPCDefinition(npc.type)))
			{
				if (Main.rand.Next(2) == 0)
				{
					if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlock)
					{
						SoundEngine.PlaySound(Block, npc.position);
					}
					modifiers.FinalDamage /= 2;
				}
			}
			//Shield Guarding
			if (BlockingConfig.Instance.NPCShieldGuardWhitelist.Contains(new NPCDefinition(npc.type)))
			{
				if (Main.rand.Next(BlockingConfig.Instance.npcShieldGuardChance) == 0)
				{
					if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlockShield)
					{
						SoundEngine.PlaySound(BlockShield, npc.position);
					}
					modifiers.FinalDamage.Flat /= 4;
				}
			}
		}
		//	Won't be using this. Maybe another time..
		/*public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			Main.NewText("ModifyHitByItem is being ran.");
			BlockingPlayer bp = player.GetModPlayer<BlockingPlayer>();
			if (bp.counterDamage > 0)
			{
				damage += bp.counterDamage;
				bp.counterDamage -= damage;
				Main.NewText("Counter Damage spent.");
				SoundEngine.PlaySound(BlockShield with {Pitch = +0.75f, Volume = 1f}, npc.position);
			}
		}*/
	}
}