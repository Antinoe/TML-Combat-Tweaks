using Terraria.ModLoader;
using CombatTweaks.Common.Configs;

namespace CombatTweaks.Common.Systems{
	public class CombatTweaksKeybinds : ModSystem
	{
		public static ModKeybind Dodge{get;private set;}
		public static ModKeybind Guard{get;private set;}
		public static ModKeybind Parry{get;private set;}
		public static ModKeybind RevUp{get;private set;}
		public override void Load(){
			Dodge = KeybindLoader.RegisterKeybind(Mod,"Dodge","LeftControl");
			Guard = KeybindLoader.RegisterKeybind(Mod,"Guard","LeftAlt");
			Parry = KeybindLoader.RegisterKeybind(Mod,"Parry","LeftAlt");
			RevUp = KeybindLoader.RegisterKeybind(Mod,"RevUp","Z");
		}
		public override void Unload(){
			Dodge = null;
			Guard = null;
			Parry = null;
			RevUp = null;
		}
	}
}
