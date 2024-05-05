using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.GlobalNPCs
{
	public class NPCAttackCooldowns : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public int attackCooldown = 0;
		public override void AI(NPC npc){
			if(attackCooldown > 0){
				attackCooldown--;
			}
			if(attackCooldown == 1){
				int dustID = Dust.NewDust(npc.position, npc.width, npc.height, DustID.BlueCrystalShard, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, new Color(), 2f);
				Main.dust[dustID].noGravity = true;
				SoundEngine.PlaySound(SoundID.Camera with {Pitch=+3f,Volume=1f}, npc.position);
			}
		}
		public override void DrawEffects(NPC npc, ref Color drawColor){
			if(attackCooldown > 0 && attackCooldown < 5){drawColor = Color.Yellow;}
			if(attackCooldown > 5 && attackCooldown < 10){drawColor = Color.Orange;}
		}
		public override void ModifyHitPlayer(NPC npc, Player target, ref Player.HurtModifiers modifiers){
			if(attackCooldown == 0 && DefenseConfig.Instance.MasterSwitch && DefenseConfig.Instance.NPCAttackCooldowns){attackCooldown = 60;}
		}
		public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot){
			if(attackCooldown > 0){
				return false;
			}
			return base.CanHitPlayer(npc, target, ref cooldownSlot);
		}
	}
	//	I know this isn't in a `GlobalProjectiles` folder, but it's related to Attack Cooldowns anyway.
	public class ProjectileAttackCooldowns : GlobalProjectile
	{
		public override bool InstancePerEntity => true;
		public int attackCooldown = 0;
		public override void AI(Projectile projectile){if(attackCooldown > 0){attackCooldown--;}}
		public override void ModifyHitPlayer(Projectile projectile, Player target, ref Player.HurtModifiers modifiers){
			if(attackCooldown == 0 && DefenseConfig.Instance.MasterSwitch && DefenseConfig.Instance.NPCAttackCooldowns){attackCooldown = 60;}
		}
		public override bool CanHitPlayer(Projectile projectile, Player target){
			if(attackCooldown > 0){
				return false;
			}
			return base.CanHitPlayer(projectile, target);
		}
	}
}
