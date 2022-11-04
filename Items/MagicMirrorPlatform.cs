using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class MagicMirrorPlatform : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.MagicMirrorPlatform}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.MagicMirrorPlatform}");
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
            Item.height = 24;
			Item.width = 14;
			Item.createTile = ModContent.TileType<Tiles.MagicMirrorPlatform>();
			Item.value = 0;
        }

        public override void AddRecipes()
        {
			CreateRecipe(2)
				.AddIngredient(ModContent.ItemType<Items.MagicMirrorBlock>())
				.Register();
        }
    }
}