using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class ObsidianWallMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.ObsidianWallMirror}");
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
			Item.placeStyle = 15;
			Item.value = CalculateValue.GetObsidianWallMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeObsidian && ConfigValues.MaterialAmount >= 4)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Obsidian, ConfigValues.MaterialAmount - 2)
					.AddIngredient(ItemID.Hellstone, 2)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			else if (ConfigValues.RecipeObsidian)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Obsidian, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Hellstone, 1)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}