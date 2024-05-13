using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.Graphics.CameraModifiers;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.Players{
	public class ArmorPlayer : ModPlayer{
		public int statArmor = 0;
		public int statArmorMax = 0;
		public int statArmorMax2 = 100;
		public override void PostUpdateMiscEffects(){
			var player = Player;
			//	Couldn't get values past 2 working.
			//if(player.statDefense > 0){statArmorMax = (player.statDefense * DefenseConfig.Instance.ArmorMultiplier);}
			if(player.statDefense > 0){statArmorMax = (player.statDefense * 5);}
			else{statArmorMax = 0;}
		}
		public override void ModifyHurt(ref Player.HurtModifiers modifiers){
			var player = Player;
			var damage = (int)modifiers.FinalDamage.Flat;
			if(statArmor > 0){modifiers.DisableSound();}
		}
		public override bool FreeDodge(Player.HurtInfo info){
			var player = Player;
			ArmorPlayer ap = player.GetModPlayer<ArmorPlayer>();
			DodgingPlayer dp = player.GetModPlayer<DodgingPlayer>();
			GuardingPlayer gp = player.GetModPlayer<GuardingPlayer>();
			ParryingPlayer pp = player.GetModPlayer<ParryingPlayer>();
			bool isDodging = (dp.dodgingTime > 0);
			bool isGuarding = (gp.guardingTime > 0);
			bool isShieldGuarding = (gp.guardingTime > 0 && gp.hasShield);
			bool isParrying = (pp.parryingTime > 0);
			//	Need to fix this...
			//	I'd really like for this to account for other mods, but I haven't found a solution yet,
			//	so I'll just hard-code it to exclude this mod's features for now.
			if(isShieldGuarding || isDodging || isParrying){return base.FreeDodge(info);}
			if(info.Damage > 0 && statArmor > 0){
				statArmor -= info.Damage;
				player.immune = true;
				player.immuneTime = 40;
				if(!player.noKnockback && DefenseConfig.Instance.ArmorKnockback){
					if(player.velocity.Y < 1f){player.velocity.Y -= 5f;}
					if(info.HitDirection == 1){player.velocity.X += 5f;}
					if(info.HitDirection == -1){player.velocity.X -= 5f;}
				}
				SoundEngine.PlaySound(SoundID.NPCHit4, player.position);
				CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Color.LightGray, (info.Damage), false, false);
				return true;
			}
			return base.FreeDodge(info);
		}
	}
}
