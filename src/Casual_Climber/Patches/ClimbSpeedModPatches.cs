using HarmonyLib;
using UnityEngine.PlayerLoop;

namespace Casual_Climber.Patches
{
    [HarmonyPatch]
    public class ClimbSpeedModPatches
    {
        public static float climbSpeedMod_Default = 1f;
        public static float climbSpeedMod;
        public static bool climbSpeedModToggle;

        [HarmonyPatch(typeof(CharacterClimbing), nameof(FixedUpdate))]
        [HarmonyPostfix]
        public static void Awake_Postfix(ref float ___climbSpeedMod)
        {
            climbSpeedMod = Casual_ClimberPlugin.climbSpeedMod;
            climbSpeedModToggle = Casual_ClimberPlugin.climbSpeedModToggle;
            
            if (climbSpeedModToggle)
            { ___climbSpeedMod = climbSpeedMod; }
            else
            { ___climbSpeedMod = climbSpeedMod_Default; }
        }
    }
}