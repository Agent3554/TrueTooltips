using Microsoft.Xna.Framework;
using static Terraria.ID.Colors;
using static Terraria.Main;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using Terraria.ModLoader;
using Terraria;

namespace TrueTooltips
{
    class MyGlobalItem : GlobalItem
    {
        internal static Item CurrentAmmo { get; private set; } = new Item();

        static Color rarityColor;

        static string hexCopper,
                      hexSilver,
                      hexGold,
                      hexPlat,
                      priceLineText;

        public override bool PreDrawTooltip(Item item, ReadOnlyCollection<TooltipLine> lines, ref int x, ref int y)
        {
            Color bgColor = ModContent.GetInstance<Config>().bgColor;
            string[] lineTexts = lines.Select(_ => _.text).ToArray();

            foreach (string text in lineTexts) if (text == priceLineText) lineTexts[Array.IndexOf(lineTexts, text)] = text.Replace($"[c/{hexCopper}:", "").Replace($"[c/{hexSilver}:", "").Replace($"[c/{hexGold}:", "").Replace($"[c/{hexPlat}:", "").Replace("]", "").TrimEnd();
            if (bgColor.A > 0) Utils.DrawInvBG(spriteBatch, new Rectangle(x - 10, y - 10, (int)lineTexts.Max(_ => fontMouseText.MeasureString(_).X) + 20, (int)lineTexts.Sum(_ => fontMouseText.MeasureString(_).Y) + 15), new Color(bgColor.R * bgColor.A / 255, bgColor.G * bgColor.A / 255, bgColor.B * bgColor.A / 255, bgColor.A));

            return base.PreDrawTooltip(item, lines, ref x, ref y);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> lines)
        {
            Config config = ModContent.GetInstance<Config>();
            Player player = LocalPlayer;

            foreach (Item invItem in player.inventory) if (invItem.active && invItem.ammo == item.useAmmo)
                {
                    CurrentAmmo = invItem;
                    break;
                }
            for (int i = 54; i < 58; i++) if (player.inventory[i].active && player.inventory[i].ammo == item.useAmmo)
                {
                    CurrentAmmo = player.inventory[i];
                    break;
                }

            TooltipLine l1 = new TooltipLine(mod, mod.Name, CurrentAmmo.HoverName) { overrideColor = rarityColor },
                        l2 = lines.Find(_ => _.Name == "Ammo"),
                        l3 = lines.Find(_ => _.Name == "AxePower"),
                        l4 = lines.Find(_ => _.Name == "BaitPower"),
                        l5 = lines.Find(_ => _.Name == "BuffTime"),
                        l6 = lines.Find(_ => _.Name == "Consumable"),
                        l7 = lines.Find(_ => _.Name == "CritChance"),
                        l8 = lines.Find(_ => _.Name == "Damage"),
                        l9 = lines.Find(_ => _.Name == "Defense"),
                        l10 = lines.Find(_ => _.Name == "Equipable"),
                        l11 = lines.Find(_ => _.Name == "EtherianManaWarning"),
                        l12 = lines.Find(_ => _.Name == "Expert"),
                        l13 = lines.Find(_ => _.Name == "Favorite"),
                        l14 = lines.Find(_ => _.Name == "FavoriteDesc"),
                        l15 = lines.Find(_ => _.Name == "FishingPower"),
                        l16 = lines.Find(_ => _.Name == "HammerPower"),
                        l17 = lines.Find(_ => _.Name == "HealLife"),
                        l18 = lines.Find(_ => _.Name == "HealMana"),
                        l19 = lines.Find(_ => _.Name == "Knockback"),
                        l20 = lines.Find(_ => _.Name == "Material"),
                        l21 = lines.Find(_ => _.Name == "NeedsBait"),
                        l22 = lines.Find(_ => _.Name == "PickPower"),
                        l23 = lines.Find(_ => _.Name == "Placeable"),
                        l24 = lines.Find(_ => _.Name == "Quest"),
                        l25 = lines.Find(_ => _.Name == "SetBonus"),
                        l26 = lines.Find(_ => _.Name == "Social"),
                        l27 = lines.Find(_ => _.Name == "SocialDesc"),
                        l28 = lines.Find(_ => _.Name == "SpecialPrice"),
                        l29 = lines.Find(_ => _.Name == "Speed"),
                        l30 = lines.Find(_ => _.Name == "TileBoost"),
                        l31 = lines.Find(_ => _.Name == "UseMana"),
                        l32 = lines.Find(_ => _.Name == "Vanity"),
                        l33 = lines.Find(_ => _.Name == "WandConsumes"),
                        l34 = lines.Find(_ => _.Name == "WellFedExpert");

            if (config.ammoLine && item.useAmmo > 0)
            {
                if (player.HasAmmo(item, true)) lines.Add(l1);
                else lines.Add(new TooltipLine(mod, mod.Name, "No " + (new Dictionary<int, string> { [40] = "Arrow", [71] = "Coin", [97] = "Bullet", [169] = "Sand", [283] = "Dart", [771] = "Rocket", [780] = "Solution", [931] = "Flare" }.TryGetValue(item.useAmmo, out string ammo) ? ammo : Lang.GetItemNameValue(item.useAmmo))) { overrideColor = RarityTrash });
            }
            if (config.priceLine)
            {
                double? price = (double)item.stack * (item.buy ? item.shopCustomPrice > 0 ? item.shopCustomPrice : item.value : item.value / 5);

                int copper = (int)price / 1 % 100,
                    silver = (int)price / 100 % 100,
                    gold = (int)price / 10000 % 100,
                    plat = (int)price / 1000000;

                TextPulse(CoinCopper, out _, out string hex1);
                TextPulse(CoinSilver, out _, out string hex2);
                TextPulse(CoinGold, out _, out string hex3);
                TextPulse(CoinPlatinum, out _, out string hex4);

                if (!(item.type > 70 && item.type < 75)) lines.Add(new TooltipLine(mod, mod.Name, priceLineText = $"{(plat > 0 ? $"[c/{hexPlat = hex4}:{plat} platinum] " : "") + (gold > 0 ? $"[c/{hexGold = hex3}:{gold} gold] " : "") + (silver > 0 ? $"[c/{hexSilver = hex2}:{silver} silver] " : "") + (copper > 0 ? $"[c/{hexCopper = hex1}:{copper} copper]" : "")}"));

                lines.RemoveAll(_ => _.Name == "Price");
            }

            if (config.modName)
            {
                if (CurrentAmmo.modItem != null) l1.text += " - " + CurrentAmmo.modItem.mod.DisplayName;
                if (item.modItem != null) lines.Find(_ => _.Name == "ItemName").text += " - " + item.modItem.mod.DisplayName;
            }
            if (l2 != null) l2.overrideColor = config.Ammo;
            if (l3 != null) l3.overrideColor = config.AxePower;
            if (l4 != null) l4.overrideColor = config.BaitPower;
            if (l5 != null) l5.overrideColor = config.BuffTime;
            if (l6 != null) l6.overrideColor = config.Consumable;
            if (l7 != null) l7.overrideColor = config.CritChance;
            if (l8 != null)
            {
                if (item.useAmmo > 0 && player.HasAmmo(item, true) && config.wpnPlusAmmoDmg) l8.text = l8.text.Replace(l8.text.Split(' ').First(), player.GetWeaponDamage(item) + player.GetWeaponDamage(CurrentAmmo) + "");

                if (ModLoader.GetMod("_ColoredDamageTypes") == null) l8.overrideColor = config.Damage;
            }
            if (l9 != null) l9.overrideColor = config.Defense;
            if (l10 != null) l10.overrideColor = config.Equipable;
            if (l11 != null) l11.overrideColor = config.EtherianManaWarning;
            if (l12 != null) l12.overrideColor = config.Expert;
            if (l13 != null) l13.overrideColor = config.Favorite;
            if (l14 != null) l14.overrideColor = config.FavoriteDesc;
            if (l15 != null) l15.overrideColor = config.FishingPower;
            if (l16 != null) l16.overrideColor = config.HammerPower;
            if (l17 != null) l17.overrideColor = config.HealLife;
            if (l18 != null) l18.overrideColor = config.HealMana;

            float knockback = item.knockBack;

            if (item.summon) knockback += player.minionKB;
            if (item.type == 3106 && player.inventory[player.selectedItem].type == 3106) knockback *= 2 - player.stealth;
            if (item.useAmmo == 1836 || (item.useAmmo == 40 && player.magicQuiver)) knockback *= 1.1f;

            ItemLoader.GetWeaponKnockback(item, player, ref knockback);
            PlayerHooks.GetWeaponKnockback(player, item, ref knockback);

            if (l19 != null)
            {
                if (config.knockbackLine) l19.text = Math.Round(knockback + (item.useAmmo > 0 && player.HasAmmo(item, true) && config.wpnPlusAmmoKb ? player.GetWeaponKnockback(CurrentAmmo, CurrentAmmo.knockBack) : 0), 2) + " knockback";

                l19.overrideColor = config.Knockback;
            }
            if (l20 != null) l20.overrideColor = config.Material;
            if (l21 != null) l21.overrideColor = config.NeedsBait;
            if (l22 != null) l22.overrideColor = config.PickPower;
            if (l23 != null) l23.overrideColor = config.Placeable;
            if (l24 != null) l24.overrideColor = config.Quest;
            if (l25 != null) l25.overrideColor = config.SetBonus;
            if (l26 != null) l26.overrideColor = config.Social;
            if (l27 != null) l27.overrideColor = config.SocialDesc;
            if (l28 != null) l28.overrideColor = config.SpecialPrice;
            if (l29 != null)
            {
                if (config.speedLine) l29.text = Math.Round(60 / (item.reuseDelay + (item.useAnimation * (item.melee ? player.meleeSpeed : 1))), 2) + " attacks per second";

                l29.overrideColor = config.Speed;
            }
            if (l30 != null) l30.overrideColor = config.TileBoost;
            if (l31 != null) l31.overrideColor = config.UseMana;
            if (l32 != null) l32.overrideColor = config.Vanity;
            if (l33 != null) l33.overrideColor = config.WandConsumes;
            if (l34 != null) l34.overrideColor = config.WellFedExpert;

            if (config.Ammo.A == 0) lines.Remove(l2);
            if (config.AxePower.A == 0) lines.Remove(l3);
            if (config.BaitPower.A == 0) lines.Remove(l4);
            if (config.BuffTime.A == 0) lines.Remove(l5);
            if (config.Consumable.A == 0) lines.Remove(l6);
            if (config.CritChance.A == 0 || (item.ammo > 0 && !config.ammoCrit)) lines.Remove(l7);
            if (config.Damage.A == 0) lines.Remove(l8);
            if (config.Defense.A == 0) lines.Remove(l9);
            if (config.Equipable.A == 0) lines.Remove(l10);
            if (config.EtherianManaWarning.A == 0) lines.Remove(l11);
            if (config.Expert.A == 0) lines.Remove(l12);
            if (config.Favorite.A == 0) lines.Remove(l13);
            if (config.FavoriteDesc.A == 0) lines.Remove(l14);
            if (config.FishingPower.A == 0) lines.Remove(l15);
            if (config.HammerPower.A == 0) lines.Remove(l16);
            if (config.HealLife.A == 0) lines.Remove(l17);
            if (config.HealMana.A == 0) lines.Remove(l18);
            if (config.Knockback.A == 0 || knockback + (item.useAmmo > 0 && player.HasAmmo(item, true) ? player.GetWeaponKnockback(CurrentAmmo, CurrentAmmo.knockBack) : 0) == 0) lines.Remove(l19);
            if (config.Material.A == 0) lines.Remove(l20);
            if (config.NeedsBait.A == 0) lines.Remove(l21);
            if (config.PickPower.A == 0) lines.Remove(l22);
            if (config.Placeable.A == 0) lines.Remove(l23);
            if (config.Quest.A == 0) lines.Remove(l24);
            if (config.SetBonus.A == 0) lines.Remove(l25);
            if (config.Social.A == 0) lines.Remove(l26);
            if (config.SocialDesc.A == 0) lines.Remove(l27);
            if (config.SpecialPrice.A == 0) lines.Remove(l28);
            if (config.Speed.A == 0) lines.Remove(l29);
            if (config.TileBoost.A == 0) lines.Remove(l30);
            if (config.UseMana.A == 0) lines.Remove(l31);
            if (config.Vanity.A == 0) lines.Remove(l32);
            if (config.WandConsumes.A == 0) lines.Remove(l33);
            if (config.WellFedExpert.A == 0) lines.Remove(l34);
        }

