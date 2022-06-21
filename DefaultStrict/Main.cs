using System.Reflection;
using DefaultStrict.MainPatch;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace DefaultStrict {
    #if DEBUG
    [EnableReloading]
    #endif

    internal static class Main {
        // public static Text text;
        internal static UnityModManager.ModEntry Mod;
        private static Harmony _harmony;
        internal static bool IsEnabled { get; private set; }

        private static void Load(UnityModManager.ModEntry modEntry) {
            Mod = modEntry;
            Mod.OnToggle = OnToggle;

            #if DEBUG
            Mod.OnUnload = Stop;
            #endif
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) {
            IsEnabled = value;

            if (value) Start();
            else Stop(modEntry);

            return true;
        }

        private static void Start() {
            _harmony = new Harmony(Mod.Info.Id);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            // text = new GameObject().AddComponent<Text>();
            // Object.DontDestroyOnLoad(text);
        }

        private static bool Stop(UnityModManager.ModEntry modEntry) {
            _harmony.UnpatchAll(Mod.Info.Id);
            #if RELEASE
            _harmony = null;
            #endif
            
            // Object.DestroyImmediate(text);
            // text = null;

            return true;
        }
    }
}