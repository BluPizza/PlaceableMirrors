using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class TerraMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.TerraMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.TerraMirror}");
        }

        public override void SetDefaults()
        {
			Item.autoReuse = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Yellow;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.height = 32;
			Item.width = 20;
			Item.createTile = ModContent.TileType<Tiles.TerraMirror>();
			Item.value = CalculateValue.GetTerraMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeTerra)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WallMagicMirror>())
					.AddIngredient(ItemID.BrokenHeroSword)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeTerra)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.WoodenWallMirror>())
					.AddIngredient(ItemID.BrokenHeroSword)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
        }
    }
}