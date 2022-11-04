using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PlaceableMirrors
{
	[Label("$Mods.PlaceableMirrors.Config.Label.Client")]
	public class PlaceableMirrorsClientConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Header("$Mods.PlaceableMirrors.Config.Header.SmartInteract")] // Smart Interact

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractMagic")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractMagic")]
		[DefaultValue(true)]
		public bool EnableSmartInteractMagicMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractIce")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractIce")]
		[DefaultValue(true)]
		public bool EnableSmartInteractIceMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractWater")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractWater")]
		[DefaultValue(true)]
		public bool EnableSmartInteractWaterMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractLava")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractLava")]
		[DefaultValue(true)]
		public bool EnableSmartInteractLavaMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractRecall")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractRecall")]
		[DefaultValue(true)]
		public bool EnableSmartInteractRecallMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractTeleportation")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractTeleportation")]
		[DefaultValue(true)]
		public bool EnableSmartInteractTeleportationMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractWormhole")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractWormhole")]
		[DefaultValue(true)]
		public bool EnableSmartInteractWormholeMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractReturn")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractReturn")]
		[DefaultValue(true)]
		public bool EnableSmartInteractReturnMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractFunctional")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractFunctional")]
		[DefaultValue(true)]
		public bool EnableSmartInteractFunctionalMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractCell")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractCell")]
		[DefaultValue(true)]
		public bool EnableSmartInteractCellMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractShell")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractShell")]
		[DefaultValue(true)]
		public bool EnableSmartInteractShellMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractTerra")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractTerra")]
		[DefaultValue(true)]
		public bool EnableSmartInteractTerraMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.SmartInteractZenith")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SmartInteractZenith")]
		[DefaultValue(true)]
		public bool EnableSmartInteractZenithMirror;

		[Header("$Mods.PlaceableMirrors.Config.Header.DustEffects")] // Dust Effects

		[Label("$Mods.PlaceableMirrors.Config.Label.DustEffects")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.DustEffects")]
		[DefaultValue(true)]
		public bool EnableDustEffects;
	}
	[Label("$Mods.PlaceableMirrors.Config.Label.ServerRecipes")]
	public class PlaceableMirrorsServerRecipesConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("$Mods.PlaceableMirrors.Config.Header.RecipesUpdate")] // Recipes Update

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeMagicMirrorUpdate")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeMagicMirrorUpdate")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeMagicMirrorUpdate;

		[Header("$Mods.PlaceableMirrors.Config.Header.RecipesSpecial")] // Recipes Special

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeMagic")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeMagic")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeMagicMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeIce")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeIce")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeIceMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeWater")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeWater")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeWaterMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeLava")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeLava")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeLavaMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeRecall")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeRecall")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeRecallMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeTeleportation")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeTeleportation")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeTeleportationMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeWormhole")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeWormhole")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeWormholeMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeReturn")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeReturn")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeReturnMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeFunctional")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeFunctional")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeFunctionalMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeCell")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeCell")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeCellMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeShell")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeShell")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeShellMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeTerra")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeTerra")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeTerraMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeZenith")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeZenith")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeZenithMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeMagicMirrorBlock")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeMagicMirrorBlock")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeMagicMirrorBlock;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeWoodenMirrorBlock")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeWoodenMirrorBlock")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeWoodenMirrorBlock;

		[Header("$Mods.PlaceableMirrors.Config.Header.AltRecipesSpecial")] // Alt Recipes Special

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeMagic")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeMagic")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeMagicMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeIce")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeIce")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeIceMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeWater")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeWater")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeWaterMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeLava")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeLava")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeLavaMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeRecall")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeRecall")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeRecallMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeTeleportation")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeTeleportation")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeTeleportationMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeWormhole")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeWormhole")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeWormholeMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeReturn")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeReturn")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeReturnMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeFunctional")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeFunctional")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeFunctionalMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeCell")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeCell")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeCellMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeShell")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeShell")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeShellMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeTerra")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeTerra")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeTerraMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeZenith")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeZenith")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeZenithMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.OldRecipeZenith")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.OldRecipeZenith")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableOldRecipeZenithMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.AltRecipeMagicMirrorBlock")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.AltRecipeMagicMirrorBlock")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableAltRecipeMagicMirrorBlock;

		[Header("$Mods.PlaceableMirrors.Config.Header.RecipesIngredientAmounts")] // Recipes Ingredient Amounts

		[Label("$Mods.PlaceableMirrors.Config.Label.GlassAmount")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.GlassAmount")]
		[Range(1, 100)]
		[DefaultValue(3)]
		[ReloadRequired]
		public int GlassAmount;

		[Label("$Mods.PlaceableMirrors.Config.Label.FurnitureSetsMaterialAmount")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.FurnitureSetsMaterialAmount")]
		[Range(1, 100)]
		[DefaultValue(6)]
		[ReloadRequired]
		public int FurnitureSetsMaterialAmount;

		[Label("$Mods.PlaceableMirrors.Config.Label.GlassAmountForBlocks")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.GlassAmountForBlocks")]
		[Range(1, 999)]
		[DefaultValue(100)]
		[ReloadRequired]
		public int GlassAmountForBlocks;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecallPotionAmount")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecallPotionAmount")]
		[Range(1, 100)]
		[DefaultValue(10)]
		[ReloadRequired]
		public int RecallPotionAmount;

		[Label("$Mods.PlaceableMirrors.Config.Label.TeleportationPotionAmount")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.TeleportationPotionAmount")]
		[Range(1, 100)]
		[DefaultValue(10)]
		[ReloadRequired]
		public int TeleportationPotionAmount;

		[Label("$Mods.PlaceableMirrors.Config.Label.WormholePotionAmount")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.WormholePotionAmount")]
		[Range(1, 100)]
		[DefaultValue(10)]
		[ReloadRequired]
		public int WormholePotionAmount;

		[Label("$Mods.PlaceableMirrors.Config.Label.PotionOfReturnAmount")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.PotionOfReturnAmount")]
		[Range(1, 100)]
		[DefaultValue(10)]
		[ReloadRequired]
		public int PotionOfReturnAmount;

		[Label("$Mods.PlaceableMirrors.Config.Label.MetalBarAmount")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.MetalBarAmount")]
		[Range(1, 100)]
		[DefaultValue(5)]
		[ReloadRequired]
		public int MetalBarAmount;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecallPotionAmountAlt")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecallPotionAmountAlt")]
		[Range(1, 100)]
		[DefaultValue(10)]
		[ReloadRequired]
		public int RecallPotionAmountAlt;

		[Label("$Mods.PlaceableMirrors.Config.Label.SeashellAmountAlt")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SeashellAmountAlt")]
		[Range(1, 100)]
		[DefaultValue(10)]
		[ReloadRequired]
		public int SeashellAmountAlt;

		[Label("$Mods.PlaceableMirrors.Config.Label.HellstoneBarAmountAlt")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.HellstoneBarAmountAlt")]
		[Range(1, 100)]
		[DefaultValue(5)]
		[ReloadRequired]
		public int HellstoneBarAmountAlt;

		[Label("$Mods.PlaceableMirrors.Config.Label.WireAmountAlt")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.WireAmountAlt")]
		[Range(1, 100)]
		[DefaultValue(10)]
		[ReloadRequired]
		public int WireAmountAlt;

		[Header("$Mods.PlaceableMirrors.Config.Header.RecipesFurniture")] // Recipes Furniture

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeWooden")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeWooden")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeWoodenMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeEbonwood")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeEbonwood")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeEbonwoodMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeRichMahogany")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeRichMahogany")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeRichMahoganyMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipePearlwood")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipePearlwood")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipePearlwoodMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeCactus")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeCactus")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeCactusMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeFlesh")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeFlesh")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeFleshMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeMushroom")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeMushroom")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeMushroomMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeLivingWood")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeLivingWood")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeLivingWoodMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeBone")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeBone")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeBoneMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSkyware")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSkyware")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeSkywareMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeShadewood")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeShadewood")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeShadewoodMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeLihzahrd")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeLihzahrd")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeLihzahrdMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeBlueDungeon")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeBlueDungeon")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeBlueDungeonMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeGreenDungeon")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeGreenDungeon")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeGreenDungeonMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipePinkDungeon")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipePinkDungeon")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipePinkDungeonMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeObsidian")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeObsidian")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeObsidianMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeGlass")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeGlass")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeGlassMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeGolden")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeGolden")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableRecipeGoldenMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeHoney")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeHoney")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeHoneyMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSteampunk")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSteampunk")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeSteampunkMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipePumpkin")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipePumpkin")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipePumpkinMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSpooky")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSpooky")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeSpookyMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeFrozen")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeFrozen")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeFrozenMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeDynasty")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeDynasty")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeDynastyMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipePalmWood")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipePalmWood")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipePalmWoodMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeBorealWood")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeBorealWood")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeBorealWoodMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSlime")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSlime")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeSlimeMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeMartian")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeMartian")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeMartianMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeMeteorite")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeMeteorite")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeMeteoriteMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeGranite")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeGranite")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeGraniteMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeMarble")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeMarble")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeMarbleMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeCrystal")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeCrystal")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeCrystalMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSpider")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSpider")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeSpiderMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeLesion")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeLesion")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeLesionMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSolar")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSolar")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeSolarMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeVortex")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeVortex")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeVortexMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeNebula")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeNebula")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeNebulaMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeStardust")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeStardust")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeStardustMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSandstone")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSandstone")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeSandstoneMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeBamboo")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeBamboo")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeBambooMirror;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeReef")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeReef")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeReefMirror;
		
		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeBalloon")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeBalloon")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeBalloonMirror;
		
		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeAshWood")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeAshWood")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeAshWoodMirror;

		[Header("$Mods.PlaceableMirrors.Config.Header.RecipesMetal")] // Recipes Metal

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeCopper")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeCopper")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeCopperMirror;
		
		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeAdamantite")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeAdamantite")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableRecipeAdamantiteMirror;

		[Header("$Mods.PlaceableMirrors.Config.Header.RecipesMisc")] // Recipes Misc

		[Label("$Mods.PlaceableMirrors.Config.Label.CraftingStation")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.CraftingStation")]
		[Range(0, 624)]
		[DefaultValue(17)]
		[ReloadRequired]
		public int CraftingStation;

		[Label("$Mods.PlaceableMirrors.Config.Label.CraftingStationCombine")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.CraftingStationCombine")]
		[Range(0, 624)]
		[DefaultValue(16)]
		[ReloadRequired]
		public int CraftingStationCombine;

		[Label("$Mods.PlaceableMirrors.Config.Label.SpecialCrafting")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.SpecialCrafting")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool SpecialCrafting;

		[Header("$Mods.PlaceableMirrors.Config.Header.RecipesConch")] // Recipes Conch

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSmallMagicConch")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSmallMagicConch")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableSmallMagicConchRecipe;

		[Label("$Mods.PlaceableMirrors.Config.Label.RecipeSmallDemonConch")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RecipeSmallDemonConch")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableSmallDemonConchRecipe;
	}
	[Label("$Mods.PlaceableMirrors.Config.Label.ServerMisc")]
	public class PlaceableMirrorsServerMiscConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		[Header("$Mods.PlaceableMirrors.Config.Header.NPCDrops")] // NPC Drops

		[Label("$Mods.PlaceableMirrors.Config.Label.PirateGoldenMirrorDrop")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.PirateGoldenMirrorDrop")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnablePirateGoldenMirrorDrop;

		[Label("$Mods.PlaceableMirrors.Config.Label.GoldenMirrorDropChance")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.GoldenMirrorDropChance")]
		[Range(1, 500)]
		[DefaultValue(300)]
		[ReloadRequired]
		public int GoldenMirrorDropChance;

		[Header("$Mods.PlaceableMirrors.Config.Header.NPCShops")] // NPC Shops

		[Label("$Mods.PlaceableMirrors.Config.Label.MerchantSellsCopperMirror")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.MerchantSellsCopperMirror")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableMerchantSellsCopperMirror;

		[Header("$Mods.PlaceableMirrors.Config.Header.ZenithMirror")] // Zenith Mirror

		[Label("$Mods.PlaceableMirrors.Config.Label.ZenithMirrorFunctionMagic")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.ZenithMirrorFunctionMagic")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ZenithMirrorFunctionMagic;

		[Label("$Mods.PlaceableMirrors.Config.Label.ZenithMirrorFunctionWater")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.ZenithMirrorFunctionWater")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ZenithMirrorFunctionWater;

		[Label("$Mods.PlaceableMirrors.Config.Label.ZenithMirrorFunctionLava")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.ZenithMirrorFunctionLava")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ZenithMirrorFunctionLava;

		[Label("$Mods.PlaceableMirrors.Config.Label.ZenithMirrorFunctionTeleportation")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.ZenithMirrorFunctionTeleportation")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ZenithMirrorFunctionTeleportation;

		[Label("$Mods.PlaceableMirrors.Config.Label.ZenithMirrorFunctionWormhole")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.ZenithMirrorFunctionWormhole")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ZenithMirrorFunctionWormhole;

		[Label("$Mods.PlaceableMirrors.Config.Label.ZenithMirrorFunctionReturn")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.ZenithMirrorFunctionReturn")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ZenithMirrorFunctionReturn;

		[Label("$Mods.PlaceableMirrors.Config.Label.ZenithMirrorFunctionUltimate")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.ZenithMirrorFunctionUltimate")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool ZenithMirrorFunctionUltimate;

		[Header("$Mods.PlaceableMirrors.Config.Header.PlacementPreview")] // Placement Preview

		[Label("$Mods.PlaceableMirrors.Config.Label.MirrorOriginX")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.MirrorOriginX")]
		[Range(0, 1)]
		[DefaultValue(0)]
		[Slider]
		[ReloadRequired]
		public int OriginX;

		[Label("$Mods.PlaceableMirrors.Config.Label.MirrorOriginY")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.MirrorOriginY")]
		[Range(0, 2)]
		[DefaultValue(1)]
		[Slider]
		[ReloadRequired]
		public int OriginY;

		[Header("$Mods.PlaceableMirrors.Config.Header.Experimental")] // Experimental

		[Label("$Mods.PlaceableMirrors.Config.Label.RequireWall")]
		[Tooltip("$Mods.PlaceableMirrors.Config.Tooltip.RequireWall")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool RequireWallForPlacement;
	}
}