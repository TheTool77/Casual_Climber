using HarmonyLib;
using Photon.Pun;
using UnityEngine;
using static CharacterAfflictions;

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
        public static bool sporesModifier_Default = false;
        public static bool sporesModifier;
        public static bool sporesModifierToggle;
        public static bool thornsModifier_Default = false;
        public static bool thornsModifier;
        public static bool thornsModifierToggle;
        public static bool crabModifier_Default = false;
        public static bool crabModifier;
        public static bool crabModifierToggle;
        public static bool webModifier_Default = false;
        public static bool webModifier;
        public static bool webModifierToggle;
        public static bool weightModifier_Default = false;
        public static bool weightModifier;
        public static bool weightModifierToggle;
        public static bool injuryModifier_Default = false;
        public static bool injuryModifier;
        public static bool injuryModifierToggle;
        public static bool modifierDown = false;
        public static bool keyFlag0;
        public static bool keyFlag1;
        public static bool keyFlag2;
        public static bool keyFlag3;
        public static bool keyFlag4;
        public static bool keyFlag5;
        public static bool keyFlag6;
        public static bool keyFlag7;
        public static bool keyFlag8;
        public static bool keyFlag9;
        public static bool keyFlag10;
        public static bool keyFlag11;
        public static bool keyFlag12;

        [HarmonyPatch(typeof(CharacterAfflictions), nameof(CharacterAfflictions.UpdateNormalStatuses))]
        [HarmonyPostfix]
        public static void Awake_Postfix()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            { modifierDown = true; } 
            else if (Input.GetKeyUp(KeyCode.LeftAlt))
            { modifierDown = false;}
            if (modifierDown)
            { 
                keyFlag0 = Input.GetKeyDown(KeyCode.Keypad0);
                keyFlag1 = Input.GetKeyDown(KeyCode.Keypad1);
                keyFlag2 = Input.GetKeyDown(KeyCode.Keypad2);
                keyFlag3 = Input.GetKeyDown(KeyCode.Keypad3);
                keyFlag4 = Input.GetKeyDown(KeyCode.Keypad4);
                keyFlag5 = Input.GetKeyDown(KeyCode.Keypad5);
                keyFlag6 = Input.GetKeyDown(KeyCode.Keypad6);
                keyFlag7 = Input.GetKeyDown(KeyCode.Keypad7);
                keyFlag8 = Input.GetKeyDown(KeyCode.Keypad8);
                keyFlag9 = Input.GetKeyDown(KeyCode.Keypad9);
                keyFlag10 = Input.GetKeyDown(KeyCode.KeypadDivide);
                keyFlag11 = Input.GetKeyDown(KeyCode.KeypadMultiply);
                keyFlag12 = Input.GetKeyDown(KeyCode.KeypadPeriod);
            }

            if (keyFlag0)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0.2f, true); }
            if (keyFlag1)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0.2f, true); }
            if (keyFlag2)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0.2f, true); }
            if (keyFlag3)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0.2f, true); }
            if (keyFlag4)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0.2f, true); }
            if (keyFlag5)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0.2f, true); }
            if (keyFlag6)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, 0.2f, true); }
            if (keyFlag7)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0.2f, true); }
            if (keyFlag8)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0.2f, true); }
            if (keyFlag9)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0.2f, true); }
            if (keyFlag10)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0.2f, true); }
            if (keyFlag11)
            { PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0.2f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0.2f, true); }
            if (keyFlag12)
            {   PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.ClearAllStatus(false);
                Character.localCharacter.refs.afflictions.ClearAllStatus(false); }

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
            sporesModifier = Casual_ClimberPlugin.sporesModifier;
            sporesModifierToggle = Casual_ClimberPlugin.sporesModifierToggle;
            thornsModifier = Casual_ClimberPlugin.thornsModifier;
            thornsModifierToggle = Casual_ClimberPlugin.thornsModifierToggle;
            crabModifier = Casual_ClimberPlugin.crabModifier;
            crabModifierToggle = Casual_ClimberPlugin.crabModifierToggle;
            webModifier = Casual_ClimberPlugin.webModifier;
            webModifierToggle = Casual_ClimberPlugin.webModifierToggle;
            weightModifier = Casual_ClimberPlugin.weightModifier;
            weightModifierToggle = Casual_ClimberPlugin.weightModifierToggle;
            injuryModifier = Casual_ClimberPlugin.injuryModifier;
            injuryModifierToggle = Casual_ClimberPlugin.injuryModifierToggle;

            if (hungerModifier && hungerModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0f, true); }
            if (poisonModifier && poisonModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0f, true); }
            if (heatModifier && heatModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0f, true); }
            if (coldModifier && coldModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0f, true); }
            if (drowsyModifier && drowsyModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0f, true); }
            if (curseModifier && curseModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, true); }
            if (sporesModifier && sporesModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, 0f, true); }
            if (thornsModifier && thornsModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, true); }
            if (crabModifier && crabModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, true); }
            if (webModifier && webModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, true); }
            if (weightModifier && weightModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, true); }
            if (injuryModifier && injuryModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0f, true);
                PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0f, true); }
        }
    }
}