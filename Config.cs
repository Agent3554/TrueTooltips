using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TrueTooltips
{
    class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("[c/ffff00:Custom Tooltip Lines]")]

        [Label("Ammo Line")]
        [Tooltip("Shows the Item's Ammo's Name, Amount and Rarity, shows the Mod that adds the Ammo if \"Mod Name next to Item Name\" is on and shows the Ammo the Item needs if the Item has no Ammo.")]
        [DefaultValue(true)]
        public bool ammoLine;

        [Label("Better Price Line")]
        [Tooltip("Correct Sell Price for Items with Custom Price, always visible, better Color Coding, cleaner. Replaces Vanilla Price Line.")]
        [DefaultValue(true)]
        public bool priceLine;

        [Label("Better Speed Line")]
        [Tooltip("Shows Attacks per Second. Replaces Vanilla Speed Line.")]
        [DefaultValue(true)]
        public bool speedLine;

        [Label("Better Knockback Line")]
        [Tooltip("Shows Knockback as a Number. Replaces Vanilla Knockback Line.")]
        [DefaultValue(true)]
        public bool knockbackLine;

        [Label("Combine Weapon and Ammo Damage")]
        [DefaultValue(true)]
        public bool wpnPlusAmmoDmg;

        [Label("Combine Weapon and Ammo Knockback")]
        [Tooltip("Requires Better Knockback Line to be on")]
        [DefaultValue(true)]
        public bool wpnPlusAmmoKb;

        [Label("Mod Name next to Item Name")]
        [Tooltip("Shows the Mod that adds the Item next to the Item's Name.")]
        [DefaultValue(true)]
        public bool modName;

        [Header("[c/ffff00:Background Color]")]

        [Label("")]
        [DefaultValue(typeof(Color), "63,81,151,255")]
        public Color bgColor;

        [Header("[c/ffff00:Miscellaneous]")]

        [Label("Text Pulse")]
        [DefaultValue(false)]
        public bool textPulse;

        [Label("Crit Chance Line for Ammo")]
        [Tooltip("Off by Default because Ammo Crit Chance doesn't affect Crit Chance.")]
        [DefaultValue(false)]
        public bool ammoCrit;

        [Header("[c/ffff00:Vanilla Tooltip Lines]")]

        [Tooltip("Tells if the item is ammo.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Ammo;

        [Tooltip("The item's axe power.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color AxePower;

        [Tooltip("The bait power of the bait.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color BaitPower;

        [Tooltip("Tells how long the item's buff lasts.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color BuffTime;

        [Tooltip("Tells if the item is consumable.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Consumable;

        [Tooltip("The critical strike chance of the weapon.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color CritChance;

        [Tooltip("The damage value and type of the weapon.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Damage;

        [Tooltip("Tells how much defense the item gives when equipped.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Defense;

        [Tooltip("Tells that an item is equipable.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Equipable;

        [Tooltip("Warning about how the item can't be used without Etherian Mana until the Eternia Crystal has been defeated.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color EtherianManaWarning;

        [Tooltip("Tells whether the item is from expert-mode.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Expert;

        [Tooltip("Tells if the item is favorited.")]
        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color Favorite;

        [Tooltip("Tells what it means when an item is favorited.")]
        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color FavoriteDesc;

        [Tooltip("Tells the fishing power of the fishing pole.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color FishingPower;

        [Tooltip("The item's hammer power.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color HammerPower;

        [Tooltip("How much health the item recovers when used.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color HealLife;

        [Tooltip("How much mana the item recovers when used.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color HealMana;

        [Tooltip("The knockback of the weapon.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Knockback;

        [Tooltip("Tells if the item can be used to craft something.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Material;

        [Tooltip("Tells that a fishing pole requires bait.")]
        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color NeedsBait;

        [Tooltip("The item's pickaxe power.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color PickPower;

        [Tooltip("Tells if the item is placeable.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Placeable;

        [Tooltip("Tells that this is a quest item.")]
        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color Quest;

        [Tooltip("The set bonus description of the armor set.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color SetBonus;

        [Tooltip("Tells if the item is in a social slot.")]
        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color Social;

        [Tooltip("Tells what it means for an item to be in a social slot.")]
        [DefaultValue(typeof(Color), "255,255,255,0")]
        public Color SocialDesc;

        [Tooltip("Tells the alternate currency price of an item.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color SpecialPrice;

        [Tooltip("The use speed of the weapon.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Speed;

        [Tooltip("How much farther the item can reach than normal items.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color TileBoost;

        [Tooltip("Tells how much mana the item consumes upon usage.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color UseMana;

        [Tooltip("Tells that this is a vanity item.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color Vanity;

        [Tooltip("Tells what item a tile wand consumes.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color WandConsumes;

        [Tooltip("In expert mode, tells that food increases life renegeration.")]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        public Color WellFedExpert;
    }
}