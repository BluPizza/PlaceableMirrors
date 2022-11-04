using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class MagicMirrorWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.MagicMirrorWall}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.MagicMirrorWall}");
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
			Item.width = 24;
			Item.createWall = ModContent.WallType<Tiles.MagicMirrorWall>();
			Item.value = 0;
        }
		
        public override void AddRecipes()
        {	
			CreateRecipe(4)
				.AddIngredient(ModContent.ItemType<Items.MagicMirrorBlock>())
				.AddTile(TileID.WorkBenches)
				.Register();
        }
    }
}