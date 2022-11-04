using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class CellMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.CellMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.CellMirror}");
        }

        public override void SetDefaults()
        {
			Item.autoReuse = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Lime;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.height = 48;
			Item.width = 48;
			Item.createTile = ModContent.TileType<Tiles.CellMirror>();
			Item.value = CalculateValue.GetCellMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeCell)
			{
				CreateRecipe()
					.AddIngredient(ItemID.CellPhone)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			if (ConfigValues.AltRecipeCell)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Wire, ConfigValues.WireAmountAlt)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}