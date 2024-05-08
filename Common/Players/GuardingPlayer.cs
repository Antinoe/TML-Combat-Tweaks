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
	public class GuardingPlayer : ModPlayer{
		//public bool isGuarding = false;
		//public bool isGuardingWithShield = false;
		public int guardingTime = 0;
		public bool hasShield = false;
		public bool hasGlove = false;
		public bool hasBoot = false;
		PunchCameraModifier shakeBrittle => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 10f, 10, 15f, "shakeBrittle");
		PunchCameraModifier shakeWeak => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1.5f, 10f, 10, 15f, "shakeWeak");
		PunchCameraModifier shakeModerate => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2f, 10f, 10, 15f, "shakeModerate");
		PunchCameraModifier shakeStrong => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2.5f, 10f, 10, 15f, "shakeStrong");
		public override void ResetEffects(){
			hasShield = false;
			hasGlove = false;
			hasBoot = false;
		}
		public override void ProcessTriggers(TriggersSet triggersSet){
			var player = Player;
			if(CombatTweaksKeybinds.Guard.JustPressed && GuardingConfig.Instance.MasterSwitch && GuardingConfig.Instance.GuardingToggle){
				Main.instance.CameraModifiers.Add(shakeWeak);
				SoundEngine.PlaySound(SoundID.Dig with {Pitch=1.50f,Volume=0.25f}, player.position);
			}
			if(CombatTweaksKeybinds.Guard.Current && GuardingConfig.Instance.MasterSwitch && GuardingConfig.Instance.GuardingToggle){
				guardingTime++;
			}
			if(CombatTweaksKeybinds.Guard.JustReleased){
				guardingTime=0;
				if(GuardingConfig.Instance.MasterSwitch && GuardingConfig.Instance.GuardingToggle){
					Main.instance.CameraModifiers.Add(shakeWeak);
					SoundEngine.PlaySound(SoundID.Dig with {Pitch=1.25f,Volume=0.25f}, player.position);
				}
			}
		}
		public override void PostUpdate(){
			if(guardingTime >= 1){Player.bodyFrame.Y = Player.bodyFrame.Height * 10;}
			if(guardingTime >= 10){Player.bodyFrame.Y = Player.bodyFrame.Height * 11;}
		}
		public override void PostUpdateMiscEffects(){
			var player = Player;
			if(guardingTime > 0){player.velocity.X *= 0.95f;}
			if(guardingTime > 0 && hasShield){player.thorns += GuardingConfig.Instance.ShieldThorns;}
		}
		public override void ModifyHurt(ref Player.HurtModifiers modifiers){
			var player = Player;
			var damage = (int)modifiers.FinalDamage.Flat;
			if(guardingTime > 0){
				modifiers.DisableSound();
				modifiers.FinalDamage *= 1f - GuardingConfig.Instance.GuardingDamageReduction;
			}
		}
		public override void OnHurt(Player.HurtInfo info){
			var player = Player;
			if(guardingTime > 0){
				SoundEngine.PlaySound(SoundID.Dig with {Pitch=1f,Volume=1f}, player.position);
			}
		}
		public override bool FreeDodge(Player.HurtInfo info){
			var player = Player;
			ParryingPlayer pp = player.GetModPlayer<ParryingPlayer>();
			if(guardingTime > 0 && hasShield && pp.parryingTime == 0){
				if(player.statMana > 0 && player.statMana >= (info.Damage * GuardingConfig.Instance.ShieldGuardingDamageMultiplier)){
					SoundEngine.PlaySound(SoundID.Tink with {Pitch=-0.65f,Volume=1f}, player.position);
					player.statMana -= (info.Damage * GuardingConfig.Instance.ShieldGuardingDamageMultiplier);
					player.immune = true;
					player.immuneTime = 40;
					return true;
				}
			}
			return base.FreeDodge(info);
		}
	}
}
