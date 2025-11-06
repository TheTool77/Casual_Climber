using HarmonyLib;

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
            }
            else
            {
                return;
            }
        }
    }
}
