using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.GlobalNPCs{
	public class LogicalContactDamage : GlobalNPC{
		public override bool InstancePerEntity => true;
		public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot){
			if(DefenseConfig.Instance.LogicalContactDamage && !DefenseConfig.Instance.noPassiveContactDamageBlacklist.Contains(new NPCDefinition(npc.type))){
				if(MathF.Abs(npc.velocity.X) < 1 && MathF.Abs(npc.velocity.Y) < 1){
					return false;
				}
			}
			return base.CanHitPlayer(npc, target, ref cooldownSlot);
		}
		public override void ModifyHitPlayer(NPC npc, Player target, ref Player.HurtModifiers modifiers){
			bool relativeSpeed1 = (target.velocity.X < 0 || npc.velocity.X < 0);
			bool relativeSpeed2 = (target.velocity.X > 0 || npc.velocity.X > 0);
			int speedDifference = ((int)target.velocity.X - (int)npc.velocity.X);
			//	Disabled for now. Needs more work.
			//if(relativeSpeed1 || relativeSpeed2){modifiers.FinalDamage.Flat *= 0.5f;}
		}
	}
}
