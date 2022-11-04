using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class SmallMagicConch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.SmallMagicConch}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.SmallMagicConch}");
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
			Item.createTile = ModContent.TileType<Tiles.SmallConch>();
			Item.placeStyle = 0;
			Item.value = 25000;
        }

        public override void AddRecipes()
        {
			if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableSmallMagicConchRecipe)
			{
				CreateRecipe(2)
					.AddIngredient(ItemID.MagicConch)
					.Register();

				Recipe.Create(ItemID.MagicConch)
					.AddIngredient(ModContent.ItemType<Items.SmallMagicConch>(), 2)
					.Register();
			}
        }
    }
}