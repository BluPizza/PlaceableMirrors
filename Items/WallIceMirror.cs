using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WallIceMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.LargeIceMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.LargeIceMirror}");
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
			Item.createTile = ModContent.TileType<Tiles.WallIceMirror>();
			Item.value = CalculateValue.GetLargeIceMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeIce)
			{
				CreateRecipe()
					.AddIngredient(ItemID.IceMirror)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			if (ConfigValues.AltRecipeIce)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WallMagicMirror>())
					.AddIngredient(ItemID.IceBlock, ConfigValues.MaterialAmount)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
        }
    }
}