using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using SimplyCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace SimplyCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class SimplyCards : BaseUnityPlugin
    {
        private const string ModId = "com.willuwontu.rounds.SimplyCards";
        private const string ModName = "Simply Cards";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "SC";

        public static SimplyCards instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<EvasiveManeuvers>(); // Repeat for each card to be built
        }
    }
}