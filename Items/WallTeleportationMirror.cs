using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WallTeleportationMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.TeleportationMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.TeleportationMirror}");
        }

        public override void SetDefaults()
        {
			Item.autoReuse = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.height = 32;
			Item.width = 20;
			Item.createTile = ModContent.TileType<Tiles.WallTeleportationMirror>();
			Item.value = CalculateValue.GetTeleportationMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeTeleportation)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WallMagicMirror>())
					.AddIngredient(ItemID.TeleportationPotion, ConfigValues.TeleportationPotionAmount)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeTeleportation)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.TeleportationPotion, ConfigValues.TeleportationPotionAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}