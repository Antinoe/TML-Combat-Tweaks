using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using CombatTweaks.Common.Players;

//	I'll need to learn more about UI if I want to crunch it down even further.
namespace CombatTweaks.Common.UI.ResourceOverlays{
	public class VanillaLifeOverlay : ModResourceOverlay{
		private Dictionary<string, Asset<Texture2D>> vanillaAssetCache = new();
		private Asset<Texture2D> heartTexture, barsFillingTexture;
		public override void PostDrawResource(ResourceOverlayDrawContext context){
			Asset<Texture2D> asset = context.texture;
			string fancyFolder = "Images/UI/PlayerResourceSets/FancyClassic/";
			string barsFolder = "Images/UI/PlayerResourceSets/HorizontalBars/";
			//	Not sure if I should use `Main.LocalPlayer` or just `Player`.
			//	Example Mod used the former, so I'll go with that for now.
			int armor = Main.LocalPlayer.GetModPlayer<ArmorPlayer>().statArmor;
			//	Every overlay icon is worth 20 points.
			if(context.resourceNumber >= 0.05f * armor){return;}
			if (asset == TextureAssets.Heart || asset == TextureAssets.Heart2){DrawClassicFancyOverlay(context);}
			else if(CompareAssets(asset, fancyFolder + "Heart_Fill") || CompareAssets(asset, fancyFolder + "Heart_Fill_B")){DrawClassicFancyOverlay(context);}
			else if (CompareAssets(asset, barsFolder + "HP_Fill") || CompareAssets(asset, barsFolder + "HP_Fill_Honey")){DrawBarsOverlay(context);}
		}
		private bool CompareAssets(Asset<Texture2D> existingAsset, string compareAssetPath){
			if(!vanillaAssetCache.TryGetValue(compareAssetPath, out var asset)){asset = vanillaAssetCache[compareAssetPath] = Main.Assets.Request<Texture2D>(compareAssetPath);}
			return existingAsset == asset;
		}
		private void DrawClassicFancyOverlay(ResourceOverlayDrawContext context){
			context.texture = heartTexture ??= ModContent.Request<Texture2D>("CombatTweaks/Common/UI/ResourceOverlays/ArmorLifeOverlayClassic");
			context.Draw();
		}
		private void DrawBarsOverlay(ResourceOverlayDrawContext context){
			context.texture = barsFillingTexture ??= ModContent.Request<Texture2D>("CombatTweaks/Common/UI/ResourceOverlays/ArmorLifeOverlayBars");
			context.Draw();
		}
	}
}
