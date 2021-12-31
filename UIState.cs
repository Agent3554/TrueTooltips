using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Chat;
using static Terraria.Main;
namespace TrueTooltips
{
    class UIState0 : UIState
    {
        protected override void DrawSelf(SpriteBatch sb)
        {
            var lp = LocalPlayer;
            var num = 20;
            var x = mouseX + (ThickMouse ? 16 : 10);
            var y = mouseY + (ThickMouse ? 16 : 10);

            for (var _ = 0; _ < 10; _++)
            {
                var hbs = hotbarScale[_];

                if (mouseX >= num && mouseX <= num + hbs * inventoryBackTexture.Width && mouseY > (int)(19 + 22 * (1 - hbs)) && mouseY < (int)(21 + 22 * (1 - hbs)) + hbs * inventoryBackTexture.Height && !(lp.channel || lp.ghost || lp.hbLocked || lp.inventory[_].type == 0 || PlayerInput.IgnoreMouseInterface || playerInventory))
                {
                    ChatManager.DrawColorCodedStringWithShadow(sb, fontMouseText, lp.inventory[_].HoverName, new Vector2(x, y), (Color)GlobalItem0.RarityColor(lp.inventory[_]), 0, Vector2.Zero, Vector2.One);
                    hoverItemName = "";
                }
                num += (int)(hbs * inventoryBackTexture.Width) + 4;
            }
            foreach (var _ in item)
            {
                var ms = fontMouseText.MeasureString(_.HoverName);
                var tb = itemTexture[_.type].Bounds;

                if (_.active && new Rectangle((int)_.position.X + _.width / 2 - tb.Width / 2, (int)_.position.Y + _.height - tb.Height, tb.Width, tb.Height).Contains((int)screenPosition.X + mouseX, (int)screenPosition.Y + mouseY) && !mouseText)
                {
                    ChatManager.DrawColorCodedStringWithShadow(sb, fontMouseText, _.HoverName, new Vector2(x + ms.X + 4 > screenWidth ? screenWidth - ms.X - 4 : x, y + ms.Y + 4 > screenHeight ? screenHeight - ms.Y - 4 : y), (Color)GlobalItem0.RarityColor(_), 0, Vector2.Zero, Vector2.One);
                    mouseText = true;
                    PlayerInput.SetZoom_Test();
                    PlayerInput.SetZoom_UI();
                }
            }
        }
    }
}