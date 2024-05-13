using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CombatTweaks.Common.Configs;
using CombatTweaks.Common.Players;

namespace CombatTweaks.Content.Items{
	public class BasicPickup : ModItem{
		public override string Texture => "CombatTweaks/Content/Items/ArmorPickup";
		public override void SetStaticDefaults(){
			Item.ResearchUnlockCount = 25;
			ItemID.Sets.IgnoresEncumberingStone[Type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
		}
		public override void SetDefaults(){
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = Item.CommonMaxStack;
			Item.value = 1000;
			Item.rare = ItemRarityID.Cyan;
		}
		public override void PostUpdate(){Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);}
		public override void GrabRange(Player player, ref int grabRange){grabRange = 30;}
		public override bool ItemSpace(Player player) => true;
	}
	public class LifePickup : BasicPickup{
		public virtual int itemLife => 5;
		//	Need to figure out how to get Vanilla textures.
		//public override string Texture => $"Terraria/Images/Item_Heart";
		public override void SetDefaults(){
			base.SetDefaults();
			Item.rare = ItemRarityID.Red;
		}
		public override void PostUpdate(){Item.color = Color.Red; Lighting.AddLight(Item.Center, Color.Red.ToVector3() * 0.55f * Main.essScale);}
		public override bool CanPickup(Player player){
			var item = Item;
			if(player.statLife < player.statLifeMax || player.statLife < player.statLifeMax2){return true;}
			return false;
		}
		public override bool OnPickup(Player player){
			var item = Item;
			CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Color.Green, (item.stack * itemLife), false, false);
			player.statLife += (item.stack * itemLife);
			return false;
		}
	}
	public class ArmorPickup : BasicPickup{
		public virtual int itemArmor => DefenseConfig.Instance.ArmorPickupAmount;
		public override string Texture => "CombatTweaks/Content/Items/ArmorPickup";
		public override void SetDefaults(){
			base.SetDefaults();
			Item.rare = ItemRarityID.Gray;
		}
		public override bool CanPickup(Player player){
			var item = Item;
			ArmorPlayer ap = player.GetModPlayer<ArmorPlayer>();
			if(ap.statArmor < ap.statArmorMax){return true;}
			return false;
		}
		public override bool OnPickup(Player player){
			var item = Item;
			ArmorPlayer ap = player.GetModPlayer<ArmorPlayer>();
			SoundEngine.PlaySound(SoundID.Item52,player.position);
			CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Color.LightGray, (item.stack * itemArmor), false, false);
			if(ap.statArmor <= 0){ap.statArmor = 0;}
			ap.statArmor += (item.stack * itemArmor);
			return false;
		}
	}
}
