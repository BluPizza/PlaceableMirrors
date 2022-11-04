using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Items
{
    public class ShellMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.PlaceableMirrors.Items.ShellMirror}");
            Tooltip.SetDefault("{$Mods.PlaceableMirrors.Items.Tooltip.ShellMirror}");
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
			Item.createTile = ModContent.TileType<Tiles.ShellMirror>();
			Item.value = CalculateValue.GetShellMirrorValue();
        }

        public override void AddRecipes()
        {
			if (ConfigValues.RecipeShell && ConfigValues.RecipeReef && (ConfigValues.RecipeFunctional || ConfigValues.AltRecipeFunctional))
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.FunctionalReefWallMirror>())
					.AddIngredient(ItemID.MagicConch)
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.RecipeShell && ConfigValues.RecipeReef && (ConfigValues.RecipeFunctional || !(ConfigValues.RecipeFunctional || ConfigValues.AltRecipeFunctional)))
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.ReefWallMirror>())
					.AddIngredient(ItemID.MagicMirror)
					.AddIngredient(ItemID.MagicConch)
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.RecipeShell && ConfigValues.RecipeReef && ConfigValues.AltRecipeFunctional)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.ReefWallMirror>())
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmountAlt)
					.AddIngredient(ItemID.MagicConch)
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}

			if (ConfigValues.RecipeShell && !ConfigValues.RecipeReef && (ConfigValues.RecipeFunctional || !(ConfigValues.RecipeFunctional || ConfigValues.AltRecipeFunctional)))
			{
				CreateRecipe()
					.AddIngredient(ItemID.CoralstoneBlock, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.MagicMirror)
					.AddIngredient(ItemID.MagicConch)
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.RecipeShell && !ConfigValues.RecipeReef && ConfigValues.AltRecipeFunctional)
			{
				CreateRecipe()
					.AddIngredient(ItemID.CoralstoneBlock, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmountAlt)
					.AddIngredient(ItemID.MagicConch)
					.AddIngredient(ItemID.DemonConch)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}

			if (ConfigValues.AltRecipeShell && ConfigValues.RecipeReef && (ConfigValues.RecipeFunctional || ConfigValues.AltRecipeFunctional))
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.FunctionalReefWallMirror>())
					.AddIngredient(ItemID.Seashell, ConfigValues.SeashellAmountAlt)
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeShell && ConfigValues.RecipeReef && (ConfigValues.RecipeFunctional || !(ConfigValues.RecipeFunctional || ConfigValues.AltRecipeFunctional)))
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.ReefWallMirror>())
					.AddIngredient(ItemID.MagicMirror)
					.AddIngredient(ItemID.Seashell, ConfigValues.SeashellAmountAlt)
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeShell && ConfigValues.RecipeReef && ConfigValues.AltRecipeFunctional)
			{
				CreateRecipe()
					.AddIngredient(ModContent.ItemType<Items.ReefWallMirror>())
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmountAlt)
					.AddIngredient(ItemID.Seashell, ConfigValues.SeashellAmountAlt)
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}

			if (ConfigValues.AltRecipeShell && !ConfigValues.RecipeReef && (ConfigValues.RecipeFunctional || !(ConfigValues.RecipeFunctional || ConfigValues.AltRecipeFunctional)))
			{
				CreateRecipe()
					.AddIngredient(ItemID.CoralstoneBlock, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.MagicMirror)
					.AddIngredient(ItemID.Seashell, ConfigValues.SeashellAmountAlt)
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
			if (ConfigValues.AltRecipeShell && !ConfigValues.RecipeReef && ConfigValues.AltRecipeFunctional)
			{
				CreateRecipe()
					.AddIngredient(ItemID.CoralstoneBlock, ConfigValues.MaterialAmount)
					.AddIngredient(ItemID.Glass, ConfigValues.GlassAmount)
					.AddIngredient(ItemID.RecallPotion, ConfigValues.RecallPotionAmountAlt)
					.AddIngredient(ItemID.Seashell, ConfigValues.SeashellAmountAlt)
					.AddIngredient(ItemID.HellstoneBar, ConfigValues.HellstoneBarAmountAlt)
					.AddTile(ConfigValues.CraftingStationCombine)
					.Register();
			}
        }
    }
}