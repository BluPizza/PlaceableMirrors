using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class LesionWallMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.LesionWallMirror}");
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
			Item.placeStyle = 33;
			Item.value = CalculateValue.GetWallMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeLesionMirror && !ConfigValues.SpecialCrafting)
			{
				CreateRecipe()
					.AddIngredient(ItemID.LesionBlock, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			else if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeLesionMirror && ConfigValues.SpecialCrafting)
			{
				CreateRecipe()
					.AddIngredient(ItemID.LesionBlock, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(TileID.LesionStation)
					.Register();
			}
        }
    }
}