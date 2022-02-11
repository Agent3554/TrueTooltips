using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace TrueTooltips
{
    class MyMod : Mod
    {
        readonly UserInterface ui = new UserInterface();

        public override void Load()
        {
            MyGlobalItem.CurrentAmmo.SetDefaults();

            ui.SetState(new MyUIState());
        }

        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> layers)
        {
            int mouseText = layers.FindIndex(_ => _.Name == "Vanilla: Mouse Text");

            if (mouseText >= 0)
            {
                layers.Insert(mouseText, new LegacyGameInterfaceLayer("", () =>
                {
                    ui.Draw(Main.spriteBatch, new GameTime());

                    return true;
                }, InterfaceScaleType.UI));
            }
        }

        public override void UpdateUI(GameTime gameTime) => ui?.Update(gameTime);

        public override void PostUpdateInput()
        {
            if (!ModContent.GetInstance<Config>().textPulse)
            {
                Main.cursorAlpha = 0.6f;
                Main.mouseTextColor = 255;
            }
        }
    }
}