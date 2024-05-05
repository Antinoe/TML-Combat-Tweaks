using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CombatTweaks.Common.Configs{
	public class DodgingConfig : ModConfig{
		public static DodgingConfig Instance;
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[Header("DodgingOptions")]
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:Lever] Master Switch")]
		[Tooltip("Turn this off to disable every feature below.")]
		[DefaultValue(true)]
		public bool MasterSwitch;
		
		[BackgroundColor(100, 100, 100)]
		[Label("[i:Tabi] Dodging")]
		[Tooltip("Should clients be allowed to perform a dodge?")]
		[DefaultValue(true)]
		public bool DodgingToggle;
	}
}
