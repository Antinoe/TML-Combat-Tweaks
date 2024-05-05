using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.Graphics.CameraModifiers;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.Mount;
using CombatTweaks.Common.Configs;
using CombatTweaks.Common.Systems;

namespace CombatTweaks.Common.Players{
	public class DodgingPlayer : ModPlayer{
		public int dodgingTime = 0;
		public int dodgingCooldown = 0;
		PunchCameraModifier shakeBrittle => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 10f, 10, 15f, "shakeBrittle");
		PunchCameraModifier shakeWeak => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1.5f, 10f, 10, 15f, "shakeWeak");
		PunchCameraModifier shakeModerate => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2f, 10f, 10, 15f, "shakeModerate");
		PunchCameraModifier shakeStrong => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2.5f, 10f, 10, 15f, "shakeStrong");
		public override void ProcessTriggers(TriggersSet triggersSet){
			var player = Player;
			if(CombatTweaksKeybinds.Dodge.JustPressed && DodgingConfig.Instance.MasterSwitch && DodgingConfig.Instance.DodgingToggle){
				bool controls = (player.controlLeft || player.controlRight);
				bool canDodge = (!player.mount.Active && dodgingTime == 0 && dodgingCooldown == 0 && player.velocity.Y == 0 && controls);
				if(canDodge){
					dodgingTime = 40;
					dodgingTime = dodgingCooldown = 80;
					Main.instance.CameraModifiers.Add(shakeWeak);
					SoundEngine.PlaySound(SoundID.Item1 with {Pitch=1f,Volume=0.75f}, player.position);
					if(player.direction == 1){player.velocity.X += 5f;}
					if(player.direction == -1){player.velocity.X -= 5f;}
				}
			}
		}
		public override void PostUpdateMiscEffects(){
			var player = Player;
			if(dodgingTime > 0){dodgingTime--;}
			if(dodgingCooldown > 0){dodgingCooldown--;}
		}
		public override void PostUpdate(){
			var player = Player;
			//	A very messy rotation.. I'll have to fix this.
			//if(dodgingTime > 0){player.fullRotation++;}
			//if(dodgingTime == 0){player.fullRotation = 0;}
		}
		public override bool FreeDodge(Player.HurtInfo info){
			var player = Player;
			if(dodgingTime > 0){return true;}
			return base.FreeDodge(info);
		}
	}
}
