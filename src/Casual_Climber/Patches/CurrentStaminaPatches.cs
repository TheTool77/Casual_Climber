using HarmonyLib;

namespace Casual_Climber.Patches
{
    [HarmonyPatch]
    public class CurrentStaminaPatches
    {
        public static bool staminaModifier_Default = false;
        public static bool staminaModifier;
        public static bool staminaModifierToggle;

        [HarmonyPatch(typeof(Character), nameof(CharacterMovement.FixedUpdate))]
        [HarmonyPostfix]
        public static void Awake_Postfix(Character __instance)
        {
            staminaModifier = Casual_ClimberPlugin.staminaModifier;
            staminaModifierToggle = Casual_ClimberPlugin.staminaModifierToggle;

            float currentStamina = __instance.data.currentStamina;

            if (staminaModifier && staminaModifierToggle)
            {
                __instance.data.currentStamina = currentStamina + 0.00050f;

                if (currentStamina <= 0.001f)
                { __instance.data.currentStamina = 0f; }
            }
            else
            { __instance.data.currentStamina = currentStamina + 0f; }
        }
    }
}