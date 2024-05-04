using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CombatTweaks.Common.Configs
{
	public class DefenseConfig : ModConfig
	{
		public static DefenseConfig Instance;
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[Header("DefenseOptions")]
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:Lever] Master Switch")]
		[Tooltip("Turn this off to disable every feature below.")]
		[DefaultValue(true)]
		public bool MasterSwitch;
		
		[BackgroundColor(155, 255, 255)]
		[Label("[i:CobaltShield] Initial Damage Reduction")]
		[Tooltip("Modify how much Damage Reduction clients have by default.\n(A value of 0.75 reduces damage by 75%.)")]
		[Range(0f,1f)]
		[Increment(0.05f)]
		[Slider]
		[DefaultValue(0f)]
		public float InitialDamageReduction;
		
		[BackgroundColor(255, 155, 255)]
		[Label("[i:ObsidianShield] Defense Effectiveness")]
		[Tooltip("Modify the effectiveness of Defense.\n(A value of 2 makes Defense twice as effective.)")]
		[Range(0.25f,5f)]
		[Increment(0.25f)]
		[Slider]
		[DefaultValue(1f)]
		public float DefenseEffectiveness;
		
		[BackgroundColor(255, 155, 255)]
		[Label("[i:ObsidianShield] Defense Multiplier")]
		[Tooltip("Multiplies the Defense points of every client.\n(10 Defense, with a value of 2, results in 20 Defense.)\n(Use this if Defense Effectiveness is hindered by other mods.)")]
		[Range(1,5)]
		[Increment(1)]
		[Slider]
		[DefaultValue(1)]
		public int DefenseMultiplier;
		
		[BackgroundColor(255, 255, 155)]
		[Label("[i:PaladinsShield] Minimum Damage Invulnerability")]
		[Tooltip("Should clients be completely protected from minimal damage?\n(Damage that is no more than 1.)")]
		[DefaultValue(false)]
		public bool MinDamageImmunity;
		
		[BackgroundColor(255, 255, 155)]
		[Label("[i:CrossNecklace] No Immunity Frames")]
		[Tooltip("Should Immune Time be disabled entirely?")]
		[DefaultValue(false)]
		public bool NoImmuneTime;
		
		[BackgroundColor(255, 255, 155)]
		[Label("[i:CrossNecklace] Immunity Frame Subtraction")]
		[Tooltip("Whenever Immunity Frames are activated, this kicks in and removes the configured value every tick.\n(A value of 1 means half the Immune Time.)")]
		[Range(0,3)]
		[Increment(1)]
		[Slider]
		[DefaultValue(0)]
		public int ImmuneTimeSubtraction;
	}
}
