using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WallWaterMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.WaterMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.WaterMirror}");
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
			Item.createTile = ModContent.TileType<Tiles.WallWaterMirror>();
			Item.value = CalculateValue.GetWaterMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeWater && ConfigValues.RecipePalmWood)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.PalmWoodWallMirror>())
					.AddIngredient(ItemID.MagicConch)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			else if (ConfigValues.RecipeWater && !ConfigValues.RecipePalmWood)
			{
				CreateRecipe()
					.AddIngredient(ItemID.PalmWood, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.MagicConch)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			if (ConfigValues.AltRecipeWater && ConfigValues.RecipePalmWood)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.PalmWoodWallMirror>())
					.AddIngredient(ItemID.Seashell, ConfigValues.SeashellAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			else if (ConfigValues.AltRecipeWater && !ConfigValues.RecipePalmWood)
			{
				CreateRecipe()
					.AddIngredient(ItemID.PalmWood, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.Seashell, ConfigValues.SeashellAmountAlt)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}