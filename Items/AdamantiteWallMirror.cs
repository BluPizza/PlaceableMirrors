using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class AdamantiteWallMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.AdamantiteWallMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.AdamantiteWallMirror}");
        }

        public override void SetDefaults()
        {
			Item.autoReuse = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.height = 32;
			Item.width = 20;
			Item.createTile = ModContent.TileType<Tiles.MetalWallMirror>();
			Item.placeStyle = 16;
			Item.value = CalculateValue.GetMetalWallMirrorValue(16);
        }

        public override void AddRecipes()
        {
			if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeAdamantiteMirror)
			{
				CreateRecipe()
					.AddIngredient(ItemID.AdamantiteBar, ConfigValues.MetalBarAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}