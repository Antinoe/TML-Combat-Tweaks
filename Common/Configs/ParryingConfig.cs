using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CombatTweaks.Common.Configs
{
	public class ParryingConfig : ModConfig
	{
		public static ParryingConfig Instance;
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[Header("ParryingOptions")]
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:Lever] Master Switch")]
		[Tooltip("Turn this off to disable every feature below.")]
		[DefaultValue(true)]
		public bool MasterSwitch;
		
		[BackgroundColor(155, 255, 155)]
		[Label("[i:FeralClaws] Parrying")]
		[Tooltip("Should clients be allowed to parry?")]
		[DefaultValue(true)]
		public bool ParryingToggle;
	}
}
