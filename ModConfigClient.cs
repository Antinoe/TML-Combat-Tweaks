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
        
    [Header("Visuals")]
        
        [Label("[i:TitanGlove] Guarding Screenshake")]
        [Tooltip("If false, you will not experience Screenshake upon Guarding.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableScreenshakeGuarding {get; set;}
        
        [Label("[i:TitanGlove] Guarding Screenshake Amount")]
        [Tooltip("The intensity of Screenshake while Raising and Lowering your Guard.\n[Default: 1f]")]
        [Slider]
        [DefaultValue(1f)]
        [Range(0.10f, 3f)]
        [Increment(0.10f)]
        public float screenShakeAmountGuarding {get; set;}
        
        [Label("[i:TitanGlove][i:FleshKnuckles] Guard-Bash Screenshake")]
        [Tooltip("If false, you will not experience Screenshake upon Guard-Bashing.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableScreenshakeGuardingGuardBash {get; set;}
        
        [Label("[i:FeralClaws] Parrying Screenshake")]
        [Tooltip("If false, you will not experience Screenshake upon Parrying.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableScreenshakeParrying {get; set;}
        
        [Label("[i:FeralClaws] Parrying Attempt Screenshake Amount")]
        [Tooltip("The intensity of Screenshake while Attempting Parries.\n[Default: 1f]")]
        [Slider]
        [DefaultValue(1f)]
        [Range(0.10f, 3f)]
        [Increment(0.10f)]
        public float screenShakeAmountParryingAttempt {get; set;}
        
        [Label("[i:FeralClaws] Parrying Screenshake Amount")]
        [Tooltip("The intensity of Screenshake while Succeeding Parries.\n[Default: 2f]")]
        [Slider]
        [DefaultValue(2f)]
        [Range(0.10f, 3f)]
        [Increment(0.10f)]
        public float screenShakeAmountParrying {get; set;}
        
    [Header("Audio")]
        
        [Label("[i:TitanGlove] Guarding Raise Sound")]
        [Tooltip("If false, you will not hear the Guard Raise sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsGuardingRaise {get; set;}
        
        [Label("[i:TitanGlove] Guarding Lower Sound")]
        [Tooltip("If false, you will not hear the Guard Lower sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsGuardingLower {get; set;}
        
        [Label("[i:TitanGlove] Guarding Block Sound")]
        [Tooltip("If false, you will not hear the Guard Block sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsGuardingBlock {get; set;}
        
        [Label("[i:TitanGlove][i:CobaltShield] Guarding Shield-Block Sound")]
        [Tooltip("If false, you will not hear the Guard Shield-Block sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsGuardingBlockShield {get; set;}
        
        [Label("[i:TitanGlove][i:CobaltShield] Guarding Broken Shield-Block Sound")]
        [Tooltip("If false, you will not hear the Guard Broken Shield-Block sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsGuardingBlockShieldBroken {get; set;}
        
        [Label("[i:TitanGlove][i:FleshKnuckles] Guarding Bash Sound")]
        [Tooltip("If false, you will not hear the Guard Bash sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsGuardingBash {get; set;}
        
        [Label("[i:FeralClaws] Parrying Attempt Sound")]
        [Tooltip("If false, you will not hear the Parry Attempt sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsParryingAttempt {get; set;}
        
        [Label("[i:FeralClaws] Parrying Sound")]
        [Tooltip("If false, you will not hear the Parry sound.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableSoundsParrying {get; set;}
    }
}