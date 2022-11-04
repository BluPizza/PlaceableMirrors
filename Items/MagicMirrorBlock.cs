using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class MagicMirrorBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.MagicMirrorBlock}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.MagicMirrorBlock}");
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
            Item.height = 16;
			Item.width = 16;
			Item.createTile = ModContent.TileType<Tiles.MagicMirrorBlock>();
			Item.value = 0;
        }
		
        public override void AddRecipes()
        {
			if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeMagicMirrorBlock)
			{
				CreateRecipe(ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().GlassAmountForBlocks)
					.AddIngredient(ItemID.MagicMirror)
					.AddIngredient(ItemID.Glass, ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().GlassAmountForBlocks)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeMagicMirrorBlock)
			{
				CreateRecipe(ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().GlassAmountForBlocks)
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmountAlt)
					.AddIngredient(ItemID.Glass, ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().GlassAmountForBlocks)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}

			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.MagicMirrorBackgroundBlock>())
				.Register();

			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.MagicMirrorWall>(), 4)
				.AddTile(TileID.WorkBenches)
				.Register();

			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.MagicMirrorPlatform>(), 2)
				.Register();
        }
    }
}