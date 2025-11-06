using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Casual_Climber.Patches;
using UnityEngine;

namespace Casual_Climber
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class Casual_ClimberPlugin : BaseUnityPlugin
    {
        // Begin Casual Climber Mod for PEAK by TheTool
        private const string MyGUID = "com.TheTool.Casual_Climber";
        private const string PluginName = "Casual_Climber";
        private const string VersionString = "1.0.0";

        public static bool casual_climberMasterKeyToggle = false;

        public static bool displayUIFlag = false;
        public static bool displayUIConfigFlag = false;

        public static string casualClimber_ActivatedString = "Config Values Applied";
        public static string casualClimber_DeactivatedString = "Default Values Applied";

        public static string jumpString = "Jump Height Set to: ";
        public static float jumpString_Value = jumpGravity;
        public static float jumpString_DefaultValue = JumpGravityPatches.jumpGravity_Default;

        public static string moveSpeedString = "Movement Speed Set to: ";
        public static float moveSpeedString_Value = movementForce;
        public static float moveSpeedString_DefaultValue = MovementForcePatches.movementForce_Default;

        public static string climbSpeedString = "Climb Speed Set to: ";
        public static float climbSpeedString_Value = climbSpeedMod;
        public static float climbSpeedString_DefaultValue = ClimbSpeedModPatches.climbSpeedMod_Default;

        public static string staminaModifierString = "Stamina Modifier Enabled: ";
        public static bool staminaModifierString_Value = staminaModifier;
        public static bool staminaModifierString_DefaultValue = CurrentStaminaPatches.staminaModifier_Default;

        public static string hungerModifierString = "Hunger Disabled: ";
        public static bool hungerModifierString_Value = hungerModifier;
        public static bool hungerModifierString_DefaultValue = CharacterAfflictionsPatches.hungerModifier_Default;

        public static string poisonModifierString = "Poison Disabled: ";
        public static bool poisonModifierString_Value = poisonModifier;
        public static bool poisonModifierString_DefaultValue = CharacterAfflictionsPatches.poisonModifier_Default;

        public static string heatModifierString = "Heat Disabled: ";
        public static bool heatModifierString_Value = heatModifier;
        public static bool heatModifierString_DefaultValue = CharacterAfflictionsPatches.heatModifier_Default;

        public static string coldModifierString = "Cold Disabled: ";
        public static bool coldModifierString_Value = coldModifier;
        public static bool coldModifierString_DefaultValue = CharacterAfflictionsPatches.coldModifier_Default;

        public static string drowsyModifierString = "Drowsiness Disabled: ";
        public static bool drowsyModifierString_Value = drowsyModifier;
        public static bool drowsyModifierString_DefaultValue = CharacterAfflictionsPatches.drowsyModifier_Default;

        public static string curseModifierString = "Curse Disabled: ";
        public static bool curseModifierString_Value = curseModifier;
        public static bool curseModifierString_DefaultValue = CharacterAfflictionsPatches.curseModifier_Default;

        public static string injuryModifierString = "Injury Disabled: ";
        public static bool injuryModifierString_Value = injuryModifier;
        public static bool injuryModifierString_DefaultValue = CharacterAfflictionsPatches.injuryModifier_Default;


        // Config entry key strings
        // These will appear in the config file created by BepInEx and can also be used
        // by the OnSettingsChange event to determine which setting has changed.
        public static string JumpHeightKey = "01. Jump Height";
        public static string MovementSpeedKey = "02. Movement Speed";
        public static string ClimbSpeedModKey = "03. Climb Speed";
        public static string StaminaModifierKey = "04. Enable Stamina Modifier";
        public static string HungerModifierKey = "05. Disable Hunger";
        public static string PoisonModifierKey = "06. Disable Poison";
        public static string HeatModifierKey = "07. Disable Heat";
        public static string ColdModifierKey = "08. Disable Cold";
        public static string DrowsyModifierKey = "09. Disable Drowsiness";
        public static string CurseModifierKey = "10. Disable Curse";
        public static string InjuryModifierKey = "11. Disable Injury";
        public static string KeyboardKey_1Key = "12. Enable/Disable PEAK-ToolsTools Key";
        public static string KeyboardKey_1_AltKey = "13. Enable/Disable PEAK-ToolsTools Alt Key";
        public static string KeyboardKey_2Key = "14. PEAK-ToolsTools Configuration Key";
        public static string KeyboardKey_2_AltKey = "15. PEAK-ToolsTools Configuration Alt Key";

        // Configuration entries
        public static ConfigEntry<float>? JumpHeight;
        public static ConfigEntry<float>? MovementSpeed;
        public static ConfigEntry<float>? ClimbSpeedMod;
        public static ConfigEntry<bool>? StaminaModifier;
        public static ConfigEntry<bool>? HungerModifier;
        public static ConfigEntry<bool>? PoisonModifier;
        public static ConfigEntry<bool>? HeatModifier;
        public static ConfigEntry<bool>? ColdModifier;
        public static ConfigEntry<bool>? DrowsyModifier;
        public static ConfigEntry<bool>? CurseModifier;
        public static ConfigEntry<bool>? InjuryModifier;
        public static ConfigEntry<KeyboardShortcut>? KeyboardKey_1;
        public static ConfigEntry<KeyboardShortcut>? KeyboardKey_1_Alt;
        public static ConfigEntry<KeyboardShortcut>? KeyboardKey_2;
        public static ConfigEntry<KeyboardShortcut>? KeyboardKey_2_Alt;

        private static readonly Harmony Harmony = new(MyGUID);
        public static ManualLogSource Log = new(PluginName);

        public static float jumpGravity;
        public static bool jumpGravityToggle;
        public static float movementForce;
        public static bool movementForceToggle;
        public static float climbSpeedMod;
        public static bool climbSpeedModToggle;
        public static bool staminaModifier;
        public static bool staminaModifierToggle;
        public static bool hungerModifier;
        public static bool hungerModifierToggle;
        public static bool poisonModifier;
        public static bool poisonModifierToggle;
        public static bool heatModifier;
        public static bool heatModifierToggle;
        public static bool coldModifier;
        public static bool coldModifierToggle;
        public static bool drowsyModifier;
        public static bool drowsyModifierToggle;
        public static bool curseModifier;
        public static bool curseModifierToggle;
        public static bool injuryModifier;
        public static bool injuryModifierToggle;


        public void Awake()
        {
            // Static Log
            Log = Logger;

            jumpGravityToggle = false;
            movementForceToggle = false;
            climbSpeedModToggle = false;
            staminaModifierToggle = false;
            hungerModifierToggle = false;
            poisonModifierToggle = false;
            heatModifierToggle = false;
            coldModifierToggle = false;
            drowsyModifierToggle = false;
            curseModifierToggle = false;
            injuryModifierToggle = false;

            // Create GUI Object instance
            GameObject gameObject = new("GUI_UI");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            GUI_UI.Instance = gameObject.AddComponent<GUI_UI>();


            // JumpHeight
            JumpHeight = Config.Bind(
                "General",
                JumpHeightKey,
                60.0f,
                new ConfigDescription("Jump Height Value. min:15 - max:60",
                new AcceptableValueRange<float>(15.0f, 60.0f)));
            // MovementSpeed
            MovementSpeed = Config.Bind(
                "General",
                MovementSpeedKey,
                50.0f,
                new ConfigDescription("Move Speed Value. min:10 - max:50",
                new AcceptableValueRange<float>(25.0f, 50.0f)));
            // ClimbSpeedMod
            ClimbSpeedMod = Config.Bind(
                "General",
                ClimbSpeedModKey,
                2.0f,
                new ConfigDescription("Climb Speed Value. min:1 - max:2",
                new AcceptableValueRange<float>(1.0f, 2.0f)));

            // StaminaModifier
            StaminaModifier = Config.Bind(
                "General",
                StaminaModifierKey,
                true,
                new ConfigDescription("Enable Stamina Modifier.",
                new AcceptableValueList<bool>(false, true)));

            // Hunger
            HungerModifier = Config.Bind(
                "General",
                HungerModifierKey,
                true,
                new ConfigDescription("Disable Hunger.",
                new AcceptableValueList<bool>(false, true)));

            // Poison
            PoisonModifier = Config.Bind(
                "General",
                PoisonModifierKey,
                true,
                new ConfigDescription("Disable Poison.",
                new AcceptableValueList<bool>(false, true)));

            // Heat
            HeatModifier = Config.Bind(
                "General",
                HeatModifierKey,
                true,
                new ConfigDescription("Disable Heat.",
                new AcceptableValueList<bool>(false, true)));

            // Cold
            ColdModifier = Config.Bind(
                "General",
                ColdModifierKey,
                true,
                new ConfigDescription("Disable Cold.",
                new AcceptableValueList<bool>(false, true)));

            // Drowsy
            DrowsyModifier = Config.Bind(
                "General",
                DrowsyModifierKey,
                true,
                new ConfigDescription("Disable Drowsiness.",
                new AcceptableValueList<bool>(false, true)));

            // Curse
            CurseModifier = Config.Bind(
                "General",
                CurseModifierKey,
                true,
                new ConfigDescription("Disable Curse.",
                new AcceptableValueList<bool>(false, true)));

            // Injury
            InjuryModifier = Config.Bind(
                "General",
                InjuryModifierKey,
                true,
                new ConfigDescription("Disable Injury.",
                new AcceptableValueList<bool>(false, true)));



            // Keyboard Key Mod Activation 
            KeyboardKey_1 = Config.Bind
                ("General",
                KeyboardKey_1Key,
                // new KeyboardKey_1(KeyCode.A, KeyCode.LeftControl));
                new KeyboardShortcut(KeyCode.KeypadPlus), 
                new ConfigDescription("Activate Mod Key."));

            // Keyboard Alt Key Mod Activation Alt
            KeyboardKey_1_Alt = Config.Bind
                ("General",
                KeyboardKey_1_AltKey,
                // new KeyboardKey_1(KeyCode.A, KeyCode.LeftControl));
                new KeyboardShortcut(KeyCode.Equals),
                new ConfigDescription("Activate Mod Key."));

            // Keyboard Key Mod Config
            KeyboardKey_2 = Config.Bind
                ("General",
                KeyboardKey_2Key,
                // new KeyboardKey_1(KeyCode.A, KeyCode.LeftControl));
                new KeyboardShortcut(KeyCode.KeypadMinus),
                new ConfigDescription("Show Mod Config Key."));

            // Keyboard Alt Key Mod Config
            KeyboardKey_2_Alt = Config.Bind
                ("General",
                KeyboardKey_2_AltKey,
                // new KeyboardKey_1(KeyCode.A, KeyCode.LeftControl));
                new KeyboardShortcut(KeyCode.Minus),
                new ConfigDescription("Show Mod Config Key."));


            // Add listeners methods to run if and when settings are changed by the player.
            JumpHeight.SettingChanged += ConfigSettingChanged;
            MovementSpeed.SettingChanged += ConfigSettingChanged;
            ClimbSpeedMod.SettingChanged += ConfigSettingChanged;
            StaminaModifier.SettingChanged += ConfigSettingChanged;
            HungerModifier.SettingChanged += ConfigSettingChanged;
            PoisonModifier.SettingChanged += ConfigSettingChanged;
            HeatModifier.SettingChanged += ConfigSettingChanged;
            ColdModifier.SettingChanged += ConfigSettingChanged;
            DrowsyModifier.SettingChanged += ConfigSettingChanged;
            CurseModifier.SettingChanged += ConfigSettingChanged;
            InjuryModifier.SettingChanged += ConfigSettingChanged;
            KeyboardKey_1.SettingChanged += ConfigSettingChanged;
            KeyboardKey_2.SettingChanged += ConfigSettingChanged;

            jumpGravity = JumpHeight.Value;
            movementForce = MovementSpeed.Value;
            climbSpeedMod = ClimbSpeedMod.Value;
            staminaModifier = StaminaModifier.Value;
            hungerModifier = HungerModifier.Value;
            poisonModifier = PoisonModifier.Value;
            heatModifier = HeatModifier.Value;
            coldModifier = ColdModifier.Value;
            drowsyModifier = DrowsyModifier.Value;
            curseModifier = CurseModifier.Value;
            injuryModifier = InjuryModifier.Value;


            // Load all patches
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
        }


        // Code executed every frame.
        public void Update()
        {
            displayUIFlag = false;
            displayUIConfigFlag = false;

            jumpString_Value = jumpGravity;
            moveSpeedString_Value = movementForce;
            climbSpeedString_Value = climbSpeedMod;
            staminaModifierString_Value = staminaModifier;
            hungerModifierString_Value = hungerModifier;
            poisonModifierString_Value= poisonModifier;
            heatModifierString_Value = heatModifier;
            coldModifierString_Value = coldModifier;
            drowsyModifierString_Value = drowsyModifier;
            curseModifierString_Value = curseModifier;
            injuryModifierString_Value = injuryModifier;

            //Display Config GUI
            if (KeyboardKey_2 != null)
            {
                if (Casual_ClimberPlugin.KeyboardKey_2.Value.IsDown())
                {
                    if (displayUIConfigFlag == false)
                    { displayUIConfigFlag = true; }
                }
            }
            if (KeyboardKey_2_Alt != null)
            {
                if (Casual_ClimberPlugin.KeyboardKey_2_Alt.Value.IsDown())
                {
                    if (displayUIConfigFlag == false)
                    { displayUIConfigFlag = true; }
                }
            }

            //Display Mod GUI / Activate Toggle Values
            if (KeyboardKey_1 != null)
            {
                if (Casual_ClimberPlugin.KeyboardKey_1.Value.IsDown())
                { MasterSwitchesToggle(); }
            }
            if (KeyboardKey_1_Alt != null)
            {
                if (Casual_ClimberPlugin.KeyboardKey_1_Alt.Value.IsDown())
                { MasterSwitchesToggle(); }
            }

        }

        public static void MasterSwitchesToggle()
        {

            // casual_climberMasterKeyToggle
            if (casual_climberMasterKeyToggle == false)
            { casual_climberMasterKeyToggle = true; }
            else
            { casual_climberMasterKeyToggle = false; }

            if (displayUIFlag == false)
            { displayUIFlag = true; }

            // jumpGravityToggle
            if (jumpGravityToggle == false)
            {
                jumpGravityToggle = true;
                Log.LogInfo($"jumpGravity Value: {JumpGravityPatches.jumpGravity}");
            }
            else
            {
                jumpGravityToggle = false;
                Log.LogInfo($"jumpGravity Value: {JumpGravityPatches.jumpGravity_Default}: Default");
            }

            // movementForceToggle
            if (movementForceToggle == false)
            {
                movementForceToggle = true;
                Log.LogInfo($"movementForce Value: {MovementForcePatches.movementForce}");
            }
            else
            {
                movementForceToggle = false;
                Log.LogInfo($"movementForce Value: {MovementForcePatches.movementForce_Default}: Default");
            }

            // climbSpeedModToggle
            if (climbSpeedModToggle == false)
            {
                climbSpeedModToggle = true;
                Log.LogInfo($"climbSpeedMod Value: {ClimbSpeedModPatches.climbSpeedMod}");
            }
            else
            {
                climbSpeedModToggle = false;
                Log.LogInfo($"climbSpeedMod Value: {ClimbSpeedModPatches.climbSpeedMod_Default}: Default");
            }

            // staminaModifierToggle
            if (staminaModifierToggle == false)
            {
                staminaModifierToggle = true;
                Log.LogInfo($"staminaModifier Value: {CurrentStaminaPatches.staminaModifier}");
            }
            else
            {
                staminaModifierToggle = false;
                Log.LogInfo($"staminaModifier Value: {CurrentStaminaPatches.staminaModifier_Default}: Default");
            }

            // hungerModifierToggle
            if (hungerModifierToggle == false)
            {
                hungerModifierToggle = true;
                Log.LogInfo($"hungerModifier Value: {CharacterAfflictionsPatches.hungerModifier}");
            }
            else
            {
                hungerModifierToggle = false;
                Log.LogInfo($"hungerModifier Value: {CharacterAfflictionsPatches.hungerModifier_Default}: Default");
            }

            // poisonModifierToggle
            if (poisonModifierToggle == false)
            {
                poisonModifierToggle = true;
                Log.LogInfo($"poisonModifier Value: {CharacterAfflictionsPatches.poisonModifier}");
            }
            else
            {
                poisonModifierToggle = false;
                Log.LogInfo($"poisonModifier Value: {CharacterAfflictionsPatches.poisonModifier_Default}: Default");
            }

            // heatModifierToggle
            if (heatModifierToggle == false)
            {
                heatModifierToggle = true;
                Log.LogInfo($"heatModifier Value: {CharacterAfflictionsPatches.heatModifier}");
            }
            else
            {
                heatModifierToggle = false;
                Log.LogInfo($"heatModifier Value: {CharacterAfflictionsPatches.heatModifier_Default}: Default");
            }

            // coldModifierToggle
            if (coldModifierToggle == false)
            {
                coldModifierToggle = true;
                Log.LogInfo($"coldModifier Value: {CharacterAfflictionsPatches.coldModifier}");
            }
            else
            {
                coldModifierToggle = false;
                Log.LogInfo($"coldModifier Value: {CharacterAfflictionsPatches.coldModifier_Default}: Default");
            }

            // drowsyModifierToggle
            if (drowsyModifierToggle == false)
            {
                drowsyModifierToggle = true;
                Log.LogInfo($"drowsyModifier Value: {CharacterAfflictionsPatches.drowsyModifier}");
            }
            else
            {
                drowsyModifierToggle = false;
                Log.LogInfo($"drowsyModifier Value: {CharacterAfflictionsPatches.drowsyModifier_Default}: Default");
            }

            // curseModifierToggle
            if (curseModifierToggle == false)
            {
                curseModifierToggle = true;
                Log.LogInfo($"curseModifier Value: {CharacterAfflictionsPatches.curseModifier}");
            }
            else
            {
                curseModifierToggle = false;
                Log.LogInfo($"curseModifier Value: {CharacterAfflictionsPatches.curseModifier_Default}: Default");
            }

            // injuryModifierToggle
            if (injuryModifierToggle == false)
            {
                injuryModifierToggle = true;
                Log.LogInfo($"injuryModifier Value: {CharacterAfflictionsPatches.injuryModifier}");
            }
            else
            {
                injuryModifierToggle = false;
                Log.LogInfo($"injuryModifier Value: {CharacterAfflictionsPatches.injuryModifier_Default}: Default");
            }

            Log.LogInfo($"jumpGravityToggle Status: {jumpGravityToggle}");
            Log.LogInfo($"movementForceToggle Status: {movementForceToggle}");
            Log.LogInfo($"climbSpeedModToggle Status: {climbSpeedModToggle}");
            Log.LogInfo($"staminaModifierToggle Status: {staminaModifierToggle}");
            Log.LogInfo($"hungerModifierToggle Status: {hungerModifierToggle}");
            Log.LogInfo($"poisonModifierToggle Status: {poisonModifierToggle}");
            Log.LogInfo($"heatModifierToggle Status: {heatModifierToggle}");
            Log.LogInfo($"coldModifierToggle Status: {coldModifierToggle}");
            Log.LogInfo($"drowsyModifierToggle Status: {drowsyModifierToggle}");
            Log.LogInfo($"curseModifierToggle Status: {curseModifierToggle}");
            Log.LogInfo($"injuryModifierToggle Status: {injuryModifierToggle}");

        }            

        // Handle changes to conf made by the player
        public static void ConfigSettingChanged(object sender, System.EventArgs e)
        {
            SettingChangedEventArgs? settingChangedEventArgs = e as SettingChangedEventArgs;

            // Check if null and return
            if (settingChangedEventArgs == null)
            { return; }

            // JumpHeightKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == JumpHeightKey)
            {
                if (JumpHeight != null)
                { 
                    jumpGravity = JumpHeight.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"jumpGravity Value: {jumpGravity}");
                }
            }

            // MovementSpeedKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == MovementSpeedKey)
            {
                if (MovementSpeed != null)
                {
                    movementForce = MovementSpeed.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"movementForce Value: {movementForce}");
                }
            }

            // ClimbSpeedModKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == ClimbSpeedModKey)
            {
                if (ClimbSpeedMod != null)
                {
                    climbSpeedMod = ClimbSpeedMod.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"climbSpeed Value: {climbSpeedMod}");
                }
            }

            // StaminaModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == StaminaModifierKey)
            {
                if (StaminaModifier != null)
                {
                    staminaModifier = StaminaModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"staminaModifier Value: {staminaModifier}");
                }
            }

            // HungerModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == HungerModifierKey)
            {
                if (HungerModifier != null)
                {
                    hungerModifier = HungerModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"hungerModifier Value: {hungerModifier}");
                }
            }

            // PoisonModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == PoisonModifierKey)
            {
                if (PoisonModifier != null)
                {
                    poisonModifier = PoisonModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"poisonModifier Value: {poisonModifier}");
                }
            }

            // HeatModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == HeatModifierKey)
            {
                if (HeatModifier != null)
                {
                    heatModifier = HeatModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"heatModifier Value: {heatModifier}");
                }
            }

            // ColdModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == ColdModifierKey)
            {
                if (ColdModifier != null)
                {
                    coldModifier = ColdModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"coldModifier Value: {coldModifier}");
                }
            }

            // DrowsyModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == DrowsyModifierKey)
            {
                if (DrowsyModifier != null)
                {
                    drowsyModifier = DrowsyModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"drowsyModifier Value: {drowsyModifier}");
                }
            }

            // CurseModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == CurseModifierKey)
            {
                if (CurseModifier != null)
                {
                    curseModifier = CurseModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"curseModifier Value: {curseModifier}");
                }
            }

            // InjuryModifierKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == InjuryModifierKey)
            {
                if (InjuryModifier != null)
                {
                    injuryModifier = InjuryModifier.Value;
                    Casual_ClimberPlugin.Log.LogInfo($"injuryModifier Value: {injuryModifier}");
                }
            }


            // KeyboardKey_1Key ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == KeyboardKey_1Key)
            {
                KeyboardShortcut nullValue = (KeyboardShortcut)settingChangedEventArgs.ChangedSetting.BoxedValue;
            }

            // KeyboardKey_1_AltKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == KeyboardKey_1_AltKey)
            {
                KeyboardShortcut nullValue = (KeyboardShortcut)settingChangedEventArgs.ChangedSetting.BoxedValue;
            }

            // KeyboardKey_2Key ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == KeyboardKey_2Key)
            {
                KeyboardShortcut nullValue = (KeyboardShortcut)settingChangedEventArgs.ChangedSetting.BoxedValue;
            }

            // KeyboardKey_2_AltKey ChangedSetting
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == KeyboardKey_2_AltKey)
            {
                KeyboardShortcut nullValue = (KeyboardShortcut)settingChangedEventArgs.ChangedSetting.BoxedValue;
            }
        }
    }
}
