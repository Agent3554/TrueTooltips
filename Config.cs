using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;
namespace TrueTooltips
{
    class Config : ModConfig
    {
        [Header("[c/ffff00:Background]")]

        [DefaultValue(typeof(Color), "63,81,151,255")]
        [Label("Background Color")]
        public Color bc;

        [Header("[c/ffff00:Custom Tooltip Lines]")]

        [DefaultValue(true)]
        [Label("Ammo Line")]
        public bool al;

        [DefaultValue(true)]
        [Label("Better Knockback Line")]
        public bool bkl;

        [DefaultValue(true)]
        [Label("Better Price Line")]
        public bool bpl;

        [DefaultValue(true)]
        [Label("Better Speed Line")]
        public bool bsl;

        [DefaultValue(true)]
        [Label("Mod Name under Item Name")]
        public bool mn;

        [DefaultValue(true)]
        [Label("Weapon + Ammo Crit")]
        public bool wac;

        [DefaultValue(true)]
        [Label("Weapon + Ammo Damage")]
        public bool wad;

        [DefaultValue(true)]
        [Label("Weapon + Ammo Knockback")]
        public bool wak;

        [Header("[c/ffff00:Vanilla Tooltip Lines]")]

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Ammo;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color AxePower;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color BaitPower;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color BuffTime;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Consumable;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color CritChance;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Damage;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Defense;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Equipable;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color EtherianManaWarning;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Expert;

        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color Favorite;

        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color FavoriteDesc;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color FishingPower;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color HammerPower;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color HealLife;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color HealMana;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Knockback;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Material;

        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color NeedsBait;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color PickPower;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Placeable;

        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color Quest;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color SetBonus;

        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color Social;

        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color SocialDesc;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color SpecialPrice;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Speed;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color TileBoost;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color UseMana;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Vanity;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color WandConsumes;

        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color WellFedExpert;
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}