using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CombatTweaks
{
    [Label("Client Config")]
    public class CombatTweaksConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static CombatTweaksConfigClient Instance;
		
	[Header("General")]
		
        [Label("[i:BerserkerGlove] Automatic Rev Up")]
        [Tooltip("If true, Counter Damage will automatically be transfered from your reserve.\n[Default: On]")]
        [DefaultValue(true)]
        public bool automaticRevUp {get; set;}
    }
}