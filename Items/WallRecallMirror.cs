using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WallRecallMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.RecallMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.RecallMirror}");
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
			Item.createTile = ModContent.TileType<Tiles.WallRecallMirror>();
			Item.value = CalculateValue.GetRecallMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeRecall)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WallMagicMirror>())
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmount)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeRecall)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}