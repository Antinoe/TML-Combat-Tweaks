using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

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

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			Main.NewText("ModifyHitNPC");
			if (counterDamage > 0)
			{
				damage += counterDamage;
				counterDamage -= damage;
				Main.NewText("Counter Damage spent.");
				SoundEngine.PlaySound(SoundID.Run with {Pitch = +0.75f, Volume = 1f}, target.position);
			}
		}
		public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
		{
			Main.NewText("ModifyHitPvp");
			if (counterDamage > 0)
			{
				damage += counterDamage;
				counterDamage -= damage;
				Main.NewText("Counter Damage spent.");
				SoundEngine.PlaySound(SoundID.Run with {Pitch = +0.75f, Volume = 1f}, target.position);
			}
		}
		
		//	I probably want to use PostHurt instead of PreHurt because PostHurt considers the damage that has already been applied.
		/*public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
			counterDamageReserve += damage;
			return true;
		}*/
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
		{
			counterDamageReserve += (int)damage;
		}
	}
}