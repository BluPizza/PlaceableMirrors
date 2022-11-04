using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class ZenithMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.ZenithMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.ZenithMirror}" + "\n" + "{$Mods.PlaceableMirrors.Items.Tooltip.ZenithMirrorControl}");
        }

        public override void SetDefaults()
        {
			Item.autoReuse = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Red;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.height = 48;
			Item.width = 48;
			Item.createTile = ModContent.TileType<Tiles.ZenithMirror>();
			Item.value = CalculateValue.GetZenithMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeZenith && !ConfigValues.OldRecipeZenith)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.TerraMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallWaterMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallLavaMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallTeleportationMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallWormholeMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallReturnMirror>())
					.AddIngredient(ModContent.ItemType<Items.CopperWallMirror>())
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			else if (ConfigValues.RecipeZenith && ConfigValues.OldRecipeZenith)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.TerraMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallWaterMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallLavaMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallReturnMirror>())
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeZenith && !ConfigValues.OldRecipeZenith)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WallMagicMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallWaterMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallLavaMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallTeleportationMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallWormholeMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallReturnMirror>())
					.AddIngredient(ModContent.ItemType<Items.CopperWallMirror>())
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			else if (ConfigValues.AltRecipeZenith && ConfigValues.OldRecipeZenith)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WallMagicMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallWaterMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallLavaMirror>())
					.AddIngredient(ModContent.ItemType<Items.WallReturnMirror>())
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
        }
    }
}