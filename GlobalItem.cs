using Microsoft.Xna.Framework;
using static Terraria.ID.Colors;
using System.Linq;
using System;
using Terraria.ModLoader;
using Terraria;
using System.Collections.ObjectModel;
namespace TrueTooltips
{
    class GlobalItem0 : GlobalItem
    {
        public override bool PreDrawTooltip(Item item, ReadOnlyCollection<TooltipLine> tl, ref int x, ref int y)
        {
            var bc = ModContent.GetInstance<Config>().bc;

            if (0 < bc.A) Utils.DrawInvBG(Main.spriteBatch, new Rectangle(x - 10, y - 10, (int)tl.Select(_ => _.text).Max(_ => Main.fontMouseText.MeasureString(_).X) + 20, (int)tl.Select(_ => _.text).Sum(_ => Main.fontMouseText.MeasureString(_).Y) + 15), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            return base.PreDrawTooltip(item, tl, ref x, ref y);
        }
        public override void ModifyTooltips(Item item, System.Collections.Generic.List<TooltipLine> tl)
        {
            var ca = new Item();
            var ci = ModContent.GetInstance<Config>();
            var lp = Main.LocalPlayer;
            var rc = new System.Collections.Generic.Dictionary<int, Color> { [0] = RarityNormal, [1] = RarityBlue, [-1] = RarityTrash, [10] = new Color(255, 40, 100), [11] = new Color(180, 40, 255), [-11] = new Color(255, 175, 0), [2] = RarityGreen, [3] = RarityOrange, [4] = RarityRed, [5] = RarityPink, [6] = RarityPurple, [7] = RarityLime, [8] = RarityYellow, [9] = RarityCyan };

            foreach (var _ in lp.inventory) if (_.active && _.ammo == item.useAmmo)
                {
                    ca = _;
                    break;
                }
            for (var slot = 54; 58 > slot; slot++) if (item.useAmmo == lp.inventory[slot].ammo && lp.inventory[slot].active)
                {
                    ca = lp.inventory[slot];
                    break;
                }
            TooltipLine l1 = new TooltipLine(mod, mod.Name, ca.HoverName) { overrideColor = rc[ca.rare] }, l2 = tl.Find(_ => _.Name == "Ammo"), l3 = tl.Find(_ => _.Name == "AxePower"), l4 = tl.Find(_ => _.Name == "BaitPower"), l5 = tl.Find(_ => _.Name == "BuffTime"), l6 = tl.Find(_ => _.Name == "Consumable"), l7 = tl.Find(_ => _.Name == "CritChance"), l8 = tl.Find(_ => _.Name == "Damage"), l9 = tl.Find(_ => _.Name == "Defense"), l10 = tl.Find(_ => _.Name == "Equipable"), l11 = tl.Find(_ => _.Name == "EtherianManaWarning"), l12 = tl.Find(_ => _.Name == "Expert"), l13 = tl.Find(_ => _.Name == "Favorite"), l14 = tl.Find(_ => _.Name == "FavoriteDesc"), l15 = tl.Find(_ => _.Name == "FishingPower"), l16 = tl.Find(_ => _.Name == "HammerPower"), l17 = tl.Find(_ => _.Name == "HealLife"), l18 = tl.Find(_ => _.Name == "HealMana"), l19 = tl.Find(_ => _.Name == "Knockback"), l20 = tl.Find(_ => _.Name == "Material"), l21 = tl.Find(_ => _.Name == "NeedsBait"), l22 = tl.Find(_ => _.Name == "PickPower"), l23 = tl.Find(_ => _.Name == "Placeable"), l24 = tl.Find(_ => _.Name == "Quest"), l25 = tl.Find(_ => _.Name == "SetBonus"), l26 = tl.Find(_ => _.Name == "Social"), l27 = tl.Find(_ => _.Name == "SocialDesc"), l28 = tl.Find(_ => _.Name == "SpecialPrice"), l29 = tl.Find(_ => _.Name == "Speed"), l30 = tl.Find(_ => _.Name == "TileBoost"), l31 = tl.Find(_ => _.Name == "UseMana"), l32 = tl.Find(_ => _.Name == "Vanity"), l33 = tl.Find(_ => _.Name == "WandConsumes"), l34 = tl.Find(_ => _.Name == "WellFedExpert");
            var price = (double)item.stack * item.value / (item.buy ? 1 : 5);
            int copper = (int)price / 1 % 100, gold = (int)price / 10000 % 100, plat = (int)price / 1000000, silver = (int)price / 100 % 100;

            if (ci.al)
            {
                if (0 < item.useAmmo) tl.Add(l1);
                if (!lp.HasAmmo(item, true)) tl.Add(new TooltipLine(mod, mod.Name, "No ammo") { overrideColor = RarityTrash });
            }
            if (ci.bpl)
            {
                tl.RemoveAll(_ => _.Name == "Price");
                if (!(70 < item.type && 75 > item.type)) tl.Add(new TooltipLine(mod, mod.Name, $"{(0 < plat ? $"[c/dcdcc6:{plat} platinum] " : "") + (0 < gold ? $"[c/e0c95c:{gold} gold] " : "") + (0 < silver ? $"[c/b5c0c1:{silver} silver] " : "") + (0 < copper ? $"[c/f68a60:{copper} copper]" : "")}"));
            }
            if (ci.mn)
            {
                if (ca.modItem != null) l1.text += "\n" + ca.modItem.mod.DisplayName;
                if (item.modItem != null) tl.Find(_ => _.Name == "ItemName").text += "\n" + item.modItem.mod.DisplayName;
            }
            if (l19 != null)
            {
                if (ci.bkl) l19.text = Math.Round((0 < ca.knockBack && ci.wak ? ca.knockBack : 0) + item.knockBack, 2) + " knockback";
                l19.overrideColor = ci.Knockback;
            }
            if (l29 != null)
            {
                if (ci.bsl) l29.text = Math.Round(60 / (((item.melee ? lp.meleeSpeed : 1) * item.useAnimation) + item.reuseDelay), 2) + " uses per second";
                l29.overrideColor = ci.Speed;
            }
            if (l7 != null)
            {
                if (ci.wac) l7.text = ca.crit - (0 < CC(ca) ? 2 : 1) * lp.HeldItem.crit + CC(ca) + CC(item) + item.crit + "% critical strike chance";
                l7.overrideColor = ci.CritChance;
            }
            if (l8 != null)
            {
                if (0 < ca.damage && 0 < item.useAmmo && ci.wad) l8.text = l8.text.Replace(l8.text.Split(' ').First(), lp.GetWeaponDamage(ca) + lp.GetWeaponDamage(item) + "");
                if (ModLoader.GetMod("_ColoredDamageTypes") == null) l8.overrideColor = ci.Damage;
            }
            int CC(Item _)
            {
                if (_.magic) return lp.magicCrit;
                if (_.melee) return lp.meleeCrit;
                if (_.ranged) return lp.rangedCrit;
                if (_.thrown) return lp.thrownCrit;
                return 0;
            }
            if (0 == ca.knockBack + item.knockBack || 1 > ci.Knockback.A) tl.Remove(l19);
            if (1 > ci.Ammo.A) tl.Remove(l2);
            if (1 > ci.AxePower.A) tl.Remove(l3);
            if (1 > ci.BaitPower.A) tl.Remove(l4);
            if (1 > ci.BuffTime.A) tl.Remove(l5);
            if (1 > ci.Consumable.A) tl.Remove(l6);
            if (1 > ci.CritChance.A) tl.Remove(l7);
            if (1 > ci.Damage.A) tl.Remove(l8);
            if (1 > ci.Defense.A) tl.Remove(l9);
            if (1 > ci.Equipable.A) tl.Remove(l10);
            if (1 > ci.EtherianManaWarning.A) tl.Remove(l11);
            if (1 > ci.Expert.A) tl.Remove(l12);
            if (1 > ci.Favorite.A) tl.Remove(l13);
            if (1 > ci.FavoriteDesc.A) tl.Remove(l14);
            if (1 > ci.FishingPower.A) tl.Remove(l15);
            if (1 > ci.HammerPower.A) tl.Remove(l16);
            if (1 > ci.HealLife.A) tl.Remove(l17);
            if (1 > ci.HealMana.A) tl.Remove(l18);
            if (1 > ci.Material.A) tl.Remove(l20);
            if (1 > ci.NeedsBait.A) tl.Remove(l21);
            if (1 > ci.PickPower.A) tl.Remove(l22);
            if (1 > ci.Placeable.A) tl.Remove(l23);
            if (1 > ci.Quest.A) tl.Remove(l24);
            if (1 > ci.SetBonus.A) tl.Remove(l25);
            if (1 > ci.Social.A) tl.Remove(l26);
            if (1 > ci.SocialDesc.A) tl.Remove(l27);
            if (1 > ci.SpecialPrice.A) tl.Remove(l28);
            if (1 > ci.Speed.A) tl.Remove(l29);
            if (1 > ci.TileBoost.A) tl.Remove(l30);
            if (1 > ci.UseMana.A) tl.Remove(l31);
            if (1 > ci.Vanity.A) tl.Remove(l32);
            if (1 > ci.WandConsumes.A) tl.Remove(l33);
            if (1 > ci.WellFedExpert.A) tl.Remove(l34);
            if (l10 != null) l10.overrideColor = ci.Equipable;
            if (l11 != null) l11.overrideColor = ci.EtherianManaWarning;
            if (l12 != null) l12.overrideColor = ci.Expert;
            if (l13 != null) l13.overrideColor = ci.Favorite;
            if (l14 != null) l14.overrideColor = ci.FavoriteDesc;
            if (l15 != null) l15.overrideColor = ci.FishingPower;
            if (l16 != null) l16.overrideColor = ci.HammerPower;
            if (l17 != null) l17.overrideColor = ci.HealLife;
            if (l18 != null) l18.overrideColor = ci.HealMana;
            if (l2 != null) l2.overrideColor = ci.Ammo;
            if (l20 != null) l20.overrideColor = ci.Material;
            if (l21 != null) l21.overrideColor = ci.NeedsBait;
            if (l22 != null) l22.overrideColor = ci.PickPower;
            if (l23 != null) l23.overrideColor = ci.Placeable;
            if (l24 != null) l24.overrideColor = ci.Quest;
            if (l25 != null) l25.overrideColor = ci.SetBonus;
            if (l26 != null) l26.overrideColor = ci.Social;
            if (l27 != null) l27.overrideColor = ci.SocialDesc;
            if (l28 != null) l28.overrideColor = ci.SpecialPrice;
            if (l3 != null) l3.overrideColor = ci.AxePower;
            if (l30 != null) l30.overrideColor = ci.TileBoost;
            if (l31 != null) l31.overrideColor = ci.UseMana;
            if (l32 != null) l32.overrideColor = ci.Vanity;
            if (l33 != null) l33.overrideColor = ci.WandConsumes;
            if (l34 != null) l34.overrideColor = ci.WellFedExpert;
            if (l4 != null) l4.overrideColor = ci.BaitPower;
            if (l5 != null) l5.overrideColor = ci.BuffTime;
            if (l6 != null) l6.overrideColor = ci.Consumable;
            if (l9 != null) l9.overrideColor = ci.Defense;
        }
    }
}