        public override void PostDrawTooltip(Item item, ReadOnlyCollection<DrawableTooltipLine> _) { if (item.useAmmo > 0 && LocalPlayer.HasAmmo(item, true)) rarityColor = RarityColor(CurrentAmmo); }

        internal static Color RarityColor(Item item)
        {
            int var1 = 1;
            string[] var2 = { "ItemName" };
            var var3 = new bool[1];
            var var4 = new bool[1];
            int var5 = -1;

            return ItemLoader.ModifyTooltips(item, ref var1, new[] { "ItemName" }, ref var2, ref var3, ref var4, ref var5, out _)[0].overrideColor ?? new Dictionary<int, Color> { [-11] = new Color(255, 175, 0), [-1] = RarityTrash, [0] = RarityNormal, [1] = RarityBlue, [2] = RarityGreen, [3] = RarityOrange, [4] = RarityRed, [5] = RarityPink, [6] = RarityPurple, [7] = RarityLime, [8] = RarityYellow, [9] = RarityCyan, [10] = new Color(255, 40, 100), [11] = new Color(180, 40, 255) }[item.rare];
        }

        internal static void TextPulse(Color color, out Color pulseColor, out string hex)
        {
            pulseColor = new Color(color.R * mouseTextColor / 255, color.G * mouseTextColor / 255, color.B * mouseTextColor / 255, mouseTextColor);
            hex = pulseColor.Hex3();
        }
    }
}