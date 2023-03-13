using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CombatTweaks
{
    [Label("Server Config")]
    public class CombatTweaksConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static CombatTweaksConfigServer Instance;
		
	[Header("General")]
		
        [Label("[i:BerserkerGlove] Enable Counter Damage")]
        [Tooltip("If true, each time you receive damage, that damage will be added to\nyour Counter Damage Reserve, which you can disperse into your next Melee strike.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableCounterDamage {get; set;}
		
        [Label("[i:CobaltShield] Enable Armor Potency")]
        [Tooltip("If true, the slider below will affect how protective Armor is.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableArmorPotency {get; set;}
        
        [Label("[i:CobaltShield] Armor Potency")]
        [Tooltip("Example: If Armor Potency is 2, then for every 1 point of Armor, 2 Damage will be reduced.\n[Default: 1]")]
        [Slider]
        [DefaultValue(1f)]
        [Range(0.25f, 5f)]
        [Increment(0.25f)]
        public float armorPotencyAmount {get; set;}
    }
}