using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors
{
	/*
	Hello, I see that you decided to extract this mod and look into its source code.
	You might find some stuff here useful, or not.
	Just don't steal this mod and claim it as your own.
	Just going to add this here...

	PLACEBLE MIRRORS - MADE BY BLUPIZZA ©, November 4, 2022
	Steam Link: https://steamcommunity.com/sharedfiles/filedetails/?id=2832302532

	MIT License

	Copyright © 2022 BluPizza

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.

	Wormhole Mirror based on 1.4 mod Portable Wormhole by Stonga, which is based off a 1.3 mod by DaeCat
	Steam link: https://steamcommunity.com/sharedfiles/filedetails/?id=2845703054&tscn=1667002162
	Here is the source for 1.4 mod: https://github.com/JVWebb/PortableWormhole1.4
	And 1.3: https://github.com/DaeCatt/PortableWormhole
	Used with permission from Stonga
	*/

	// Placeable Mirrors
	// Includes mirror functions
	public class PlaceableMirrors : Mod
	{
		//Main.NewText($"Test");

		// Magic Mirror Function
		public static bool ToSpawn(int x, int y, int dustType)
		{
			Player player = Main.LocalPlayer;
			player.RemoveAllGrapplingHooks();
			CreateDust(dustType, player, false);
			SoundEngine.PlaySound(SoundID.Item6);
			player.Spawn(PlayerSpawnContext.RecallFromItem);
			CreateDust(dustType, player, true);
			return true;
		}

		// Water Mirror Function
		public static bool ToOcean(int x, int y)
		{
			Player player = Main.LocalPlayer;
			player.RemoveAllGrapplingHooks();
			CreateDust(-1, player, false);
			SoundEngine.PlaySound(SoundID.Item6);
			if (Main.netMode == 0)
			{
				player.MagicConch();
			}
			else if (Main.netMode == 1 && player.whoAmI == Main.myPlayer) // Multiplayer
			{
				NetMessage.SendData(73, -1, -1, null, 1);
			}
			return true;
		}

		// Lava Mirror Function
		public static bool ToUnderworld(int x, int y)
		{
			Player player = Main.LocalPlayer;
			player.RemoveAllGrapplingHooks();
			CreateDust(-1, player, false);
			SoundEngine.PlaySound(SoundID.Item6);
			if (Main.netMode == 0)
			{
				player.DemonConch();
			}
			else if (Main.netMode == 1 && player.whoAmI == Main.myPlayer) // Multiplayer
			{
				NetMessage.SendData(73, -1, -1, null, 2);
			}
			return true;
		}

		// Teleportation Mirror Function
		public static bool ToRandom(int x, int y)
		{
			Player player = Main.LocalPlayer;
			player.RemoveAllGrapplingHooks();
			SoundEngine.PlaySound(SoundID.Item6);
			if (Main.netMode == 0)
			{
				player.TeleportationPotion();
			}
			else if (Main.netMode == 1 && player.whoAmI == Main.myPlayer) // Multiplayer
			{
				NetMessage.SendData(73);
			}
			return true;
		}

		// Wormhole Mirror Function
		public static bool ToPlayer(int x, int y)
		{
			Player player = Main.LocalPlayer;
			player.TryOpeningFullscreenMap();
			if (Main.mapFullscreen)
			{
				player.GetModPlayer<PlaceableMirrorPlayer>().CanWormholeUsingMirror = true;
				//Main.NewText($"Can Use Wormhole");
			}
			return true;
		}

		// Return Mirror Function
		public static bool ToSpawnAndBack(int x, int y)
		{
			Player player = Main.LocalPlayer;
			player.RemoveAllGrapplingHooks();
			CreateDust(1, player, false);
			SoundEngine.PlaySound(SoundID.Item6);
			if (player.whoAmI == Main.myPlayer)
			{
				player.DoPotionOfReturnTeleportationAndSetTheComebackPoint();
			}
			CreateDust(1, player, true);
			return true;
		}

		// Zenith Mirror Function
		public static bool ToAnywhere(int x, int y)
		{
			int RandomNumber = Main.rand.Next(3);
			if (RandomNumber == 0 && ConfigValues.ZenithMirrorFunctionTeleportation)
				ToRandom(x, y);
			else if (RandomNumber == 1 && ConfigValues.ZenithMirrorFunctionWater)
				ToOcean(x, y);
			else if (RandomNumber == 2 && ConfigValues.ZenithMirrorFunctionLava)
				ToUnderworld(x, y);
			else
				ToSpawn(x, y, 2);
			return true;
		}

		// Mouse Over Mirrors
		public static void MouseOverMirrors(int x, int y, int ID)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ID;
		}

		// Glowmask for some mirrors
		public static void GlowmaskMirror(int x, int y, SpriteBatch sb)
		{
			Tile tile = Main.tile[x, y];
			Texture2D texture = ModContent.Request<Texture2D>("PlaceableMirrors/Tiles/MartianMirror_Glow").Value;
			Color colorGlow = Color.White;
			bool glow = false;
			if (tile.TileFrameX / 36 == 27)
			{
				glow = true;
			}
			else if (tile.TileFrameX / 36 == 28)
			{
				texture = ModContent.Request<Texture2D>("PlaceableMirrors/Tiles/MeteoriteMirror_Glow").Value;
				colorGlow = new Color(100, 100, 100, 0);
				glow = true;
			}
			if (glow)
			{
				Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
				sb.Draw(texture, 
						new Vector2(x * 16 - (int)Main.screenPosition.X, y * 16 - (int)Main.screenPosition.Y) + zero,
						new Rectangle(tile.TileFrameX % 36, tile.TileFrameY, 16, 16),
						colorGlow, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f
						);
			}
		}

		// Create Dust for when a mirror is interacted with
		public static void CreateDust(int dustType, Player player, bool afterTeleport)
		{
			if (!afterTeleport)
			{
				if (dustType == 0) // Magic Mirror, Ice Mirror
				{
					for (int d = 0; d < 70; d++)
					{
						Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.5f);
					}
				}
				else if (dustType == 1) // Recall Mirror, Return Mirror
				{
					for (int d = 0; d < 70; d++)
					{
						Main.dust[Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X, player.velocity.Y, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
					}
				}
				else if (dustType == 2) // Terra Mirror, Zenith Mirror
				{
					for (int d = 0; d < 70; d++)
					{
						Dust.NewDust(player.position, player.width, player.height, DustID.TerraBlade, player.velocity.X, player.velocity.Y, 150, default, 1.5f);
					}
				}
			}
			else
			{
				if (dustType == 0) // Magic Mirror, Ice Mirror
				{
					for (int d = 0; d < 70; d++)
					{
						Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
					}
				}
				else if (dustType == 1) // Recall Mirror, Return Mirror
				{
					for (int d = 0; d < 70; d++)
					{
						Main.dust[Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
					}
				}
				else if (dustType == 2) // Terra Mirror, Zenith Mirror
				{
					for (int d = 0; d < 70; d++)
					{
						Dust.NewDust(player.position, player.width, player.height, DustID.TerraBlade, 0f, 0f, 150, default, 1.5f);
					}
				}
			}
		}

		// Adds 1.4.4 Magic Mirror recipe
		public override void AddRecipes()
		{
			// Add 1.4.4 Magic Mirror Recipes
			if (ConfigValues.MagicMirrorRecipe)
			{
				Recipe.Create(ItemID.MagicMirror)
					.AddIngredient(ItemID.Glass, 10)
					.AddIngredient(ItemID.GoldBar, 10)
					.AddIngredient(ItemID.Diamond, 3)
					.AddTile(TileID.Furnaces)
					.Register();

				Recipe.Create(ItemID.MagicMirror)
					.AddIngredient(ItemID.Glass, 10)
					.AddIngredient(ItemID.PlatinumBar, 10)
					.AddIngredient(ItemID.Diamond, 3)
					.AddTile(TileID.Furnaces)
					.Register();
			}
		}

		// Functions for Wormhole Mirrors -
		// Based on 1.4 mod Portable Wormhole by Stonga, which is based off a 1.3 mod by DaeCat
		// Steam link: https://steamcommunity.com/sharedfiles/filedetails/?id=2845703054&tscn=1667002162
		// Here is the source for 1.4 mod: https://github.com/JVWebb/PortableWormhole1.4
		// And 1.3: https://github.com/DaeCatt/PortableWormhole
		// Used with permission
		public override void Load()
		{
			On.Terraria.Player.HasUnityPotion += CanWormholeUsingMirror;
			On.Terraria.Player.TakeUnityPotion += TakeAwayPotion;
		}

		private static bool CanWormholeUsingMirror(On.Terraria.Player.orig_HasUnityPotion orig, Player player)
		{
			PlaceableMirrorPlayer MirrorPlayer = player.GetModPlayer<PlaceableMirrorPlayer>();
			return MirrorPlayer.CanWormholeUsingMirror || orig(player);
		}

		private static void TakeAwayPotion(On.Terraria.Player.orig_TakeUnityPotion orig, Player player)
		{
			PlaceableMirrorPlayer MirrorPlayer = player.GetModPlayer<PlaceableMirrorPlayer>();
			if (MirrorPlayer.CanWormholeUsingMirror)
				return;
			else
				orig(player);
		}

		// Some Client and Server Syncing
		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			byte PlayerNumber = reader.ReadByte();
			PlaceableMirrorPlayer MirrorPlayer = Main.player[PlayerNumber].GetModPlayer<PlaceableMirrorPlayer>();
			byte MirrorPacketInfo = reader.ReadByte();
			if (MirrorPacketInfo == 2)
				MirrorPlayer.CanWormholeUsingMirror = true;
			else if (MirrorPacketInfo == 1)
				MirrorPlayer.CanTeleportUsingMirror = true;
			else
			{
				MirrorPlayer.CanWormholeUsingMirror = false;
				MirrorPlayer.CanTeleportUsingMirror = false;
			}
			if (Main.netMode == 2)
				MirrorPlayer.SyncPlayer(-1, whoAmI, false);
		}
	}

	// NPC Drops
	// Pirate Drops for Golden Mirror and Merchant Selling Copper Mirror
	public class NPCDrops : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot loot){
			if ( (npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateDeckhand || npc.type == NPCID.PirateCrossbower || npc.type == NPCID.PirateCorsair) && (ConfigValues.GoldenMirrorDrop))
			{
				loot.Add(ItemDropRule.Common(ModContent.ItemType<Items.GoldenWallMirror>(), ConfigValues.GoldenMirrorDropChance));
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Merchant && ConfigValues.SellCopperMirror)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.CopperWallMirror>());
				nextSlot++;
			}
		}
	}

	// Config Values
	// Shortens config values lines
	public class ConfigValues
	{
		public static bool MagicMirrorRecipe = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeMagicMirrorUpdate;
		
		// Get Recipes
		public static bool RecipeMagic = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeMagicMirror;
		public static bool RecipeIce = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeIceMirror;
		public static bool RecipeWater = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeWaterMirror;
		public static bool RecipeLava = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeLavaMirror;
		public static bool RecipeRecall = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeRecallMirror;
		public static bool RecipeTeleportation = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeTeleportationMirror;
		public static bool RecipeWormhole = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeWormholeMirror;
		public static bool RecipeReturn = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeReturnMirror;
		public static bool RecipeFunctional = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeFunctionalMirror;
		public static bool RecipeCell = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeCellMirror;
		public static bool RecipeShell = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeShellMirror;
		public static bool RecipeTerra = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeTerraMirror;
		public static bool RecipeZenith = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeZenithMirror;

		// Get Alt Recipes
		public static bool AltRecipeMagic = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeMagicMirror;
		public static bool AltRecipeIce = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeIceMirror;
		public static bool AltRecipeWater = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeWaterMirror;
		public static bool AltRecipeLava = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeLavaMirror;
		public static bool AltRecipeRecall = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeRecallMirror;
		public static bool AltRecipeTeleportation = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeTeleportationMirror;
		public static bool AltRecipeWormhole = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeWormholeMirror;
		public static bool AltRecipeReturn = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeReturnMirror;
		public static bool AltRecipeFunctional = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeFunctionalMirror;
		public static bool AltRecipeCell = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeCellMirror;
		public static bool AltRecipeShell = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeShellMirror;
		public static bool AltRecipeTerra = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeTerraMirror;
		public static bool AltRecipeZenith = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableAltRecipeZenithMirror;
		public static bool OldRecipeZenith = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableOldRecipeZenithMirror;

		// Amount of Items
		public static int GlassAmount = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().GlassAmount;
		public static int MaterialAmount = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().FurnitureSetsMaterialAmount;
		public static int RecallPotionAmount = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().RecallPotionAmount;
		public static int TeleportationPotionAmount = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().TeleportationPotionAmount;
		public static int WormholePotionAmount = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().WormholePotionAmount;
		public static int PotionOfReturnAmount = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().PotionOfReturnAmount;
		public static int MetalBarAmount = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().MetalBarAmount;
		public static int RecallPotionAmountAlt = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().RecallPotionAmountAlt;
		public static int SeashellAmountAlt = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().SeashellAmountAlt;
		public static int HellstoneBarAmountAlt = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().HellstoneBarAmountAlt;
		public static int WireAmountAlt = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().WireAmountAlt;

		// Recipe of Furniture Set Mirrors
		public static bool RecipeObsidian = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeObsidianMirror;
		public static bool RecipeGolden = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeGoldenMirror;
		public static bool RecipePalmWood = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipePalmWoodMirror;
		public static bool RecipeReef = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().EnableRecipeReefMirror;

		// Crafting Stations
		public static int CraftingStation = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().CraftingStation;
		public static int CraftingStationCombine = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().CraftingStationCombine;
		public static bool SpecialCrafting = ModContent.GetInstance<PlaceableMirrorsServerRecipesConfig>().SpecialCrafting;

		// Golden Mirror
		public static bool GoldenMirrorDrop = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().EnablePirateGoldenMirrorDrop;
		public static int GoldenMirrorDropChance = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().GoldenMirrorDropChance;

		// Copper Mirror
		public static bool SellCopperMirror = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().EnableMerchantSellsCopperMirror;

		// Zenith Mirror
		public static bool ZenithMirrorFunctionMagic = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().ZenithMirrorFunctionMagic;
		public static bool ZenithMirrorFunctionWater = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().ZenithMirrorFunctionWater;
		public static bool ZenithMirrorFunctionLava = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().ZenithMirrorFunctionLava;
		public static bool ZenithMirrorFunctionTeleportation = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().ZenithMirrorFunctionTeleportation;
		public static bool ZenithMirrorFunctionWormhole = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().ZenithMirrorFunctionWormhole;
		public static bool ZenithMirrorFunctionReturn = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().ZenithMirrorFunctionReturn;
		public static bool ZenithMirrorFunctionUltimate = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().ZenithMirrorFunctionUltimate;

		// Origns
		public static int OriginX = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().OriginX;
		public static int OriginY = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().OriginY;

		// Wall Requirement
		public static bool RequireWall = ModContent.GetInstance<PlaceableMirrorsServerMiscConfig>().RequireWallForPlacement;
	}

	// Calculate Value
	// A system to change mirrors prices based on the configs set
	public class CalculateValue
	{
		// Value of items = price to buy
		// Value / 5 = price to sell
		public const int SpecialItemCost = 50000; // 5 gold
		public const int BrokenHeroSwordCost = 375000; // 37 gold, 50 silver
		public const int CellPhoneCost = 400000; // 40 gold
		public const int GlassCost = 40; // 40 copper
		public const int MaterialCost = 40; // 40 copper
		public const int HellstoneCost = 1250; // 12 silver, 50 copper
		public const int RecallPotionCost = 1000; // 10 silver
		public const int TeleportationPotionCost = 1000; // 10 silver
		public const int WormholePotionCost = 1000; // 10 silver
		public const int PotionOfReturnCost = 1000; // 10 silver
		public const int CopperBarCost = 750; // 7 silver, 50 copper
		public const int HellstoneBarCost = 20000; // 2 gold
		public const int AdamantiteBarCost = 30000; // 3 gold
		public const int SeashellCost = 2500; // 25 silver
		public const int WireCost = 500; // 5 silver

		// Total Cost, Value * Amount
		public static int GlassTotalCost = GlassCost * ConfigValues.GlassAmount;
		public static int MaterialTotalCost = MaterialCost * ConfigValues.MaterialAmount;
		public static int RecallPotionTotalCost = RecallPotionCost * ConfigValues.RecallPotionAmount;
		public static int TeleportationPotionTotalCost = TeleportationPotionCost * ConfigValues.TeleportationPotionAmount;
		public static int WormholePotionTotalCost = WormholePotionCost * ConfigValues.WormholePotionAmount;
		public static int PotionOfReturnTotalCost = PotionOfReturnCost * ConfigValues.PotionOfReturnAmount;
		public static int CopperBarTotalCost = CopperBarCost * ConfigValues.MetalBarAmount;
		public static int AdamantiteBarTotalCost = AdamantiteBarCost * ConfigValues.MetalBarAmount;
		public static int RecallPotionTotalCostAlt = RecallPotionCost * ConfigValues.RecallPotionAmountAlt;
		public static int SeashellTotalCostAlt = SeashellCost * ConfigValues.SeashellAmountAlt;
		public static int HellstoneBarTotalCostAlt = HellstoneBarCost * ConfigValues.HellstoneBarAmountAlt;
		public static int WireTotalCostAlt = WireCost * ConfigValues.WireAmountAlt;

		// Large Magic Mirror Value
		public static int GetLargeMagicMirrorValue()
		{
			int Cost = SpecialItemCost + GlassTotalCost;
			if (ConfigValues.AltRecipeMagic)
			{
				int AltCost = RecallPotionTotalCostAlt + GlassTotalCost;
				if (!ConfigValues.RecipeMagic)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Large Ice Mirror Value
		public static int GetLargeIceMirrorValue()
		{
			int Cost = SpecialItemCost + GlassTotalCost;
			if (ConfigValues.AltRecipeIce)
			{
				int AltCost = GetLargeMagicMirrorValue() + MaterialTotalCost;
				if (!ConfigValues.RecipeIce)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Water Mirror Value
		public static int GetWaterMirrorValue()
		{
			int Cost = GetWallMirrorValue() + SpecialItemCost;
			if (ConfigValues.AltRecipeWater)
			{
				int AltCost = GetWallMirrorValue() + SeashellTotalCostAlt;
				if (!ConfigValues.RecipeWater)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Lava Mirror Value
		public static int GetLavaMirrorValue()
		{
			int Cost = GetObsidianWallMirrorValue() + SpecialItemCost;
			if (ConfigValues.AltRecipeLava)
			{
				int AltCost = GetObsidianWallMirrorValue() + HellstoneBarTotalCostAlt;
				if (!ConfigValues.RecipeLava)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Recall Mirror Value
		public static int GetRecallMirrorValue()
		{
			int Cost = GetLargeMagicMirrorValue() + RecallPotionTotalCost;
			if (ConfigValues.AltRecipeRecall)
			{
				int AltCost = GlassTotalCost + RecallPotionTotalCost;
				if (!ConfigValues.RecipeRecall)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Teleportation Mirror Value
		public static int GetTeleportationMirrorValue()
		{
			int Cost = GetLargeMagicMirrorValue() + TeleportationPotionTotalCost;
			if (ConfigValues.AltRecipeTeleportation)
			{
				int AltCost = GlassTotalCost + TeleportationPotionTotalCost;
				if (!ConfigValues.RecipeTeleportation)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Wormhole Mirror Value
		public static int GetWormholeMirrorValue()
		{
			int Cost = GetLargeMagicMirrorValue() + WormholePotionTotalCost;
			if (ConfigValues.AltRecipeWormhole)
			{
				int AltCost = GlassTotalCost + WormholePotionTotalCost;
				if (!ConfigValues.RecipeWormhole)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Return Mirror Value
		public static int GetReturnMirrorValue()
		{
			int Cost = GetLargeMagicMirrorValue() + PotionOfReturnTotalCost;
			if (ConfigValues.AltRecipeReturn)
			{
				int AltCost = GlassTotalCost + PotionOfReturnTotalCost;
				if (!ConfigValues.RecipeReturn)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Cell Mirror Value
		public static int GetCellMirrorValue()
		{
			int Cost = CellPhoneCost + GlassTotalCost;
			if (ConfigValues.AltRecipeCell)
			{
				int AltCost = WireTotalCostAlt + GlassTotalCost;
				if (!ConfigValues.RecipeCell)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			return Cost;
		}

		// Shell Mirror Value
		public static int GetShellMirrorValue()
		{
			int Cost = GetFunctionalWallMirrorValue() + SpecialItemCost * 2;
			if (ConfigValues.AltRecipeShell)
			{
				int AltCost = GetFunctionalWallMirrorValue() + SeashellTotalCostAlt + HellstoneBarTotalCostAlt;
				if (!ConfigValues.RecipeShell)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			return Cost;
		}

		// Terra Mirror Value
		public static int GetTerraMirrorValue()
		{
			int Cost = GetLargeMagicMirrorValue() + BrokenHeroSwordCost;
			if (ConfigValues.AltRecipeTerra)
			{
				int AltCost = GetWallMirrorValue() + BrokenHeroSwordCost;
				if (!ConfigValues.RecipeTerra)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Zenith Mirror Value
		public static int GetZenithMirrorValue()
		{
			if (ConfigValues.OldRecipeZenith)
				return GetZenithMirrorValueOld();
			int Cost = GetTerraMirrorValue() + GetWaterMirrorValue() + GetLavaMirrorValue() + GetTeleportationMirrorValue() + GetWormholeMirrorValue() + GetReturnMirrorValue() + GetMetalWallMirrorValue(0);
			if (ConfigValues.AltRecipeZenith)
			{
				int AltCost = GetLargeMagicMirrorValue() + GetWaterMirrorValue() + GetLavaMirrorValue() + GetTeleportationMirrorValue() + GetWormholeMirrorValue() + GetReturnMirrorValue() + GetMetalWallMirrorValue(0);
				if (!ConfigValues.RecipeZenith)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Zenith Mirror Value (Old)
		public static int GetZenithMirrorValueOld()
		{
			int Cost = GetTerraMirrorValue() + GetWaterMirrorValue() + GetLavaMirrorValue() + GetReturnMirrorValue();
			if (ConfigValues.AltRecipeZenith)
			{
				int AltCost = GetLargeMagicMirrorValue() + GetWaterMirrorValue() + GetLavaMirrorValue() + GetReturnMirrorValue();
				if (!ConfigValues.RecipeZenith)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Wall Mirror Value
		public static int GetWallMirrorValue()
		{
			return MaterialTotalCost + GlassTotalCost;
		}

		// Obsidian Wall Mirror Value
		public static int GetObsidianWallMirrorValue()
		{
			if (ConfigValues.MaterialAmount >= 4)
				return (ConfigValues.MaterialAmount - 2) * MaterialCost + HellstoneCost * 2 + GlassTotalCost;
			else
				return MaterialTotalCost + HellstoneCost + GlassTotalCost;
		}

		// Golden Wall Mirror Value
		public static int GetGoldenWallMirrorValue()
		{
			if (!ConfigValues.RecipeGolden)
				return 100000;
			else
				return MaterialTotalCost + GlassTotalCost;
		}

		// Metal Wall Mirror Value
		public static int GetMetalWallMirrorValue(int MetalType)
		{
			switch (MetalType)
			{
				case 0:
					return CopperBarTotalCost + GlassTotalCost;
				case 16:
					return AdamantiteBarTotalCost + GlassTotalCost;
			}
			return 500 + GlassTotalCost;
		}

		// Functional Wall Mirror Value
		public static int GetFunctionalWallMirrorValue()
		{
			int Cost = GetWallMirrorValue() + SpecialItemCost;
			if (ConfigValues.AltRecipeFunctional)
			{
				int AltCost = GetWallMirrorValue() + RecallPotionTotalCostAlt;
				if (!ConfigValues.RecipeFunctional)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Functional Obsidian Wall Mirror Value
		public static int GetFunctionalObsidianWallMirrorValue()
		{
			int Cost = GetObsidianWallMirrorValue() + SpecialItemCost;
			if (ConfigValues.AltRecipeFunctional)
			{
				int AltCost = GetObsidianWallMirrorValue() + RecallPotionTotalCostAlt;
				if (!ConfigValues.RecipeFunctional)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Functional Golden Wall Mirror Value
		public static int GetFunctionalGoldenWallMirrorValue()
		{
			int Cost = GetGoldenWallMirrorValue() + SpecialItemCost;
			if (ConfigValues.AltRecipeFunctional)
			{
				int AltCost = GetGoldenWallMirrorValue() + RecallPotionTotalCostAlt;
				if (!ConfigValues.RecipeFunctional)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Functional Metal Wall Mirror Value
		public static int GetFunctionalMetalWallMirrorValue(int MetalType)
		{
			int Cost = GetMetalWallMirrorValue(MetalType) + SpecialItemCost;
			if (ConfigValues.AltRecipeFunctional)
			{
				int AltCost = GetMetalWallMirrorValue(MetalType) + RecallPotionTotalCostAlt;
				if (!ConfigValues.RecipeFunctional)
					return AltCost;
				else
					return Lesser(Cost, AltCost);
			}
			else
				return Cost;
		}

		// Lesser function, finds the lesser number
		private static int Lesser(int num1, int num2)
		{
			if (num1 <= num2)
				return num1;
			else
				return num2;
		}
	}

	// Placable Mirror Player
	// Bool for if a player can wormhole using a mirror
	// Also syncs players across a server
	public class PlaceableMirrorPlayer : ModPlayer
	{
		public bool CanWormholeUsingMirror = false;
		public bool CanTeleportUsingMirror = false;

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)Player.whoAmI);
			if (CanWormholeUsingMirror)
				packet.Write((byte)2);
			else if (CanTeleportUsingMirror)
				packet.Write((byte)1);
			else
				packet.Write((byte)0);
			packet.Send(toWho, fromWho);
		}

		public override void clientClone(ModPlayer clientClone)
		{
			PlaceableMirrorPlayer clone = clientClone as PlaceableMirrorPlayer;
			clone.CanWormholeUsingMirror = CanWormholeUsingMirror;
		}

		public override void SendClientChanges(ModPlayer clientPlayer)
		{
			PlaceableMirrorPlayer clone = clientPlayer as PlaceableMirrorPlayer;
			if (clone.CanWormholeUsingMirror != CanWormholeUsingMirror)
				SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
		}
	}

	// Teleport Mirror System
	// Checks to see if a player can wormhole using a mirror
	public class TeleportMirrorSystem : ModSystem
	{
		public override void PostUpdatePlayers()
		{
			Player player = Main.LocalPlayer;
			PlaceableMirrorPlayer MirrorPlayer = player.GetModPlayer<PlaceableMirrorPlayer>();
			if (!Main.mapFullscreen && MirrorPlayer.CanWormholeUsingMirror)
			{
				MirrorPlayer.CanWormholeUsingMirror = false;
				//Main.NewText($"Can No Longer Use Wormhole");
			}

			for (int i = 0; i < Main.player.Length; i++)
			{
				Player GetPlayer = Main.player[i];
				if (GetPlayer.active)
				{
					PlaceableMirrorPlayer GetMirrorPlayer = GetPlayer.GetModPlayer<PlaceableMirrorPlayer>();
					if (GetMirrorPlayer.CanWormholeUsingMirror)
					{
						Dust dust = Dust.NewDustDirect(GetPlayer.position, GetPlayer.width, GetPlayer.height, DustID.DungeonSpirit);
						dust.noGravity = true;
					}
					else if (GetMirrorPlayer.CanTeleportUsingMirror)
					{
						Dust dust = Dust.NewDustDirect(GetPlayer.position, GetPlayer.width, GetPlayer.height, DustID.Teleporter);
						dust.noGravity = true;
					}
				}
			}
		}
	}
}