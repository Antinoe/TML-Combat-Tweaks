using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace CombatTweaks
{
    [Label("Server Config: Main")]
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
    [Label("Server Config: Blocking")]
    public class BlockingConfig : ModConfig
    {
        //This is here for the Config to work at all.
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static BlockingConfig Instance;
        
        [Label("[i:HermesBoots] Accessory Whitelist")]
        [Tooltip("Items in this list will provide a special effect upon Parrying.\n(WORK IN PROGRESS)")]
        public List<ItemDefinition> ItemWhitelist = new List<ItemDefinition>();
        
        [Label("[i:WoodenArrow] Projectile Blacklist")]
        [Tooltip("Projectiles in this list cannot be Parried.\n(WORK IN PROGRESS)")]
        public List<ProjectileDefinition> ProjectileBlacklist = new List<ProjectileDefinition>();
        
        [Label("[i:GuideVoodooDoll][i:TitanGlove] NPC Guard Whitelist")]
        [Tooltip("NPCs in this list have a chance of Guarding against damage.")]
        public List<NPCDefinition> NPCGuardWhitelist = new List<NPCDefinition>();
        
        [Label("[i:TitanGlove] NPC Guard Chance")]
        [Tooltip("The chance Whitelisted NPCs will Guard against incoming damage.\n[Default: 4]")]
        [Slider]
        [DefaultValue(4)]
        [Range(1, 10)]
        [Increment(1)]
        public int npcGuardChance {get; set;}
        
        [Label("[i:GuideVoodooDoll][i:FeralClaws] NPC Parry Whitelist")]
        [Tooltip("NPCs in this list have a chance of Parrying damage.")]
        public List<NPCDefinition> NPCParryWhitelist = new List<NPCDefinition>
            {
                new NPCDefinition(NPCID.BoneLee)
            };
        
        [Label("[i:FeralClaws] NPC Parry Chance")]
        [Tooltip("The chance Whitelisted NPCs will Parry incoming damage.\n[Default: 10]")]
        [Slider]
        [DefaultValue(10)]
        [Range(1, 10)]
        [Increment(1)]
        public int npcParryChance {get; set;}
        
        [Label("[i:GuideVoodooDoll][i:TitanGlove][i:CobaltShield] NPC Shield Guard Whitelist")]
        [Tooltip("NPCs in this list have a chance of Shield Guarding against damage.")]
        public List<NPCDefinition> NPCShieldGuardWhitelist = new List<NPCDefinition>
            {
                new NPCDefinition(NPCID.DD2GoblinT2),
                new NPCDefinition(NPCID.DD2GoblinT3)
            };
        
        [Label("[i:TitanGlove][i:CobaltShield] NPC Shield Guard Chance")]
        [Tooltip("The chance Whitelisted NPCs will Shield Guard against incoming damage.\n[Default: 2]")]
        [Slider]
        [DefaultValue(2)]
        [Range(1, 10)]
        [Increment(1)]
        public int npcShieldGuardChance {get; set;}
        
    [Header("General")]
        
        [Label("[i:TitanGlove][i:FleshKnuckles] Enable Guarding")]
        [Tooltip("If false, Players cannot Guard or Guard Bash.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableGuarding {get; set;}
        
        [Label("[i:TitanGlove][i:CobaltShield] Enable Potent Guarding")]
        [Tooltip("If false, Guarding cannot absorb damage at the cost of Mana.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enablePotentGuarding {get; set;}
        
        [Label("[i:TitanGlove] Blocking Potency")]
        [Tooltip("The percentage of damage Guarding reduces.\n[Default: 0.6]")]
        [Slider]
        [DefaultValue(0.60f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float blockingPotency {get; set;}
        
        [Label("[i:TitanGlove][i:ThornsPotion] Thorns Potency")]
        [Tooltip("The percentage of thorns Guarding applies.\n[Default: 0.05]")]
        [Slider]
        [DefaultValue(0.05f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float thornsPotency {get; set;}
        
        [Label("[i:CrossNecklace] Blocking Immune Time")]
        [Tooltip("How long Players are immune after Blocking.\n[Default: 40]")]
        [Slider]
        [DefaultValue(40)]
        [Range(0, 120)]
        [Increment(5)]
        public int blockingImmuneTime {get; set;}
        
        [Label("[i:Stopwatch] Guarding Cooldown")]
        [Tooltip("How long until Guarding may be performed again after receiving damage.\n[Default: 0]")]
        [Slider]
        [DefaultValue(0)]
        [Range(0, 360)]
        [Increment(10)]
        public int guardingCooldown {get; set;}
        
        [Label("[i:TitanGlove][i:HermesBoots] Guarding Movement Speed")]
        [Tooltip("How slowly Players move when Guarding.\n[Default: 0.3]")]
        [Slider]
        [DefaultValue(0.3f)]
        [Range(0.1f, 1f)]
        [Increment(.1f)]
        public float guardingMoveSpeed {get; set;}
        
        [Label("[i:FleshKnuckles] Enable Guard Bashing")]
        [Tooltip("If false, Players can not perform Guard Bashes.\n[Default: Off]\n(WORK IN PROGRESS)")]
        [DefaultValue(false)]
        public bool enableGuardBashing {get; set;}
        
        [Label("[i:FleshKnuckles] Guard Bash Potency")]
        [Tooltip("How strong Guard Bashing is.\n[Default: 0.5]")]
        [Slider]
        [DefaultValue(0.5f)]
        [Range(0f, 10f)]
        [Increment(0.5f)]
        public float guardBashingPotency {get; set;}
        
        [Label("[i:FleshKnuckles][i:Stopwatch] Guard Bash Timer")]
        [Tooltip("How long Guard Bashing is active.\n[Default: 10]")]
        [Slider]
        [DefaultValue(10)]
        [Range(0, 100)]
        [Increment(5)]
        public int guardBashTimer {get; set;}
        
        [Label("[i:FleshKnuckles][i:Stopwatch] Guard Bash Cooldown")]
        [Tooltip("How long until Players may perform a Guard Bash again.\n[Default: 40]")]
        [Slider]
        [DefaultValue(40)]
        [Range(0, 100)]
        [Increment(5)]
        public int guardBashCooldown {get; set;}
        
    [Header("Shields")]
        
        [Label("[i:CobaltShield] Potent Guarding requires Shield")]
        [Tooltip("If false, Potent Guarding can be performed without a Shield.\n[Default: Om]")]
        [DefaultValue(true)]
        public bool potentGuardingRequiresShield {get; set;}
        
        [Label("[i:CobaltShield] Shield Blocking Potency")]
        [Tooltip("Additional percentage of damage Shield Guarding reduces when Potent Guarding is inactive.\n[Default: 0.1]")]
        [Slider]
        [DefaultValue(0.1f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float shieldBlockingPotency {get; set;}
        
        [Label("[i:CobaltShield][i:ThornsPotion] Shield Thorns Potency")]
        [Tooltip("Additional percentage of thorns Shield Guarding applies.\n[Default: 0.1]")]
        [Slider]
        [DefaultValue(0.1f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float shieldThornsPotency {get; set;}
        
        [Label("[i:CobaltShield][i:Stopwatch] Potent Guarding Cooldown")]
        [Tooltip("How long until Guarding may be performed again.\n[Default: 0]")]
        [Slider]
        [DefaultValue(0)]
        [Range(0, 360)]
        [Increment(10)]
        public int potentGuardingCooldown {get; set;}
        
        [Label("[i:CobaltShield][i:LifeCrystal] Shield Life")]
        [Tooltip("How much extra Max Life shields grant (per 1 Defense).\n[Default: 25]")]
        [Slider]
        [DefaultValue(25)]
        [Range(0, 100)]
        [Increment(5)]
        public int shieldLife {get; set;}
        
    [Header("Parrying")]
        
        [Label("[i:FeralClaws] Enable Parrying")]
        [Tooltip("If false, Players cannot perform Parries.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableParrying {get; set;}
        
        [Label("[i:FeralClaws][i:Stopwatch] Parry Timer")]
        [Tooltip("Time left to initiate a Parry.\n[Default: 10]")]
        [Slider]
        [DefaultValue(10)]
        [Range(0, 50)]
        [Increment(5)]
        public int parryTimer {get; set;}
        
        [Label("[i:FeralClaws][i:CrossNecklace][i:Stopwatch] Parry Immune Time")]
        [Tooltip("How long Players are immune after Parrying.\n[Default: 60]")]
        [Slider]
        [DefaultValue(60)]
        [Range(0, 100)]
        [Increment(5)]
        public int parryImmuneTime {get; set;}
        
        [Label("[i:FeralClaws][i:Stopwatch] Parry Cooldown")]
        [Tooltip("How long until Parries may be performed again.\n[Default: 40]")]
        [Slider]
        [DefaultValue(80)]
        [Range(0, 360)]
        [Increment(10)]
        public int parryCooldown {get; set;}
        
        [Label("[i:FeralClaws][i:Stopwatch][i:IronBroadsword] Enable Parry Counters")]
        [Tooltip("If false, Players cannot perform Parry Counters.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableParryCounters {get; set;}
        
        [Label("[i:FeralClaws][i:Stopwatch][i:IronBroadsword] Parry Counter Time")]
        [Tooltip("Time left to perform a Parry Counter.\n[Default: 40]")]
        [Slider]
        [DefaultValue(40)]
        [Range(0, 360)]
        [Increment(5)]
        public int parryCounterTime {get; set;}
        
        [Label("[i:FeralClaws][i:Stopwatch][i:IronBroadsword] Parry Counter Cooldown")]
        [Tooltip("How long until Parry Counters may be performed again.\n[Default: 0]")]
        [Slider]
        [DefaultValue(0)]
        [Range(0, 360)]
        [Increment(10)]
        public int parryCounterCooldown {get; set;}
        
    [Header("Miscellaneous")]
        
        [Label("[i:PowerGlove] Enable Glove Benefits")]
        [Tooltip("If false, Players will not gain benefits from wearing Gloves.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableGloveBenefits {get; set;}
        
        [Label("[i:PowerGlove][i:CobaltShield] Glove Benefits Blocking Potency")]
        [Tooltip("Additional percentage of damage Guarding reduces with Glove Benefits active.\n[Default: 0.05]")]
        [Slider]
        [DefaultValue(0.05f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float gloveBenefitsBlockingPotency {get; set;}
        
        [Label("[i:PowerGlove][i:FeralClaws][i:Stopwatch] Glove Benefits Parry Timer")]
        [Tooltip("Additional Parry Time granted from Gloves.\n[Default: 5]")]
        [Slider]
        [DefaultValue(5)]
        [Range(0, 50)]
        [Increment(5)]
        public int gloveBenefitsParryTimer {get; set;}
        
        [Label("[i:HermesBoots] Enable Boot Benefits")]
        [Tooltip("If false, Players will not gain benefits from wearing Boots.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableBootBenefits {get; set;}
        
        [Label("[i:HermesBoots] Boot Benefits Movement Speed")]
        [Tooltip("How much Movement Speed is increased when Guarding with Boot Benefits active.\n[Default: 0.75f]")]
        [Slider]
        [DefaultValue(0.35f)]
        [Range(0f, 2f)]
        [Increment(0.05f)]
        public float bootBenefitsMoveSpeed {get; set;}
    }
}