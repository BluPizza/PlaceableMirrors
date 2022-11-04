using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WallReturnMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.ReturnMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.ReturnMirror}");
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
			Item.createTile = ModContent.TileType<Tiles.WallReturnMirror>();
			Item.value = CalculateValue.GetReturnMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeReturn)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WallMagicMirror>())
					.AddIngredient(ItemID.PotionOfReturn, ConfigValues.PotionOfReturnAmount)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeReturn)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.PotionOfReturn, ConfigValues.PotionOfReturnAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}