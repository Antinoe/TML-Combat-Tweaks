using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.Graphics.CameraModifiers;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using CombatTweaks.Common.Configs;
using CombatTweaks.Common.Systems;

namespace CombatTweaks.Common.Players{
	public class ShieldSlot : ModAccessorySlot{
		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context){
			if(checkItem.shieldSlot > 0){return true;}
			return false;
		}
		public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo){
			if(item.shieldSlot > 0){return true;}
			return false;
		}
		public override bool IsEnabled(){return true;}
		public override bool IsVisibleWhenNotEnabled(){return !IsEmpty;}
		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.SquireShield;
		public override void OnMouseHover(AccessorySlotType context){
			switch(context){
				case AccessorySlotType.FunctionalSlot:
					Main.hoverItemName = "Shield";
					break;
				case AccessorySlotType.VanitySlot:
					Main.hoverItemName = "Social Shield";
					break;
				case AccessorySlotType.DyeSlot:
					Main.hoverItemName = "Shield Dye";
					break;
			}
		}
	}
}
