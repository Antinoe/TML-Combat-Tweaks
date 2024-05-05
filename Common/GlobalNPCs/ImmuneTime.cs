using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.GlobalNPCs
{
	public class NPCImmuneTime : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		//public bool immune = false;
		public int immuneTime = 0;
		public override void AI(NPC npc){
			if(immuneTime > 0){immuneTime--;}
			//	There's gotta be a better way of doing this. I just don't see it yet.
			//	:nauseous: This code is atrocious..
			if(immuneTime == 40){npc.alpha = 255;}
			if(immuneTime == 35){npc.alpha = 155;}
			if(immuneTime == 30){npc.alpha = 0;}
			if(immuneTime == 25){npc.alpha = 255;}
			if(immuneTime == 20){npc.alpha = 155;}
			if(immuneTime == 15){npc.alpha = 0;}
			if(immuneTime == 10){npc.alpha = 155;}
			if(immuneTime == 5){npc.alpha = 255;}
			if(immuneTime == 1){
				npc.alpha = 0;
			}
		}
		public override bool? CanBeHitByItem(NPC npc, Player player, Item item){
			if(immuneTime > 0){return false;}
			return base.CanBeHitByItem(npc,player,item);
		}
		public override bool? CanBeHitByProjectile(NPC npc, Projectile projectile){
			if(immuneTime > 0){return false;}
			return base.CanBeHitByProjectile(npc,projectile);
		}
		public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone){
			if(immuneTime == 0){
				immuneTime = 40;
			}
		}
		public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone){
			if(immuneTime == 0){
				immuneTime = 40;
			}
		}
	}
}
