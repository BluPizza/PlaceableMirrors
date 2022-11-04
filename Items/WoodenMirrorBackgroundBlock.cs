using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WoodenMirrorBackgroundBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.WoodenMirrorBackgroundBlock}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.WoodenMirrorBackgroundBlock}");
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
			Item.createTile = ModContent.TileType<Tiles.WoodenMirrorBackgroundBlock>();
			Item.value = 0;
        }
		
        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.WoodenMirrorBlock>())
				.Register();
        }
    }
}