using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ID.Colors;
namespace TrueTooltips
{
    class GlobalItem0 : GlobalItem
    {
        public static Color? rc;
        public static Item ca = new Item();
        static string bpl;
        public override bool PreDrawTooltip(Item item, ReadOnlyCollection<TooltipLine> tl, ref int x, ref int y)
        {
            var bc = ModContent.GetInstance<Config>().bc;
            var sl = tl.Select(_ => _.text).ToArray();

            foreach (var _ in sl) if (_ == bpl) sl[Array.IndexOf(sl, _)] = _.Replace("[c/b5c0c1:", "").Replace("[c/dcdcc6:", "").Replace("[c/e0c95c:", "").Replace("[c/f68a60:", "").Replace("]", "").TrimEnd();
            if (bc.A > 0) Utils.DrawInvBG(Main.spriteBatch, new Rectangle(x - 10, y - 10, (int)sl.Max(_ => Main.fontMouseText.MeasureString(_).X) + 20, (int)sl.Sum(_ => Main.fontMouseText.MeasureString(_).Y) + 15), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            return base.PreDrawTooltip(item, tl, ref x, ref y);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tl)
        {
            var ci = ModContent.GetInstance<Config>();
            var lp = Main.LocalPlayer;
            var price = (double)item.stack * (item.buy ? item.shopCustomPrice > 0 ? item.shopCustomPrice : item.value : item.value / 5);
            int copper = (int)price / 1 % 100, silver = (int)price / 100 % 100, gold = (int)price / 10000 % 100, plat = (int)price / 1000000;

            foreach (var _ in lp.inventory) if (_.active && _.ammo == item.useAmmo)
                {
                    ca = _;
                    break;
                }
            for (int slot = 54; slot < 58; slot++) if (lp.inventory[slot].active && lp.inventory[slot].ammo == item.useAmmo)
                {
                    ca = lp.inventory[slot];
                    break;
                }

            TooltipLine l1 = new TooltipLine(mod, mod.Name, ca.HoverName) { overrideColor = rc },
                        l2 = tl.Find(_ => _.Name == "Ammo"),
                        l3 = tl.Find(_ => _.Name == "AxePower"),
                        l4 = tl.Find(_ => _.Name == "BaitPower"),
                        l5 = tl.Find(_ => _.Name == "BuffTime"),
                        l6 = tl.Find(_ => _.Name == "Consumable"),
                        l7 = tl.Find(_ => _.Name == "CritChance"),
                        l8 = tl.Find(_ => _.Name == "Damage"),
                        l9 = tl.Find(_ => _.Name == "Defense"),
                        l10 = tl.Find(_ => _.Name == "Equipable"),
                        l11 = tl.Find(_ => _.Name == "EtherianManaWarning"),
                        l12 = tl.Find(_ => _.Name == "Expert"),
                        l13 = tl.Find(_ => _.Name == "Favorite"),
                        l14 = tl.Find(_ => _.Name == "FavoriteDesc"),
                        l15 = tl.Find(_ => _.Name == "FishingPower"),
                        l16 = tl.Find(_ => _.Name == "HammerPower"),
                        l17 = tl.Find(_ => _.Name == "HealLife"),
                        l18 = tl.Find(_ => _.Name == "HealMana"),
                        l19 = tl.Find(_ => _.Name == "Knockback"),
                        l20 = tl.Find(_ => _.Name == "Material"),
                        l21 = tl.Find(_ => _.Name == "NeedsBait"),
                        l22 = tl.Find(_ => _.Name == "PickPower"),
                        l23 = tl.Find(_ => _.Name == "Placeable"),
                        l24 = tl.Find(_ => _.Name == "Quest"),
                        l25 = tl.Find(_ => _.Name == "SetBonus"),
                        l26 = tl.Find(_ => _.Name == "Social"),
                        l27 = tl.Find(_ => _.Name == "SocialDesc"),
                        l28 = tl.Find(_ => _.Name == "SpecialPrice"),
                        l29 = tl.Find(_ => _.Name == "Speed"),
                        l30 = tl.Find(_ => _.Name == "TileBoost"),
                        l31 = tl.Find(_ => _.Name == "UseMana"),
                        l32 = tl.Find(_ => _.Name == "Vanity"),
                        l33 = tl.Find(_ => _.Name == "WandConsumes"),
                        l34 = tl.Find(_ => _.Name == "WellFedExpert");

            if (ci.al)
            {
                if (!lp.HasAmmo(item, true)) tl.Add(new TooltipLine(mod, mod.Name, "No ammo") { overrideColor = RarityTrash });
                if (item.useAmmo > 0) tl.Add(l1);
            }
            if (ci.bpl)
            {
                bpl = $"{(plat > 0 ? $"[c/dcdcc6:{plat} platinum] " : "") + (gold > 0 ? $"[c/e0c95c:{gold} gold] " : "") + (silver > 0 ? $"[c/b5c0c1:{silver} silver] " : "") + (copper > 0 ? $"[c/f68a60:{copper} copper]" : "")}";
                if (!(item.type > 70 && item.type < 75)) tl.Add(new TooltipLine(mod, mod.Name, bpl));
                tl.RemoveAll(_ => _.Name == "Price");
            }

            if (ci.mn)
            {
                if (ca.modItem != null) l1.text += "\n" + ca.modItem.mod.DisplayName;
                if (item.modItem != null) tl.Find(_ => _.Name == "ItemName").text += "\n" + item.modItem.mod.DisplayName;
            }
            if (l2 != null) l2.overrideColor = ci.Ammo;
            if (l3 != null) l3.overrideColor = ci.AxePower;
            if (l4 != null) l4.overrideColor = ci.BaitPower;
            if (l5 != null) l5.overrideColor = ci.BuffTime;
            if (l6 != null) l6.overrideColor = ci.Consumable;
            if (l7 != null)
            {
                if (ci.wac) l7.text = ca.crit - lp.HeldItem.crit * (CC(ca) > 0 ? 2 : 1) + CC(ca) + CC(item) + item.crit + "% critical strike chance";
                l7.overrideColor = ci.CritChance;
            }
            if (l8 != null)
            {
                if (ca.damage > 0 && item.useAmmo > 0 && ci.wad) l8.text = l8.text.Replace(l8.text.Split(' ').First(), lp.GetWeaponDamage(ca) + lp.GetWeaponDamage(item) + "");
                if (ModLoader.GetMod("_ColoredDamageTypes") == null) l8.overrideColor = ci.Damage;
            }
            if (l9 != null) l9.overrideColor = ci.Defense;
            if (l10 != null) l10.overrideColor = ci.Equipable;
            if (l11 != null) l11.overrideColor = ci.EtherianManaWarning;
            if (l12 != null) l12.overrideColor = ci.Expert;
            if (l13 != null) l13.overrideColor = ci.Favorite;
            if (l14 != null) l14.overrideColor = ci.FavoriteDesc;
            if (l15 != null) l15.overrideColor = ci.FishingPower;
            if (l16 != null) l16.overrideColor = ci.HammerPower;
            if (l17 != null) l17.overrideColor = ci.HealLife;
            if (l18 != null) l18.overrideColor = ci.HealMana;
            if (l19 != null)
            {
                if (ci.bkl) l19.text = Math.Round(item.knockBack + (ca.knockBack > 0 && ci.wak ? ca.knockBack : 0), 2) + " knockback";
                l19.overrideColor = ci.Knockback;
            }
            if (l20 != null) l20.overrideColor = ci.Material;
            if (l21 != null) l21.overrideColor = ci.NeedsBait;
            if (l22 != null) l22.overrideColor = ci.PickPower;
            if (l23 != null) l23.overrideColor = ci.Placeable;
            if (l24 != null) l24.overrideColor = ci.Quest;
            if (l25 != null) l25.overrideColor = ci.SetBonus;
            if (l26 != null) l26.overrideColor = ci.Social;
            if (l27 != null) l27.overrideColor = ci.SocialDesc;
            if (l28 != null) l28.overrideColor = ci.SpecialPrice;
            if (l29 != null)
            {
                if (ci.bsl) l29.text = Math.Round(60 / (item.reuseDelay + (item.useAnimation * (item.melee ? lp.meleeSpeed : 1))), 2) + " uses per second";
                l29.overrideColor = ci.Speed;
            }
            if (l30 != null) l30.overrideColor = ci.TileBoost;
            if (l31 != null) l31.overrideColor = ci.UseMana;
            if (l32 != null) l32.overrideColor = ci.Vanity;
            if (l33 != null) l33.overrideColor = ci.WandConsumes;
            if (l34 != null) l34.overrideColor = ci.WellFedExpert;

            if (ci.Ammo.A < 1) tl.Remove(l2);
            if (ci.AxePower.A < 1) tl.Remove(l3);
            if (ci.BaitPower.A < 1) tl.Remove(l4);
            if (ci.BuffTime.A < 1) tl.Remove(l5);
            if (ci.Consumable.A < 1) tl.Remove(l6);
            if (ci.CritChance.A < 1) tl.Remove(l7);
            if (ci.Damage.A < 1) tl.Remove(l8);
            if (ci.Defense.A < 1) tl.Remove(l9);
            if (ci.Equipable.A < 1) tl.Remove(l10);
            if (ci.EtherianManaWarning.A < 1) tl.Remove(l11);
            if (ci.Expert.A < 1) tl.Remove(l12);
            if (ci.Favorite.A < 1) tl.Remove(l13);
            if (ci.FavoriteDesc.A < 1) tl.Remove(l14);
            if (ci.FishingPower.A < 1) tl.Remove(l15);
            if (ci.HammerPower.A < 1) tl.Remove(l16);
            if (ci.HealLife.A < 1) tl.Remove(l17);
            if (ci.HealMana.A < 1) tl.Remove(l18);
            if (ci.Knockback.A < 1 || ca.knockBack + item.knockBack == 0) tl.Remove(l19);
            if (ci.Material.A < 1) tl.Remove(l20);
            if (ci.NeedsBait.A < 1) tl.Remove(l21);
            if (ci.PickPower.A < 1) tl.Remove(l22);
            if (ci.Placeable.A < 1) tl.Remove(l23);
            if (ci.Quest.A < 1) tl.Remove(l24);
            if (ci.SetBonus.A < 1) tl.Remove(l25);
            if (ci.Social.A < 1) tl.Remove(l26);
            if (ci.SocialDesc.A < 1) tl.Remove(l27);
            if (ci.SpecialPrice.A < 1) tl.Remove(l28);
            if (ci.Speed.A < 1) tl.Remove(l29);
            if (ci.TileBoost.A < 1) tl.Remove(l30);
            if (ci.UseMana.A < 1) tl.Remove(l31);
            if (ci.Vanity.A < 1) tl.Remove(l32);
            if (ci.WandConsumes.A < 1) tl.Remove(l33);
            if (ci.WellFedExpert.A < 1) tl.Remove(l34);

            int CC(Item _) => _.magic ?
                         lp.magicCrit :
                              _.melee ?
                         lp.meleeCrit :
                             _.ranged ?
                        lp.rangedCrit :
                             _.thrown ?
                        lp.thrownCrit :
                                     0;
        }
        public override void PostDrawTooltip(Item item, ReadOnlyCollection<DrawableTooltipLine> _) { if (item.useAmmo > 0 && Main.LocalPlayer.HasAmmo(item, true)) rc = RarityColor(ca); }
        public static Color? RarityColor(Item item)
        {
            int var1 = 1;
            var var2 = new string[] { "ItemName" };
            var var3 = new bool[1];
            var var4 = new bool[1];
            int var5 = -1;
            var var6 = default(Color?[]);
            var oc = ItemLoader.ModifyTooltips(item, ref var1, new string[] { "ItemName" }, ref var2, ref var3, ref var4, ref var5, out var6)[0].overrideColor;

            return oc.HasValue ? oc : new Dictionary<int, Color> { [-11] = new Color(255, 175, 0), [-1] = RarityTrash, [0] = RarityNormal, [1] = RarityBlue, [2] = RarityGreen, [3] = RarityOrange, [4] = RarityRed, [5] = RarityPink, [6] = RarityPurple, [7] = RarityLime, [8] = RarityYellow, [9] = RarityCyan, [10] = new Color(255, 40, 100), [11] = new Color(180, 40, 255) }[item.rare];
        }
    }
}