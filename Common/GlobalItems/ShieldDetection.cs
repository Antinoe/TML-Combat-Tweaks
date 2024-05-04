using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CombatTweaks.Common.Players;

namespace CombatTweaks.Common.GlobalItems{
	public class ShieldDetection : GlobalItem{
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(Item item, bool lateInstantiation){
			if(item.shieldSlot != -1){return true;}
			else if(item.handOnSlot != -1){return true;}
			else if(item.shoeSlot != -1){return true;}
			return false;
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips){
			if(item.shieldSlot > -1){
				var line = new TooltipLine(Mod, "CombatTweaks:Shield", "Hold GUARD to raise shield and block damage with Mana.");
				tooltips.Add(line);
			}
		}
		public override void UpdateEquip(Item item, Player player){
			GuardingPlayer gp = player.GetModPlayer<GuardingPlayer>();
			if(!gp.hasShield){gp.hasShield = item.shieldSlot > -1;}
			if(!gp.hasGlove){gp.hasGlove = item.handOnSlot > -1;}
			if(!gp.hasBoot){gp.hasBoot = item.shoeSlot > -1;}
			//if(item.shieldSlot > -1 && item.defense > 0){player.statLifeMax2 += item.defense * 25;}
		}
	}
}
