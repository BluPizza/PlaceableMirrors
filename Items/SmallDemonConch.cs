using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class SmallDemonConch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.SmallDemonConch}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.SmallDemonConch}");
        }

        public override void SetDefaults()
        {
			Item.autoReuse = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.height = 16;
			Item.width = 16;
			Item.createTile = ModContent.TileType<Tiles.SmallConch>();
			Item.placeStyle = 1;
			Item.value = 25000;
        }

        public override void AddRecipes()
        {
			if (ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableSmallDemonConchRecipe)
			{
				CreateRecipe(2)
					.AddIngredient(ItemID.DemonConch)
					.Register();

				Recipe.Create(ItemID.DemonConch)
					.AddIngredient(ModContent.ItemType<Items.SmallDemonConch>(), 2)
					.Register();
			}
        }
    }
}