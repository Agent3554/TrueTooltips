using Microsoft.Xna.Framework;
using static Terraria.ID.Colors;
using System.Linq;
using System;
using Terraria.ModLoader;
using Terraria;
namespace TrueTooltips
{
    class GlobalItem0 : GlobalItem
    {
        public override void ModifyTooltips(Item a0, System.Collections.Generic.List<TooltipLine> a1)
        {
            var f0 = new Item();
            var f1 = ModContent.GetInstance<Config>();
            var f2 = Main.LocalPlayer;

            foreach (var f3 in f2.inventory) if (f3.active && f3.ammo == a0.useAmmo)
                {
                    f0 = f3;
                    break;
                }
            for (var f3 = 54; 58 > f3; f3++) if (a0.useAmmo == f2.inventory[f3].ammo && f2.inventory[f3].active)
                {
                    f0 = f2.inventory[f3];
                    break;
                }
            TooltipLine f4 = new TooltipLine(mod, mod.Name, f0.HoverName) { overrideColor = Rarity() }, f5 = a1.Find(_ => _.Name == "Ammo"), f6 = a1.Find(_ => _.Name == "AxePower"), f7 = a1.Find(_ => _.Name == "BaitPower"), f8 = a1.Find(_ => _.Name == "BuffTime"), f9 = a1.Find(_ => _.Name == "Consumable"), f10 = a1.Find(_ => _.Name == "CritChance"), f11 = a1.Find(_ => _.Name == "Damage"), f12 = a1.Find(_ => _.Name == "Defense"), f13 = a1.Find(_ => _.Name == "Equipable"), f14 = a1.Find(_ => _.Name == "EtherianManaWarning"), f15 = a1.Find(_ => _.Name == "Expert"), f16 = a1.Find(_ => _.Name == "Favorite"), f17 = a1.Find(_ => _.Name == "FavoriteDesc"), f18 = a1.Find(_ => _.Name == "FishingPower"), f19 = a1.Find(_ => _.Name == "HammerPower"), f20 = a1.Find(_ => _.Name == "HealLife"), f21 = a1.Find(_ => _.Name == "HealMana"), f22 = a1.Find(_ => _.Name == "Knockback"), f23 = a1.Find(_ => _.Name == "Material"), f24 = a1.Find(_ => _.Name == "NeedsBait"), f25 = a1.Find(_ => _.Name == "PickPower"), f26 = a1.Find(_ => _.Name == "Placeable"), f27 = a1.Find(_ => _.Name == "Quest"), f28 = a1.Find(_ => _.Name == "SetBonus"), f29 = a1.Find(_ => _.Name == "Social"), f30 = a1.Find(_ => _.Name == "SocialDesc"), f31 = a1.Find(_ => _.Name == "SpecialPrice"), f32 = a1.Find(_ => _.Name == "Speed"), f33 = a1.Find(_ => _.Name == "TileBoost"), f34 = a1.Find(_ => _.Name == "UseMana"), f35 = a1.Find(_ => _.Name == "Vanity"), f36 = a1.Find(_ => _.Name == "WandConsumes"), f37 = a1.Find(_ => _.Name == "WellFedExpert");
            var f38 = (double)a0.stack * a0.value / (a0.buy ? 1 : 5);
            int f39 = (int)f38 / 1 % 100, g = (int)f38 / 10000 % 100, p = (int)f38 / 1000000, s = (int)f38 / 100 % 100;

            Color Rarity()
            {
                switch (f0.rare)
                {
                    case 0: return RarityNormal;
                    case 1: return RarityBlue;
                    case -1: return RarityTrash;
                    case 10: return new Color(255, 40, 100);
                    case -11: return new Color(255, 175, 0);
                    case 2: return RarityGreen;
                    case 3: return RarityOrange;
                    case 4: return RarityRed;
                    case 5: return RarityPink;
                    case 6: return RarityPurple;
                    case 7: return RarityLime;
                    case 8: return RarityYellow;
                    case 9: return RarityCyan;
                }
                return new Color(180, 40, 255);
            }
            if (f1.f0)
            {
                if (0 < a0.useAmmo) a1.Add(f4);
                if (!f2.HasAmmo(a0, true)) a1.Add(new TooltipLine(mod, mod.Name, "No ammo") { overrideColor = RarityTrash });
            }
            if (f1.f2)
            {
                a1.RemoveAll(_ => _.Name == "Price");
                if (!(70 < a0.type && 75 > a0.type)) a1.Add(new TooltipLine(mod, mod.Name, $"{(0 < p ? $"[c/dcdcc6:{p} platinum] " : "") + (0 < g ? $"[c/e0c95c:{g} gold] " : "") + (0 < s ? $"[c/b5c0c1:{s} silver] " : "") + (0 < f39 ? $"[c/f68a60:{f39} copper]" : "")}"));
            }
            if (f1.f4)
            {
                if (f0.modItem != null) f4.text += "\n" + f0.modItem.mod.DisplayName;
                if (a0.modItem != null) a1.Find(_ => _.Name == "ItemName").text += "\n" + a0.modItem.mod.DisplayName;
            }
            if (f10 != null)
            {
                if (f1.f5) f10.text = f0.crit - (0 < CC(f0) ? 2 : 1) * f2.HeldItem.crit + CC(f0) + CC(a0) + a0.crit + "% critical strike chance";
                f10.overrideColor = f1.CritChance;
            }
            if (f11 != null)
            {
                if (0 < f0.damage && 0 < a0.useAmmo && f1.f6) f11.text = f11.text.Replace(f11.text.Split(' ').First(), f2.GetWeaponDamage(f0) + f2.GetWeaponDamage(a0) + "");
                f11.overrideColor = f1.Damage;
            }
            if (f22 != null)
            {
                if (f1.f1) f22.text = Math.Round((0 < f0.knockBack && f1.f7 ? f0.knockBack : 0) + a0.knockBack, 2) + " knockback";
                f22.overrideColor = f1.Knockback;
            }
            if (f32 != null)
            {
                if (f1.f3) f32.text = Math.Round(60 / (((a0.melee ? f2.meleeSpeed : 1) * a0.useTime) + a0.reuseDelay), 2) + " uses per second";
                f32.overrideColor = f1.Speed;
            }
            int CC(Item a2)
            {
                if (a2.magic) return f2.magicCrit;
                if (a2.melee) return f2.meleeCrit;
                if (a2.ranged) return f2.rangedCrit;
                if (a2.thrown) return f2.thrownCrit;
                return 0;
            }
            if (0 == f0.knockBack + a0.knockBack || 1 > f1.Knockback.A) a1.Remove(f22);
            if (1 > f1.Ammo.A) a1.Remove(f5);
            if (1 > f1.AxePower.A) a1.Remove(f6);
            if (1 > f1.BaitPower.A) a1.Remove(f7);
            if (1 > f1.BuffTime.A) a1.Remove(f8);
            if (1 > f1.Consumable.A) a1.Remove(f9);
            if (1 > f1.CritChance.A) a1.Remove(f10);
            if (1 > f1.Damage.A) a1.Remove(f11);
            if (1 > f1.Defense.A) a1.Remove(f12);
            if (1 > f1.Equipable.A) a1.Remove(f13);
            if (1 > f1.EtherianManaWarning.A) a1.Remove(f14);
            if (1 > f1.Expert.A) a1.Remove(f15);
            if (1 > f1.Favorite.A) a1.Remove(f16);
            if (1 > f1.FavoriteDesc.A) a1.Remove(f17);
            if (1 > f1.FishingPower.A) a1.Remove(f18);
            if (1 > f1.HammerPower.A) a1.Remove(f19);
            if (1 > f1.HealLife.A) a1.Remove(f20);
            if (1 > f1.HealMana.A) a1.Remove(f21);
            if (1 > f1.Material.A) a1.Remove(f23);
            if (1 > f1.NeedsBait.A) a1.Remove(f24);
            if (1 > f1.PickPower.A) a1.Remove(f25);
            if (1 > f1.Placeable.A) a1.Remove(f26);
            if (1 > f1.Quest.A) a1.Remove(f27);
            if (1 > f1.SetBonus.A) a1.Remove(f28);
            if (1 > f1.Social.A) a1.Remove(f29);
            if (1 > f1.SocialDesc.A) a1.Remove(f30);
            if (1 > f1.SpecialPrice.A) a1.Remove(f31);
            if (1 > f1.Speed.A) a1.Remove(f32);
            if (1 > f1.TileBoost.A) a1.Remove(f33);
            if (1 > f1.UseMana.A) a1.Remove(f34);
            if (1 > f1.Vanity.A) a1.Remove(f35);
            if (1 > f1.WandConsumes.A) a1.Remove(f36);
            if (1 > f1.WellFedExpert.A) a1.Remove(f37);
            if (f5 != null) f5.overrideColor = f1.Ammo;
            if (f14 != null) f14.overrideColor = f1.EtherianManaWarning;
            if (f15 != null) f15.overrideColor = f1.Expert;
            if (f16 != null) f16.overrideColor = f1.Favorite;
            if (f17 != null) f17.overrideColor = f1.FavoriteDesc;
            if (f18 != null) f18.overrideColor = f1.FishingPower;
            if (f19 != null) f19.overrideColor = f1.HammerPower;
            if (f20 != null) f20.overrideColor = f1.HealLife;
            if (f21 != null) f21.overrideColor = f1.HealMana;
            if (f23 != null) f23.overrideColor = f1.Material;
            if (f6 != null) f6.overrideColor = f1.AxePower;
            if (f24 != null) f24.overrideColor = f1.NeedsBait;
            if (f25 != null) f25.overrideColor = f1.PickPower;
            if (f26 != null) f26.overrideColor = f1.Placeable;
            if (f27 != null) f27.overrideColor = f1.Quest;
            if (f28 != null) f28.overrideColor = f1.SetBonus;
            if (f29 != null) f29.overrideColor = f1.Social;
            if (f30 != null) f30.overrideColor = f1.SocialDesc;
            if (f31 != null) f31.overrideColor = f1.SpecialPrice;
            if (f33 != null) f33.overrideColor = f1.TileBoost;
            if (f7 != null) f7.overrideColor = f1.BaitPower;
            if (f34 != null) f34.overrideColor = f1.UseMana;
            if (f35 != null) f35.overrideColor = f1.Vanity;
            if (f36 != null) f36.overrideColor = f1.WandConsumes;
            if (f37 != null) f37.overrideColor = f1.WellFedExpert;
            if (f8 != null) f8.overrideColor = f1.BuffTime;
            if (f9 != null) f9.overrideColor = f1.Consumable;
            if (f12 != null) f12.overrideColor = f1.Defense;
            if (f13 != null) f13.overrideColor = f1.Equipable;
        }
    }
}