using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CombatTweaks.Common.Configs{
	public class GuardingConfig : ModConfig{
		public static GuardingConfig Instance;
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[Header("GuardingOptions")]
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:Lever] Master Switch")]
		[Tooltip("Turn this off to disable every feature below.")]
		[DefaultValue(true)]
		public bool MasterSwitch;
		
		[BackgroundColor(255, 155, 155)]
		[Label("[i:SquireShield] Shield Slot")]
		[Tooltip("Should clients have an accessory slot dedicated to shields?")]
		[DefaultValue(true)]
		public bool ShieldSlotToggle;
		
		[BackgroundColor(155, 155, 255)]
		[Label("[i:TitanGlove] Guarding")]
		[Tooltip("Should clients be allowed to guard?")]
		[DefaultValue(true)]
		public bool GuardingToggle;
		
		[BackgroundColor(155, 155, 255)]
		[Label("[i:TitanGlove][i:CobaltShield] Guarding Damage Reduction")]
		[Tooltip("How effective should guarding be?\n(A value of 0.25 reduces 25% of damage.)")]
		[Range(0f,1f)]
		[Increment(0.05f)]
		[Slider]
		[DefaultValue(0.5f)]
		public float GuardingDamageReduction;
		
		[BackgroundColor(155, 155, 255)]
		[Label("[i:TitanGlove][i:ObsidianShield][i:ManaCrystal] Shield-Guarding Damage Multiplier")]
		[Tooltip("How much more damage should be dealt to Mana while a shield is raised?")]
		[Range(1,10)]
		[Increment(1)]
		[Slider]
		[DefaultValue(4)]
		public int ShieldGuardingDamageMultiplier;
		
		//	Redacting this for now..
		/*
		[BackgroundColor(155, 155, 255)]
		[Label("[i:ManaCrystal][i:IronChainmail][i:SquireShield] Mana Guarding Behavior")]
		[Tooltip("1 - Guarding\n2 - Guarding with Defense\n3 - Guarding with Shield\n4 - Defense\n5 - Shield")]
		[Range(1,5)]
		[Increment(1)]
		[Slider]
		[DefaultValue(3)]
		public int ManaGuardingBehavior;
		*/
		
		//	Not implemented yet.
		/*
		[BackgroundColor(155, 155, 255)]
		[Label("[i:ManaCrystal] Mana Regen Delay")]
		[Tooltip("How long should Mana Regeneration be disabled after absorbing damage?")]
		[Range(0,360)]
		[Increment(30)]
		[Slider]
		[DefaultValue(60)]
		public int ManaRegenDelay;
		*/
		
		[BackgroundColor(155, 155, 255)]
		[Label("[i:HeroShield] Shield Thorns")]
		[Tooltip("What percentage of Thorns should shields have?")]
		[Range(0f,1f)]
		[Increment(0.05f)]
		[Slider]
		[DefaultValue(0f)]
		public float ShieldThorns;
	}
}
