using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.GlobalNPCs
{
	public class LogicalContactDamage : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot){
			if(DefenseConfig.Instance.LogicalContactDamage){
				if(npc.velocity.X == 0 || npc.velocity.Y == 0){
					return false;
				}
			}
			return base.CanHitPlayer(npc, target, ref cooldownSlot);
		}
	}
}
