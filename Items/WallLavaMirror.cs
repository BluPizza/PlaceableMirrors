using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class WallLavaMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.LavaMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.LavaMirror}");
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
            Item.height = 32;
			Item.width = 20;
			Item.createTile = ModContent.TileType<Tiles.WallLavaMirror>();
			Item.value = CalculateValue.GetLavaMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeLava && ConfigValues.RecipeObsidian)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.ObsidianWallMirror>())
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			else if (ConfigValues.RecipeLava && !ConfigValues.RecipeObsidian && ConfigValues.MaterialAmount >= 4)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Obsidian, ConfigValues.MaterialAmount - 2)
					.AddIngredient(ItemID.Hellstone, 2)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			else if (ConfigValues.RecipeLava && !ConfigValues.RecipeObsidian)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Obsidian, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Hellstone, 1)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			if (ConfigValues.AltRecipeLava && ConfigValues.RecipeObsidian)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.ObsidianWallMirror>())
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			else if (ConfigValues.AltRecipeLava && !ConfigValues.RecipeObsidian && ConfigValues.MaterialAmount >= 4)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Obsidian, ConfigValues.MaterialAmount - 2)
					.AddIngredient(ItemID.Hellstone, 2)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
			else if (ConfigValues.AltRecipeLava && !ConfigValues.RecipeObsidian)
			{
				CreateRecipe()
					.AddIngredient(ItemID.Obsidian, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Hellstone, 1)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStation)
					.Register();
			}
        }
    }
}