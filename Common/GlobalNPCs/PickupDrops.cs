using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using CombatTweaks.Content.Items;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.GlobalNPCs{
	public class ItemDrops : GlobalNPC{
		public int fireTimer = 0;
		public override bool InstancePerEntity => true;
		public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone){
			if(DefenseConfig.Instance.HealthPickups){
				if(npc.life <= 0 && hit.DamageType == DamageClass.Melee){
					Item.NewItem(npc.GetSource_FromAI(), npc.Center, ModContent.ItemType<LifePickup>(), 1, true);
				}
			}
		}
		public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone){
			if(DefenseConfig.Instance.HealthPickups){
				if(npc.life <= 0 && hit.DamageType == DamageClass.Melee){
					Item.NewItem(npc.GetSource_FromAI(), npc.Center, ModContent.ItemType<LifePickup>(), 1, true);
				}
			}
		}
		public override void AI(NPC npc){
			bool isOnFire = (npc.HasBuff(BuffID.OnFire) || npc.HasBuff(BuffID.OnFire3));
			if(DefenseConfig.Instance.ArmorPickups){
				fireTimer--;
				if(isOnFire && fireTimer <= 0){
					Item.NewItem(npc.GetSource_FromAI(), npc.Center, ModContent.ItemType<ArmorPickup>(), 1, true);
					fireTimer = DefenseConfig.Instance.FireTimer;
				}
			}
		}
		public override void OnKill(NPC npc){
			bool isOnFire = (npc.HasBuff(BuffID.OnFire) || npc.HasBuff(BuffID.OnFire3));
			if(DefenseConfig.Instance.ArmorPickups){
				if(isOnFire){
					Item.NewItem(npc.GetSource_FromAI(), npc.Center, ModContent.ItemType<ArmorPickup>(), 1, true);
				}
			}
		}
	}
}
