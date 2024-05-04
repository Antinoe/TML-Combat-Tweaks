using Terraria;
using Terraria.ModLoader;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.Players{
	public class DefensePlayer : ModPlayer{
		public override void PostUpdateMiscEffects(){
			var player = Player;
			if(DefenseConfig.Instance.MasterSwitch){
				player.statDefense *= (int)DefenseConfig.Instance.DefenseMultiplier;
				player.DefenseEffectiveness *= DefenseConfig.Instance.DefenseEffectiveness;
				if(player.immuneTime > 0){
					if(DefenseConfig.Instance.NoImmuneTime){player.immuneTime = 0;}
					player.immuneTime -= DefenseConfig.Instance.ImmuneTimeSubtraction;
				}
			}
		}
		public override bool FreeDodge(Player.HurtInfo info){
			var player = Player;
			if(DefenseConfig.Instance.MinDamageImmunity){
				if(info.Damage == 1){
					player.immune = true;
					player.immuneTime = 40;
					return true;
				}
			}
			return base.FreeDodge(info);
		}
		public override void ModifyHurt(ref Player.HurtModifiers modifiers){
			var player = Player;
			if(DefenseConfig.Instance.MasterSwitch){
				modifiers.FinalDamage *= 1f - DefenseConfig.Instance.InitialDamageReduction;
			}
		}
	}
}
