using HarmonyLib;
using BepInEx;
using UnityEngine;

namespace CreativeModeKeybinds
{
    [BepInPlugin("com.github.hettenhausen.ValheimMods.CreativeModeKeybinds", "CreativeModeKeybinds", "0.0.1")]
    [BepInProcess("valheim.exe")]
    public class CreativeModeKeybinds : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("com.github.hettenhausen.ValheimMods.CreativeModeKeybinds");

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(Player), "Update")]
    public class Player_Patch
    {
        static void Postfix(ref Player __instance)//, ref bool __flag)
        {
            //if (__flag)
            //{
                if (Player.m_debugMode && Console.instance.IsCheatsEnabled())
                {
                    if (Input.GetKeyDown(KeyCode.Keypad7)) // was KeyCode.Z
                    {
                        __instance.ToggleDebugFly();
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad8)) // was KeyCode.B
                    {
                        __instance.ToggleNoPlacementCost();
                    }
                }
            //}
        }
    }
}

