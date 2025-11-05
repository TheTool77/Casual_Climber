using HarmonyLib;
//using UnityEngine;

namespace Casual_Climber.Patches
{
    [HarmonyPatch]
    public class CharacterAfflictionsPatches
    {
        public static bool hungerModifier_Default = false;
        public static bool hungerModifier;
        public static bool hungerModifierToggle;

        public static bool poisonModifier_Default = false;
        public static bool poisonModifier;
        public static bool poisonModifierToggle;

        public static bool heatModifier_Default = false;
        public static bool heatModifier;
        public static bool heatModifierToggle;

        public static bool coldModifier_Default = false;
        public static bool coldModifier;
        public static bool coldModifierToggle;

        public static bool drowsyModifier_Default = false;
        public static bool drowsyModifier;
        public static bool drowsyModifierToggle;

        public static bool curseModifier_Default = false;
        public static bool curseModifier;
        public static bool curseModifierToggle;

        public static bool injuryModifier_Default = false;
        public static bool injuryModifier;
        public static bool injuryModifierToggle;

        [HarmonyPatch(typeof(CharacterAfflictions), nameof(CharacterAfflictions.UpdateNormalStatuses))]
        [HarmonyPostfix]
        public static void Awake_Postfix()
        {
            //bool keyFlag4 = Input.GetKeyDown(KeyCode.Alpha4);
            //bool keyFlag5 = Input.GetKeyDown(KeyCode.Alpha5);
            //bool keyFlag6 = Input.GetKeyDown(KeyCode.Alpha6);
            //bool keyFlag7 = Input.GetKeyDown(KeyCode.Alpha7);
            //bool keyFlag8 = Input.GetKeyDown(KeyCode.Alpha8);
            //bool keyFlag9 = Input.GetKeyDown(KeyCode.Alpha9);
            //bool keyFlag0 = Input.GetKeyDown(KeyCode.Alpha0);

            //if (keyFlag4)
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0.2f); }
            //if (keyFlag5)
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0f); }
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0.2f); }
            //if (keyFlag6)
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0.2f); }
            //if (keyFlag7)
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0.2f); }
            //if (keyFlag8)
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0.2f); }
            //if (keyFlag9)
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0.2f); }
            //if (keyFlag0)
            //{ Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0.2f); }
            //{ Character.localCharacter.refs.afflictions.ClearAllStatus(false); }

            hungerModifier = Casual_ClimberPlugin.hungerModifier;
            hungerModifierToggle = Casual_ClimberPlugin.hungerModifierToggle;
            poisonModifier = Casual_ClimberPlugin.poisonModifier;
            poisonModifierToggle = Casual_ClimberPlugin.poisonModifierToggle;
            heatModifier = Casual_ClimberPlugin.heatModifier;
            heatModifierToggle = Casual_ClimberPlugin.heatModifierToggle;
            coldModifier = Casual_ClimberPlugin.coldModifier;
            coldModifierToggle = Casual_ClimberPlugin.coldModifierToggle;
            drowsyModifier = Casual_ClimberPlugin.drowsyModifier;
            drowsyModifierToggle = Casual_ClimberPlugin.drowsyModifierToggle;
            curseModifier = Casual_ClimberPlugin.curseModifier;
            curseModifierToggle = Casual_ClimberPlugin.curseModifierToggle;
            injuryModifier = Casual_ClimberPlugin.injuryModifier;
            injuryModifierToggle = Casual_ClimberPlugin.injuryModifierToggle;

            if (hungerModifier && hungerModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0f); }

            if (poisonModifier && poisonModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0f); }

            if (heatModifier && heatModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0f); }

            if (coldModifier && coldModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0f); }

            if (drowsyModifier && drowsyModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0f); }

            if (curseModifier && curseModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f); }

            if (injuryModifier && injuryModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0f); }
        }
    }
}