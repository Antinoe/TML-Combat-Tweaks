using Terraria;
using Terraria.ModLoader;


namespace CombatTweaks
{
	public class CombatTweaks : Mod
	{
		public static ModKeybind RevUp;
		
        public override void Load()
        {
            RevUp = KeybindLoader.RegisterKeybind(this, "Rev Up", "OpenTilde");
        }
        
        public override void Unload()
        {
            RevUp = null;
        }
    }
}