using Terraria;
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

		/*public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers)
		{
			Main.NewText("ModifyHitNPCWithItem");
			if (counterDamage > 0)
			{
				modifiers.FinalDamage += counterDamage;
				counterDamage -= (int)modifiers.FinalDamage;
				Main.NewText("Counter Damage spent.");
				SoundEngine.PlaySound(SoundID.Run with {Pitch = +0.75f, Volume = 1f}, target.position);
			}
		}*/
		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
		{
			Main.NewText("OnHitNPCWithItem");
			if (counterDamage > 0)
			{
				damageDone += counterDamage;
				counterDamage -= (int)damageDone;
				Main.NewText("Counter Damage spent.");
				SoundEngine.PlaySound(SoundID.Run with {Pitch = +0.75f, Volume = 1f}, target.position);
			}
		}
		
		public override void PostHurt(Player.HurtInfo info)
		{
			counterDamageReserve += (int) info.Damage;
		}
	}
}
