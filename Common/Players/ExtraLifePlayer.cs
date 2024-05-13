using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.Players{
	public class ExtraLifePlayer : ModPlayer{
		public int ExtraLifeImmuneTime = 0;
		public override void PostUpdateMiscEffects(){
			var player = Player;
			if(ExtraLifeImmuneTime > 0){ExtraLifeImmuneTime--;}
			if(ExtraLifeImmuneTime == 121){SoundEngine.PlaySound(SoundID.Item4,player.position);}
			if(ExtraLifeImmuneTime == 61){SoundEngine.PlaySound(SoundID.Item4,player.position);}
			if(ExtraLifeImmuneTime == 1){SoundEngine.PlaySound(SoundID.Item4,player.position);}
		}
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource){
			var player = Player;
			bool hasLifeCrystals = (player.statLifeMax >= 120 && player.statLifeMax <= 400);
			bool hasLifeFruits = (player.statLifeMax >= 405 && player.statLifeMax <= 500);
			if(DefenseConfig.Instance.MasterSwitch && DefenseConfig.Instance.ExtraLifeMode){
				if(hasLifeCrystals){
					SoundEngine.PlaySound(SoundID.Shatter,player.position);
					CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Color.Red, "Life Crystal Expunged", true, true);
					if(player.ConsumedLifeCrystals > 0){player.ConsumedLifeCrystals--;}
					//player.statLifeMax -= 20;
					player.statLife = player.statLifeMax;
					ExtraLifeImmuneTime = 241;
					return false;
				}
				if(hasLifeFruits){
					SoundEngine.PlaySound(SoundID.NPCDeath1,player.position);
					CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Color.Gold, "Life Fruit Expunged", true, true);
					if(player.ConsumedLifeFruit > 0){player.ConsumedLifeFruit--;}
					//player.statLifeMax -= 5;
					player.statLife = player.statLifeMax;
					ExtraLifeImmuneTime = 241;
					return false;
				}
			}
			return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genDust, ref damageSource);
		}
		public override bool FreeDodge(Player.HurtInfo info){
			var player = Player;
			if(ExtraLifeImmuneTime > 0){player.shadowCount++; return true;}
			return base.FreeDodge(info);
		}
	}
}
