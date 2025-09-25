using HarmonyLib;

namespace Casual_Climber.Patches
{
    [HarmonyPatch]
    public class MovementForcePatches
    {
        public static float movementForce_Default = 25f;
        public static float movementForce;
        public static bool movementForceToggle;

        [HarmonyPatch(typeof(CharacterMovement), nameof(CharacterMovement.FixedUpdate))]
        [HarmonyPostfix]
        public static void Awake_Postfix(ref float ___movementForce)
        {
            movementForce = Casual_ClimberPlugin.movementForce;
            movementForceToggle = Casual_ClimberPlugin.movementForceToggle;
            
            if (movementForceToggle)
            { ___movementForce = movementForce; }
            else
            { ___movementForce = movementForce_Default; }
        }
    }
}