using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
namespace TrueTooltips
{
    class Mod0 : Mod
    {
        bool tp;
        UserInterface ui = new UserInterface();
        public override void Load()
        {
            GlobalItem0.ca.SetDefaults();
            ui.SetState(new UIState0());
        }
        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> il)
        {
            var mti = il.FindIndex(_ => _.Name == "Vanilla: Mouse Text");

            if (mti > -1)
            {
                il.Insert(mti, new LegacyGameInterfaceLayer("", () =>
                {
                    ui.Draw(Main.spriteBatch, new GameTime());
                    return true;
                }, InterfaceScaleType.UI));
            }
        }
        public override void UpdateUI(GameTime gt) => ui?.Update(gt);
        public override void PostUpdateInput()
        {
            if (ModContent.GetInstance<Config>()?.tp != null)
            {
                if (!ModContent.GetInstance<Config>().tp)
                {
                    Main.cursorAlpha = 0.6f;
                    Main.cursorColorDirection = Main.mouseTextColorChange = 0;
                    Main.mouseTextColor = 255;
                    tp = false;
                }
                if (ModContent.GetInstance<Config>().tp && !tp)
                {
                    Main.cursorColorDirection = 1;
                    tp = true;
                }
            }
        }
        public override void Unload()
        {
            Main.cursorColorDirection = 1;
            ModContent.GetInstance<Config>().tp = true;
        }
    }
}