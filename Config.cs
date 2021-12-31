using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;
namespace TrueTooltips
{
    class Config : ModConfig
    {
        [Header("[c/ffff00:Custom Tooltip Lines]")]

        [Label("Ammo Line")]
        [Tooltip("Shows the Item's Ammo's Name, Amount and Rarity and shows the Mod that adds the Ammo under the Ammo's Name if \"Mod Name under Item Name\" is on.")]
        [DefaultValue(true)]
        public bool al;

        [Label("Better Price Line")]
        [Tooltip("Correct Sell Price for Items with Custom Price, always visible, better Color Coding, cleaner. Replaces Vanilla Price Line.")]
        [DefaultValue(true)]
        public bool bpl;

        [Label("Better Speed Line")]
        [Tooltip("Shows Uses per Second. Replaces Vanilla Speed Line.")]
        [DefaultValue(true)]
        public bool bsl;

        [Label("Better Knockback Line")]
        [Tooltip("Shows Knockback as a Number. Replaces Vanilla Knockback Line.")]
        [DefaultValue(true)]
        public bool bkl;

        [Label("Combine Weapon and Ammo Damage")]
        [DefaultValue(true)]
        public bool wad;

        [Label("Combine Weapon and Ammo Crit")]
        [DefaultValue(true)]
        public bool wac;

        [Label("Combine Weapon and Ammo Knockback")]
        [DefaultValue(true)]
        public bool wak;

        [Label("Mod Name under Item Name")]
        [Tooltip("Shows the Mod that adds the Item under the Item's Name.")]
        [DefaultValue(true)]
        public bool mn;

        [Header("[c/ffff00:Background Color]")]

        [Label("")]
        [DefaultValue(typeof(Color), "63,81,151,255")]
        public Color bc;

        [Header("[c/ffff00:Text Pulse]")]

        [Label("")]
        [DefaultValue(false)]
        public bool tp;

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