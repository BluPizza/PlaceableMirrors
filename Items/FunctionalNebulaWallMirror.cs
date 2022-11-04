using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class FunctionalNebulaWallMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.FunctionalNebulaWallMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.FunctionalWallMirror}");
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
			Item.createTile = ModContent.TileType<Tiles.FunctionalWallMirror>();
			Item.placeStyle = 36;
			Item.value = CalculateValue.GetFunctionalWallMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeFunctional)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.NebulaWallMirror>())
					.AddIngredient(ItemID.MagicMirror)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeFunctional)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.NebulaWallMirror>())
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
        }
    }
}