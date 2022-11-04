using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class MagicMirrorBackgroundBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.MagicMirrorBackgroundBlock}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.MagicMirrorBackgroundBlock}");
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
			Item.createTile = ModContent.TileType<Tiles.MagicMirrorBackgroundBlock>();
			Item.value = 0;
        }
		
        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.MagicMirrorBlock>())
				.Register();
        }
    }
}