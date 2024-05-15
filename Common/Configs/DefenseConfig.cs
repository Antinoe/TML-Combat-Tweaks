using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CombatTweaks.Common.Configs{
	public class DefenseConfig : ModConfig{
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
		
		[BackgroundColor(155, 255, 255)]
		[Label("[i:IronChainmail] Defense Effectiveness")]
		[Tooltip("Modify the effectiveness of Defense.\n(A value of 2 makes Defense twice as effective.)")]
		[Range(0.25f,5f)]
		[Increment(0.25f)]
		[Slider]
		[DefaultValue(1f)]
		public float DefenseEffectiveness;
		
		[BackgroundColor(155, 255, 255)]
		[Label("[i:GoldChainmail] Defense Multiplier")]
		[Tooltip("Multiplies the Defense points of every client.\n(10 Defense, with a value of 2, results in 20 Defense.)\n(Use this if Defense Effectiveness is hindered by other mods.)")]
		[Range(1,5)]
		[Increment(1)]
		[Slider]
		[DefaultValue(1)]
		public int DefenseMultiplier;
		
		[BackgroundColor(255, 200, 255)]
		[Label("[i:Heart] Health Pickups")]
		[Tooltip("Should a DOOM-like Health mechanic be introduced?\n(Killing monsters with Melee weapons will cause Heart Pickups to spew out.)")]
		[DefaultValue(false)]
		public bool HealthPickups;
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:HuntressBuckler] Armor Pickups")]
		[Tooltip("Should DOOM-like Armor mechanics be introduced?\n(Monsters set on fire will drop Armor Shards.\nArmor Points act as extra Life and block debuffs.)")]
		[DefaultValue(true)]
		public bool ArmorPickups;
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:TitanPotion][i:HuntressBuckler] Armor Knockback")]
		[Tooltip("Should knockback be applied to clients that have Armor Points?\n(WARNING: The physics still need work. Enable at your own discretion.)")]
		[DefaultValue(false)]
		public bool ArmorKnockback;
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:StoneBlock][i:HuntressBuckler] Armor Shard Amount")]
		[Tooltip("How many Armor Points should each Armor Shard grant?")]
		[Range(1,20)]
		[Increment(1)]
		[Slider]
		[DefaultValue(3)]
		public int ArmorPickupAmount;
		
		[BackgroundColor(255, 255, 255)]
		[Label("[i:MagmaStone][i:Stopwatch][i:HuntressBuckler] Fire Timer")]
		[Tooltip("How long should the timer be for flaming monsters to drop an Armor Shard?")]
		[Range(30,240)]
		[Increment(30)]
		[Slider]
		[DefaultValue(30)]
		public int FireTimer;
		
		//	Couldn't get values past 2 working.
		/*
		[BackgroundColor(255, 255, 255)]
		[Label("[i:HuntressBuckler] Armor Multiplier")]
		[Tooltip("How much Max Armor should clients have relative to their Defense?\n(10 Defense with a value of 3 will equal 30 Max Armor.)")]
		[Range(1,5)]
		[Increment(1)]
		[Slider]
		[DefaultValue(3)]
		public int ArmorMultiplier;
		*/
		
		[BackgroundColor(255, 200, 255)]
		[Label("[i:LifeCrystal] Extra Life Mode")]
		[Tooltip("Should the hearts you have count as Extra Lives?\n(Hearts will save you from death, but will be consumed in the process.)")]
		[DefaultValue(false)]
		public bool ExtraLifeMode;
		
		[BackgroundColor(255, 255, 155)]
		[Label("[i:PaladinsShield] Minimum Damage Invulnerability")]
		[Tooltip("Should clients be completely protected from minimal damage?\n(Damage that is no more than 1.)")]
		[DefaultValue(false)]
		public bool MinDamageImmunity;
		
		[BackgroundColor(255, 255, 155)]
		[Label("[i:CrossNecklace] No Immunity Frames")]
		[Tooltip("Should Immune Time be disabled entirely?\n(I'd strongly suggest pairing this with NPC Attack Cooldowns.)")]
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
		
		[BackgroundColor(255, 255, 155)]
		[Label("[i:CrossNecklace] NPC Immunity Frames")]
		[Tooltip("Should monsters have Immune Time similar to players?")]
		[DefaultValue(false)]
		public bool NPCImmuneTime;
		
		[BackgroundColor(255, 0, 0)]
		[Label("[i:IronBroadsword] NPC Attack Cooldowns")]
		[Tooltip("Should monsters have attack cooldowns similar to players?\n(I'd recommend pairing this with No Immunity Frames.)")]
		[DefaultValue(false)]
		public bool NPCAttackCooldowns;
		
		[BackgroundColor(255, 0, 0)]
		[Label("[i:GuideVoodooDoll] Disable Passive Contact Damage")]
		[Tooltip("Should monsters deal no damage when standing still?\n(Realistically, yes.)")]
		[DefaultValue(false)]
		public bool LogicalContactDamage;
		
		[BackgroundColor(255, 0, 0)]
		[Label("No Passive Contact Damage Blacklist")]
		public List<NPCDefinition> noPassiveContactDamageBlacklist = new List<NPCDefinition>{
			new NPCDefinition(NPCID.RockGolem)
		};
	}
}
