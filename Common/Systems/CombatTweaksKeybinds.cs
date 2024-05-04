using Terraria.ModLoader;

namespace CombatTweaks.Common.Systems{
	public class CombatTweaksKeybinds : ModSystem
	{
		public static ModKeybind Guard{get;private set;}
		public static ModKeybind Parry{get;private set;}
		public static ModKeybind RevUp{get;private set;}
		public override void Load(){
			Guard = KeybindLoader.RegisterKeybind(Mod,"Guard","LeftAlt");
			Parry = KeybindLoader.RegisterKeybind(Mod,"Parry","LeftAlt");
			RevUp = KeybindLoader.RegisterKeybind(Mod,"RevUp","Z");
		}
		public override void Unload(){
			Guard = null;
			Parry = null;
			RevUp = null;
		}
	}
}
