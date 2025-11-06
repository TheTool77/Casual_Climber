using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Casual_Climber.Patches
{   
    
    [HarmonyPatch]
    public class CursorPatches
    {

        [HarmonyPatch(typeof(GUIManager), nameof(GUIManager.UpdateWindowStatus))]
        [HarmonyPostfix]
        static void Postfix(GUIManager __instance)
        {

            if (GUI_UI.isConfigVisible == true)
            {
                __instance.windowShowingCursor = true;
                __instance.windowBlockingInput = true;
                //Debug.Log($"[Casual_Climber]  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!! ");

            }
        }
    }
}
