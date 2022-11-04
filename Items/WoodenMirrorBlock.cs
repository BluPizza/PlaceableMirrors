using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WoodenMirrorBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.WoodenMirrorBlock}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.WoodenMirrorBlock}");
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
            Item.height = 16;
			Item.width = 16;
			Item.createTile = ModContent.TileType<Tiles.WoodenMirrorBlock>();
			Item.value = 0;
        }
		
        public override void AddRecipes()
        {
			if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeWoodenMirrorBlock)
			{
				CreateRecipe(ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().GlassAmountForBlocks)
					.AddIngredient(ItemID.Wood, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().GlassAmountForBlocks)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}

			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.WoodenMirrorBackgroundBlock>())
				.Register();
        }
    }
}