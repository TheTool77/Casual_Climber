using HarmonyLib;
//using Photon.Pun;
//using Photon.Realtime;
using UnityEngine;

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
            { float hunger = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Hunger);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, hunger + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, hunger + 0.1f, false);
                hunger += 0.1f;
                keyFlag0 = false;
                Debug.Log($"[Casual_Climber] Hunger Status Value =  {hunger}"); }
            if (keyFlag1)
            { float poison = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Poison);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, poison + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, poison + 0.1f, false);
                poison += 0.1f;
                keyFlag1 = false;
                Debug.Log($"[Casual_Climber] Poison Status Value =  {poison}"); }
            if (keyFlag2)
            { float hot = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Hot);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, hot + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, hot + 0.1f, false);
                hot += 0.1f;
                keyFlag2 = false;
                Debug.Log($"[Casual_Climber] Hot Status Value =  {hot}"); }
            if (keyFlag3)
            { float cold = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Cold);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, cold + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, cold + 0.1f, false);
                cold += 0.1f;
                keyFlag3 = false;
                Debug.Log($"[Casual_Climber] Cold Status Value =  {cold}"); }
            if (keyFlag4)
            { float drowsy = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Drowsy);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, drowsy + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, drowsy + 0.1f, false);
                drowsy += 0.1f;
                keyFlag4 = false;
                Debug.Log($"[Casual_Climber] Drowsy Status Value =  {drowsy}"); }
            if (keyFlag5)
            { float curse = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Curse);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, curse + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, curse + 0.1f, false);
                curse += 0.1f;
                keyFlag5 = false;
                Debug.Log($"[Casual_Climber] Curse Status Value =  {curse}"); }
            if (keyFlag6)
            { float spores = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Spores);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, spores + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, spores + 0.1f, false);
                spores += 0.1f;
                keyFlag6 = false;
                Debug.Log($"[Casual_Climber] Spores Status Value =  {spores}"); }
            if (keyFlag7)
            { float thorns = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Thorns);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, thorns + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, thorns + 0.1f, false);
                thorns += 0.1f;
                keyFlag7 = false;
                Debug.Log($"[Casual_Climber] Thorns Status Value =  {thorns}"); }
            if (keyFlag8)
            { float crab = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Crab);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, crab + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, crab + 0.1f, false);
                crab += 0.1f;
                keyFlag8 = false;
                Debug.Log($"[Casual_Climber] Crab Status Value =  {crab}"); }
            if (keyFlag9)
            { float web = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Web);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, web + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, web + 0.1f, false);
                web += 0.1f;
                keyFlag9 = false;
                Debug.Log($"[Casual_Climber] Web Status Value =  {web}"); }
            if (keyFlag10)
            { float weight = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Weight);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, weight + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, weight + 0.1f, false);
                weight += 0.1f;
                keyFlag10 = false;
                Debug.Log($"[Casual_Climber] Weight Status Value =  {weight}"); }
            if (keyFlag11)
            { float injury = Character.localCharacter.refs.afflictions.GetCurrentStatus(CharacterAfflictions.STATUSTYPE.Injury);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, injury + 0.1f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, injury + 0.1f, false);
                injury += 0.1f;
                keyFlag11 = false;
                Debug.Log($"[Casual_Climber] Injury Status Value =  {injury}"); }
            if (keyFlag12)
            {
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, false);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, false);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, false);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, false);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, true);
                Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, false);
                //PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.ClearAllStatus(false);
                Character.localCharacter.refs.afflictions.ClearAllStatus(false);
                keyFlag12 = false;
                Debug.Log($"[Casual_Climber] Remove All Status Types");
            }

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
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hunger, 0f, true); }
            if (poisonModifier && poisonModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Poison, 0f, true); }
            if (heatModifier && heatModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Hot, 0f, true); }
            if (coldModifier && coldModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Cold, 0f, true); }
            if (drowsyModifier && drowsyModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Drowsy, 0f, true); }
            if (curseModifier && curseModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Curse, 0f, true); }
            if (sporesModifier && sporesModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Spores, 0f, true); }
            if (thornsModifier && thornsModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Thorns, 0f, true); }
            if (crabModifier && crabModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Crab, 0f, true); }
            if (webModifier && webModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Web, 0f, true); }
            if (weightModifier && weightModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Weight, 0f, true); }
            if (injuryModifier && injuryModifierToggle)
            { Character.localCharacter.refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0f, false); }
            //{ PlayerHandler.GetPlayerCharacter(PhotonNetwork.LocalPlayer).refs.afflictions.SetStatus(CharacterAfflictions.STATUSTYPE.Injury, 0f, true); }
        }
    }
}