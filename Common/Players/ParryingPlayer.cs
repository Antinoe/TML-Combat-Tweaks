using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.Graphics.CameraModifiers;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using CombatTweaks.Common.Configs;
using CombatTweaks.Common.Systems;

namespace CombatTweaks.Common.Players{
	public class ParryingPlayer : ModPlayer{
		public bool isParrying = false;
		public int parryingTime = 0;
		public int parryingCooldown = 0;
		PunchCameraModifier shakeBrittle => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 10f, 10, 15f, "shakeBrittle");
		PunchCameraModifier shakeWeak => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1.5f, 10f, 10, 15f, "shakeWeak");
		PunchCameraModifier shakeModerate => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2f, 10f, 10, 15f, "shakeModerate");
		PunchCameraModifier shakeStrong => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2.5f, 10f, 10, 15f, "shakeStrong");
		public override void ProcessTriggers(TriggersSet triggersSet){
			var player = Player;
			if(CombatTweaksKeybinds.Parry.JustPressed && ParryingConfig.Instance.MasterSwitch && ParryingConfig.Instance.ParryingToggle){
				if(parryingTime == 0 && parryingCooldown == 0){
					parryingTime = 10;
					parryingCooldown = 120;
					Main.instance.CameraModifiers.Add(shakeModerate);
					SoundEngine.PlaySound(SoundID.Item1 with {Pitch=1f,Volume=0.75f}, player.position);
				}
			}
		}
		public override void PostUpdate(){
			if (parryingTime >= 1){Player.bodyFrame.Y = Player.bodyFrame.Height * 1;}
			if (parryingTime >= 4){Player.bodyFrame.Y = Player.bodyFrame.Height * 2;}
			if (parryingTime >= 7){Player.bodyFrame.Y = Player.bodyFrame.Height * 3;}
			if (parryingTime >= 10){Player.bodyFrame.Y = Player.bodyFrame.Height * 4;}
		}
		public override void PostUpdateMiscEffects(){
			if(parryingTime > 0){parryingTime--;}
			if(parryingCooldown > 0){parryingCooldown--;}
		}
		public override bool FreeDodge(Player.HurtInfo info){
			var player = Player;
			if(parryingTime > 0){
				player.immune = true;
				player.immuneTime = 30;
				return true;
			}
			return base.FreeDodge(info);
		}
	}
}
