using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class GoldenWallMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.GoldenWallMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.WallMirror}");
        }

        public override void SetDefaults()
        {
			Item.autoReuse = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.height = 32;
			Item.width = 20;
			Item.createTile = ModContent.TileType<Tiles.WallMirror>();
			Item.placeStyle = 17;
			Item.value = CalculateValue.GetGoldenWallMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeGolden)
			{
				CreateRecipe()
					.AddIngredient(ItemID.GoldenPlatform, ConfigValues.MaterialAmount * 2)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}