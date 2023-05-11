using System;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.Graphics.CameraModifiers;
using Microsoft.Xna.Framework;

namespace CombatTweaks
{
    public class CombatTweaksPlayer : ModPlayer
    {
		public int counterDamage = 0;
		public int counterDamageReserve = 0;
		public static CombatTweaksPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<CombatTweaksPlayer>();
		}
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			var player = Main.LocalPlayer;

			if (CombatTweaks.RevUp.JustPressed && counterDamageReserve > 0)
			{
				SoundEngine.PlaySound(SoundID.Run with {Pitch = +0.75f, Volume = 1f}, player.position);
				/*counterDamageReserve *= (int)0.75f;
				counterDamage += counterDamageReserve * (int)1.25f;*/
				counterDamage += counterDamageReserve;
				counterDamageReserve -= counterDamage;
			}
		}

		/*public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers)
		{
			Main.NewText("ModifyHitNPCWithItem");
			if (counterDamage > 0)
			{
				modifiers.FinalDamage += counterDamage;
				counterDamage -= (int)modifiers.FinalDamage;
				Main.NewText("Counter Damage spent.");
				SoundEngine.PlaySound(SoundID.Run with {Pitch = +0.75f, Volume = 1f}, target.position);
			}
		}*/
		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
		{
			Main.NewText("OnHitNPCWithItem");
			if (counterDamage > 0)
			{
				damageDone += counterDamage;
				counterDamage -= (int)damageDone;
				Main.NewText("Counter Damage spent.");
				SoundEngine.PlaySound(SoundID.Run with {Pitch = +0.75f, Volume = 1f}, target.position);
			}
		}
		
		public override void PostHurt(Player.HurtInfo info)
		{
			counterDamageReserve += (int) info.Damage;
		}
	}

	//	Blocking
    public class BlockingPlayer : ModPlayer
    {
		public int guardTimer = 0;
		public int parryTimer = 0;
		public bool hasShield = false;
		public bool hasGlove = false;
		public bool hasGloveBenefits = false;
		public bool hasBoot = false;
		public bool hasBootBenefits = false;
		public bool guardBashing = false;
		public int guardBashTimer = 0;
		public int guardBashCooldown = 0;
		public bool potentGuarding = true;
		public bool canPotentGuard;
		public int guardingCooldown = 0;
		public int potentGuardingCooldown = 0;
		public int parryCooldown = 0;
		public bool parryCounter = true;
		public int parryCounterCooldown = 0;
		PunchCameraModifier shakeBrittle => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 10f, 10, 15f, "shakeBrittle");
		PunchCameraModifier shakeWeak => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1.5f, 10f, 10, 15f, "shakeWeak");
		PunchCameraModifier shakeModerate => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2f, 10f, 10, 15f, "shakeModerate");
		PunchCameraModifier shakeStrong => new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 2.5f, 10f, 10, 15f, "shakeStrong");
		
		//	Resetting the Booleans is important, as some of them may not reset by themselves.
		public override void ResetEffects()
		{
			//guardTimer = 0; //	Not resetting this anymore since the function stops working completely when doing so.
			hasShield = false;
			hasGlove = false;
			//hasGloveBenefits = false; //	Resetting this nullifies the effect completely. :moyai:
			hasBoot = false;
			//hasBootBenefits = false; //	Resetting this nullifies the effect completely. :moyai:
		}
		
		//	I'm not sure if I need this anymore, but I'll keep it for now.
		public static BlockingPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<BlockingPlayer>();
		}
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (CombatTweaks.Guard.Current && BlockingConfig.Instance.enableGuarding && guardingCooldown == 0)
			{
				if (guardTimer < 40)
				{
					guardTimer += 1;
					//Some test I did..
					/*if (guardTimer == 20)
					{
						Main.NewText("Test for tick 20.");
					}
					if (guardTimer == 40)
					{
						Main.NewText("Test for tick 40.");
					}*/
				}
			}
			if (CombatTweaks.Guard.JustPressed && BlockingConfig.Instance.enableGuarding && guardingCooldown == 0)
			{
				if (CombatTweaksConfigClient.Instance.enableSoundsGuardingRaise)
				{
					SoundEngine.PlaySound(GuardRaise, Player.position);
				}
				if (CombatTweaksConfigClient.Instance.enableScreenshakeGuarding)
				{
					Main.instance.CameraModifiers.Add(shakeWeak);
				}
			}
			if (CombatTweaks.Guard.JustReleased && BlockingConfig.Instance.enableGuarding && guardingCooldown == 0)
			{
				guardTimer = 0;
				if (CombatTweaksConfigClient.Instance.enableSoundsGuardingLower)
				{
					SoundEngine.PlaySound(GuardLower, Player.position);
				}
				if (CombatTweaksConfigClient.Instance.enableScreenshakeGuarding)
				{
					Main.instance.CameraModifiers.Add(shakeWeak);
				}
				guardBashTimer = 0;
			}
			if (CombatTweaks.Guard.Current && CombatTweaks.GuardBash.JustPressed && guardBashCooldown < 1 && BlockingConfig.Instance.enableGuarding && BlockingConfig.Instance.enableGuardBashing)
			{
				if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBash)
				{
					SoundEngine.PlaySound(GuardBash, Player.position);
				}
				if (CombatTweaksConfigClient.Instance.enableScreenshakeGuardingGuardBash)
				{
					Main.instance.CameraModifiers.Add(shakeStrong);
				}
					guardBashTimer = BlockingConfig.Instance.guardBashTimer;
					guardBashCooldown = BlockingConfig.Instance.guardBashCooldown;
			}
			if (CombatTweaks.TogglePotentGuard.JustPressed)
			{
				if (!potentGuarding)
				{
					potentGuarding = true;
					if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlockShield)
					{
						SoundEngine.PlaySound(BlockShield, Player.position);
					}
				}
				else
				{
					potentGuarding = false;
					if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlock)
					{
						SoundEngine.PlaySound(Block, Player.position);
					}
				}
			}
			if (CombatTweaks.ToggleParryCounter.JustPressed)
			{
				if (!parryCounter)
				{
					parryCounter = true;
					if (CombatTweaksConfigClient.Instance.enableSoundsParrying)
					{
						SoundEngine.PlaySound(Parry, Player.position);
					}
				}
				else
				{
					parryCounter = false;
					if (CombatTweaksConfigClient.Instance.enableSoundsParryingAttempt)
					{
						SoundEngine.PlaySound(ParryAttempt, Player.position);
					}
				}
			}
			if (BlockingConfig.Instance.enablePotentGuarding)
			{
				canPotentGuard = true;
			}
			else
			{
				canPotentGuard = false;
			}
			if (CombatTweaks.Parry.JustPressed && parryCooldown == 0 && BlockingConfig.Instance.enableParrying)
			{
				if (CombatTweaksConfigClient.Instance.enableSoundsParryingAttempt)
				{
					SoundEngine.PlaySound(ParryAttempt, Player.position);
				}
				if (CombatTweaksConfigClient.Instance.enableScreenshakeParrying)
				{
					Main.instance.CameraModifiers.Add(shakeModerate);
				}
				if (parryTimer <= 0) //If less than or equal to 0.
				{
					parryTimer = BlockingConfig.Instance.parryTimer; //Set the Parry Timer to the configured value.
					parryCooldown = BlockingConfig.Instance.parryCooldown;
					if (hasGloveBenefits && BlockingConfig.Instance.enableGloveBenefits) //If wearing Gloves, then set the Parry Timer to the configured value.
					{
						parryTimer += BlockingConfig.Instance.gloveBenefitsParryTimer;
					}
				}
			}
		}

		public override void PostUpdateMiscEffects()
		{
			//	Guarding
			if (guardTimer > 0)
			{
				Player.endurance += BlockingConfig.Instance.blockingPotency;
				Player.accRunSpeed *= BlockingConfig.Instance.guardingMoveSpeed;
				Player.maxRunSpeed *= BlockingConfig.Instance.guardingMoveSpeed;
				Player.velocity.X *= 0.95f; //	This is here to prevent usage of Speed items like the Hermes Boots or the Speedbooster from Metroid Mod.
				Player.delayUseItem = true;
			}
			if (guardingCooldown > 0)
			{
				guardingCooldown--;
			}
			
			//	Parrying
			if (parryTimer > 0)
			{
				parryTimer--;
			}
			if (parryCooldown > 0)
			{
				parryCooldown--;
			}
			if (parryCounterCooldown > 0)
			{
				parryCounterCooldown--;
			}
			
			//	Guard Bashing
			if (guardBashing)
			{
				Player.thorns = BlockingConfig.Instance.guardBashingPotency;
			}
			if (guardBashTimer > 0)
			{
				guardBashTimer--;
				guardBashing = true;
			}
			else
			{
				guardBashing = false;
			}
			if (guardBashCooldown > 0)
			{
				guardBashCooldown--;
			}
			
			//	Shield Equipped
			if (guardTimer > 0 && hasShield)
			{
				Player.endurance += BlockingConfig.Instance.shieldBlockingPotency;
			}
			
			//	Glove Equipped
			if (hasGlove && BlockingConfig.Instance.enableGloveBenefits)
			{
				hasGloveBenefits = true;
			}
			else
			{
				hasGloveBenefits = false;
			}
			if (guardTimer > 0 && BlockingConfig.Instance.enableGloveBenefits && BlockingConfig.Instance.gloveBenefitsBlockingPotency > 0)
			{
				Player.endurance += BlockingConfig.Instance.gloveBenefitsBlockingPotency;
			}
			
			//	Boot Equipped
			if (hasBoot && BlockingConfig.Instance.enableBootBenefits)
			{
				hasBootBenefits = true;
			}
			else
			{
				hasBootBenefits = false;
			}
			if (hasBootBenefits && guardTimer > 0)
			{
				Player.moveSpeed += BlockingConfig.Instance.bootBenefitsMoveSpeed;
			}
		}
		
		public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
			var damage = (int)modifiers.FinalDamage.Flat;
			var hitDirection = modifiers.HitDirection;
			//	Guarding
			if (guardTimer > 0)
			{
				if (!hasShield && parryTimer == 0)
				{
					modifiers.DisableSound();
					//	Potent Guarding
					if (potentGuarding && canPotentGuard && !BlockingConfig.Instance.potentGuardingRequiresShield && Player.statMana >= damage - Player.statDefense)
					{
						Player.statMana -= damage - Player.statDefense;
						Player.velocity.X = 5f * hitDirection;
						Player.velocity.Y = -3f;
						OnPotentBlock();
					}
					//	No Mana left for Potent Guarding. Normal Guarding.
					else
					{
						Player.velocity.X = 5f * hitDirection;
						Player.velocity.Y = -3f;
						OnBlock();
					}
				}
				
				//	Shield Guarding
				if (hasShield && parryTimer == 0)
				{
					modifiers.DisableSound();
					//	Potent Shield Guarding.
					if (potentGuarding && canPotentGuard && Player.statMana >= damage - Player.statDefense)
					{
						Player.velocity.X = 5f * hitDirection;
						Player.velocity.Y = -3f;
						Player.statMana -= damage - Player.statDefense;
						OnPotentBlockShield();
					}
					//	No Mana left to Potently Shield Guard.
					else
					{
						Player.velocity.X = 5f * hitDirection;
						Player.velocity.Y = -3f;
						OnBlockShield();
					}
				}
			}
		}

		public override bool FreeDodge(Player.HurtInfo info)
		{
			//	Parrying.
			if (parryTimer > 0)
			{
				info.SoundDisabled = true;
				OnParry();
				return true;
			}
			return false;
		}
		
		
		//	Immune Time and received damage is only after PreHurt, so the Immune Time scripts must be here, in the PostHurt Method. (Using the Hurt Method will not work.)
		public override void PostHurt(Player.HurtInfo info)
		{
			//	Guarding
			if (guardTimer > 0 && !hasShield && parryTimer == 0)
			{
				Player.immune = true;
				Player.immuneTime = BlockingConfig.Instance.blockingImmuneTime;
				guardingCooldown = BlockingConfig.Instance.guardingCooldown;
			}
			//	Shield Guarding
			if (guardTimer > 0 && hasShield && parryTimer == 0)
			{
				Player.immune = true;
				Player.immuneTime = BlockingConfig.Instance.blockingImmuneTime;
				guardingCooldown = BlockingConfig.Instance.guardingCooldown;
			}
		}
		
		public void OnBlock()
		{
			if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlock)
			{
				SoundEngine.PlaySound(Block, Player.position);
			}
			guardingCooldown = BlockingConfig.Instance.guardingCooldown;
		}
		public void OnPotentBlock()
		{
			Player.immune = true;
			Player.immuneTime = BlockingConfig.Instance.blockingImmuneTime;
			if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlock)
			{
				SoundEngine.PlaySound(Block, Player.position);
			}
			guardingCooldown = BlockingConfig.Instance.guardingCooldown;
		}
		public void OnBlockShield()
		{
			if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlockShieldBroken)
			{
				SoundEngine.PlaySound(BlockShield with {Pitch = +0.25f, Volume = 1f}, Player.position);
			}
			guardingCooldown = BlockingConfig.Instance.guardingCooldown;
		}
		public void OnPotentBlockShield()
		{
			if (CombatTweaksConfigClient.Instance.enableSoundsGuardingBlockShield)
			{
				SoundEngine.PlaySound(BlockShield, Player.position);
			}
			Player.immune = true;
			Player.immuneTime = BlockingConfig.Instance.blockingImmuneTime;
			potentGuardingCooldown = BlockingConfig.Instance.potentGuardingCooldown;
		}
		public void OnParry()
		{
			if (CombatTweaksConfigClient.Instance.enableSoundsParrying)
			{
				SoundEngine.PlaySound(Parry, Player.position);
			}
			if (CombatTweaksConfigClient.Instance.enableScreenshakeParrying)
			{
					Main.instance.CameraModifiers.Add(shakeModerate);
			}
			Player.immune = true;
			Player.immuneTime = BlockingConfig.Instance.parryImmuneTime;
			parryCooldown = BlockingConfig.Instance.parryCooldown;
			if (parryCounterCooldown == 0 && BlockingConfig.Instance.enableParryCounters && parryCounter)
			{
				Player.AddBuff(BuffID.ParryDamageBuff, BlockingConfig.Instance.parryCounterTime);
				parryCounterCooldown = BlockingConfig.Instance.parryCounterCooldown;
			}
		}
		
		//	Animations
		public override void PostUpdate()
		{
			if (guardTimer >= 1)
			{
				Player.bodyFrame.Y = Player.bodyFrame.Height * 10;
			}
			if (guardTimer >= 10)
			{
				Player.bodyFrame.Y = Player.bodyFrame.Height * 11;
			}
			if (parryTimer >= 1)
			{
				Player.bodyFrame.Y = Player.bodyFrame.Height * 1;
			}
			if (parryTimer >= 4)
			{
				Player.bodyFrame.Y = Player.bodyFrame.Height * 2;
			}
			if (parryTimer >= 7)
			{
				Player.bodyFrame.Y = Player.bodyFrame.Height * 3;
			}
			if (parryTimer >= 10)
			{
				Player.bodyFrame.Y = Player.bodyFrame.Height * 4;
			}
		}
		
		//	Sounds
		//	Question: Why declare the audio like this?
		//	Answer: A simple step in Code Optimization. If we were to declare this sound many times over in different places, it would get messy very quickly.
		public static readonly SoundStyle GuardRaise = new SoundStyle("CombatTweaks/Assets/Sounds/GuardRaise");
		public static readonly SoundStyle GuardLower = new SoundStyle("CombatTweaks/Assets/Sounds/GuardLower");
		public static readonly SoundStyle GuardBash = new SoundStyle("CombatTweaks/Assets/Sounds/GuardBash");
		public static readonly SoundStyle ParryAttempt = new SoundStyle("CombatTweaks/Assets/Sounds/ParryAttempt");
		public static readonly SoundStyle Parry = new SoundStyle("CombatTweaks/Assets/Sounds/Parry");
		public static readonly SoundStyle Block = new SoundStyle("CombatTweaks/Assets/Sounds/Block");
		public static readonly SoundStyle BlockShield = new SoundStyle("CombatTweaks/Assets/Sounds/BlockShield");
	}
}