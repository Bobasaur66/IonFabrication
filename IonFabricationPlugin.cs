using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers;
using UnityEngine;

namespace IonFabrication
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    [BepInDependency("com.snmodding.nautilus")]
    public class IonFabricationPlugin : BaseUnityPlugin
    {        
        private const string MyGUID = "com.Bobasaur.IonFabrication";
        private const string PluginName = "Ion Fabrication";
        private const string VersionString = "1.0.1";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        public static PrefabInfo Info {
            get;
            private set;
        }

        private void Awake()
        {            
            Logger.LogInfo($"Will load {PluginName} version {VersionString}.");
            Harmony.PatchAll();
            Logger.LogInfo($"{PluginName} version {VersionString} is now loaded.");
            Log = Logger;

            //new crafting tab
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "ionFabrication", "Ion Fabrication", SpriteManager.Get(TechType.PrecursorIonCrystal));

            //titanium
            CustomPrefab customPrefab = new CustomPrefab("ionTitanium", "Titanium (x10)", "Ti. Basic building material.", SpriteManager.Get(TechType.Titanium));
            CloneTemplate gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Titanium);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Titanium, 10).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Titanium, 1);
            customPrefab.Register();

            //copper
            customPrefab = new CustomPrefab("ionCopper", "Copper (x10)", "Cu. Essential wiring component.", SpriteManager.Get(TechType.Copper));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Copper);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Copper, 10).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Copper, 1);
            customPrefab.Register();

            //cave sulfur
            customPrefab = new CustomPrefab("ionCrashPowder", "Cave Sulfur (x4)", "SO4Tr. Sulfur-based powder which collects within particular cave plants. Combustible underwater.", SpriteManager.Get(TechType.CrashPowder));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.CrashPowder);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.CrashPowder, 4).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.CrashPowder, 1);
            customPrefab.Register();

            //crystalline sulfur
            customPrefab = new CustomPrefab("ionSulphur", "Crystalline Sulfur (x2)", "S. Oxidant and reducing agent.", SpriteManager.Get(TechType.Sulphur));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Sulphur);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Sulphur, 2).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Sulphur, 1);
            customPrefab.Register();

            //diamond
            customPrefab = new CustomPrefab("ionDiamond", "Diamond (x4)", "C. Carbon allotrope with superlative physical properties.", SpriteManager.Get(TechType.Diamond));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Diamond);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Diamond, 4).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Diamond, 1);
            customPrefab.Register();

            //gold
            customPrefab = new CustomPrefab("ionGold", "Gold (x6)", "Au. Valuable conductive properties. Highly valuable social property.", SpriteManager.Get(TechType.Gold));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Gold);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Gold, 6).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Gold, 1);
            customPrefab.Register();

            //kyanite
            customPrefab = new CustomPrefab("ionKyanite", "Kyanite", "Al2SiO5. Deep blue, heat resistant crystal.", SpriteManager.Get(TechType.Kyanite));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Kyanite);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Kyanite, 1).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Kyanite, 1);
            customPrefab.Register();

            //lead
            customPrefab = new CustomPrefab("ionLead", "Lead (x6)", "Pb. Insulates against radiation.", SpriteManager.Get(TechType.Lead));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Lead);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Lead, 6).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Lead, 1);
            customPrefab.Register();

            //lithium
            customPrefab = new CustomPrefab("ionLithium", "Lithium (x4)", "Li. Applications in high-strength alloys.", SpriteManager.Get(TechType.Lithium));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Lithium);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Lithium, 4).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Lithium, 1);
            customPrefab.Register();

            //magnetite
            customPrefab = new CustomPrefab("ionMagnetite", "Magnetite (x4)", "Fe3O4. Metal oxide with magnetic properties.", SpriteManager.Get(TechType.Magnetite));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Magnetite);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Magnetite, 4).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Magnetite, 1);
            customPrefab.Register();

            //nickel ore
            customPrefab = new CustomPrefab("ionNickel", "Nickel Ore (x2)", "Ni. Versatile alloy ingredient required for advanced fabrication.", SpriteManager.Get(TechType.Nickel));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Nickel);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Nickel, 2).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Nickel, 1);
            customPrefab.Register();

            //quartz
            customPrefab = new CustomPrefab("ionQuartz", "Quartz (x8)", "SiO4. Silica in crystalline form.", SpriteManager.Get(TechType.Quartz));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Quartz);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Quartz, 8).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Quartz, 1);
            customPrefab.Register();

            //ruby
            customPrefab = new CustomPrefab("ionAluminumOxide", "Ruby (x2)", "Al2O3. Valuable thermo-conductivity and electro-conductance.", SpriteManager.Get(TechType.AluminumOxide));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.AluminumOxide);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.AluminumOxide, 2).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.AluminumOxide, 1);
            customPrefab.Register();

            //salt deposit
            customPrefab = new CustomPrefab("ionSalt", "Salt Deposit (x6)", "NaCl. Culinary and sanitation applications.", SpriteManager.Get(TechType.Salt));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Salt);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Salt, 6).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Salt, 1);
            customPrefab.Register();

            //silver
            customPrefab = new CustomPrefab("ionSilver", "Silver Ore (x6)", "Ag. Conductive element and microbicide.", SpriteManager.Get(TechType.Silver));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.Silver);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.Silver, 6).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Silver, 1);
            customPrefab.Register();

            //uraninite crystal
            customPrefab = new CustomPrefab("ionUraniniteCrystal", "Uraninite Crystal (x2)", "U3O8. A highly radioactive material.", SpriteManager.Get(TechType.UraniniteCrystal));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.UraniniteCrystal);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.UraniniteCrystal, 2).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.UraniniteCrystal, 1);
            customPrefab.Register();

            //gas pod
            customPrefab = new CustomPrefab("ionGasPod", "Gas Pod (x8)", "An acidic compound produced by the gasopod. May be re-purposed.", SpriteManager.Get(TechType.GasPod));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.GasPod);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.GasPod, 8).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.GasPod, 1);
            customPrefab.Register();

            //alien feces
            customPrefab = new CustomPrefab("ionShit", "Alien Feces", "Some nice nutrient-rich Sugar Honey Ice Tea.", SpriteManager.Get(TechType.SeaTreaderPoop));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.SeaTreaderPoop);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.SeaTreaderPoop, 1).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.Peeper, 1);
            customPrefab.Register();

            //table coral
            customPrefab = new CustomPrefab("ionTableCoral", "Table Coral (x8)", "Contains trace precious metals used in computer fabrication.", SpriteManager.Get(TechType.JeweledDiskPiece));
            gameObject = new CloneTemplate(IonFabricationPlugin.Info, TechType.JeweledDiskPiece);
            customPrefab.SetGameObject(gameObject);
            GadgetExtensions.SetRecipe(customPrefab, new RecipeData
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>
                {
                    new CraftData.Ingredient(TechType.PrecursorIonCrystal, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.JeweledDiskPiece, 8).ToList()
            }).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab(new string[]
                {
                    "ionFabrication"
                });
            GadgetExtensions.SetUnlock(customPrefab, TechType.JeweledDiskPiece, 1);
            customPrefab.Register();
        }
    }
}
