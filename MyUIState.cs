﻿namespace TrueTooltips
{
    using Microsoft.Xna.Framework;
    using Terraria.GameInput;
    using Terraria.UI.Chat;
    using static Terraria.Main;
    using static TrueTooltips.MyGlobalItem;

    class MyUIState : Terraria.UI.UIState
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            int x = mouseX + (ThickMouse ? 16 : 10),
                y = mouseY + (ThickMouse ? 16 : 10);

            for(int i = 0, num = 20; i < 10; i++)
            {
                if(mouseX >= num && mouseX <= num + hotbarScale[i] * inventoryBackTexture.Width && mouseY > (int)(19 + 22 * (1 - hotbarScale[i])) && mouseY < (int)(21 + 22 * (1 - hotbarScale[i])) + hotbarScale[i] * inventoryBackTexture.Height && !(LocalPlayer.channel || LocalPlayer.ghost || LocalPlayer.hbLocked || LocalPlayer.inventory[i].type == 0 || PlayerInput.IgnoreMouseInterface || playerInventory))
                {
                    ChatManager.DrawColorCodedStringWithShadow(spriteBatch, fontMouseText, LocalPlayer.inventory[i].HoverName, new Vector2(x, y), TextPulse(RarityColor(LocalPlayer.inventory[i])), 0, Vector2.Zero, Vector2.One);

                    hoverItemName = "";
                }

                num += (int)(hotbarScale[i] * inventoryBackTexture.Width) + 4;
            }

            for(int i = 400; i >= 0; i--)
            {
                Rectangle itemTexDim = itemTexture[item[i].type].Bounds;

                if(item[i].active && new Rectangle((int)item[i].position.X + item[i].width / 2 - itemTexDim.Width / 2, (int)item[i].position.Y + item[i].height - itemTexDim.Height, itemTexDim.Width, itemTexDim.Height).Contains((int)screenPosition.X + mouseX, (int)screenPosition.Y + mouseY) && !mouseText)
                {
                    Vector2 itemNameLength = fontMouseText.MeasureString(item[i].HoverName);

                    ChatManager.DrawColorCodedStringWithShadow(spriteBatch, fontMouseText, item[i].HoverName, new Vector2(x + itemNameLength.X + 4 > screenWidth ? screenWidth - itemNameLength.X - 4 : x, y + itemNameLength.Y + 4 > screenHeight ? screenHeight - itemNameLength.Y - 4 : y), TextPulse(RarityColor(item[i])), 0, Vector2.Zero, Vector2.One);

                    PlayerInput.SetZoom_Test();
                    PlayerInput.SetZoom_UI();

                    mouseText = true;
                }
            }
        }
    }
}