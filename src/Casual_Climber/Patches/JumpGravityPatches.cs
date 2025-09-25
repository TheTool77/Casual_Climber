using HarmonyLib;

namespace Casual_Climber.Patches
{
    [HarmonyPatch]
    public class JumpGravityPatches
    {
        public static float jumpGravity_Default = 15f;
        public static float jumpGravity;
        public static bool jumpGravityToggle;

        [HarmonyPatch(typeof(CharacterMovement), nameof(CharacterMovement.TryToJump))]
        [HarmonyPostfix]
        public static void Awake_Postfix(ref float ___jumpGravity)
        {
            jumpGravity = Casual_ClimberPlugin.jumpGravity;
            jumpGravityToggle = Casual_ClimberPlugin.jumpGravityToggle;
            
            if (jumpGravityToggle)
            { ___jumpGravity = jumpGravity; }
            else
            { ___jumpGravity = jumpGravity_Default; }
        }
    }
}