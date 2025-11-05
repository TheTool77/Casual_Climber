using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Casual_Climber.Patches
{
    [HarmonyPatch]
    public class GUI_Patches : MonoBehaviour
    {
        public static bool uiActive = false;
        public static bool displayUIFlag = Casual_ClimberPlugin.displayUIFlag;
        public static bool displayUIConfigFlag = Casual_ClimberPlugin.displayUIConfigFlag;

        [HarmonyPatch(typeof(GUIManager), nameof(GUIManager.LateUpdate))]
        [HarmonyPostfix]
        public static void Postfix(GUIManager __instance)
        {
            displayUIFlag = Casual_ClimberPlugin.displayUIFlag;
            displayUIConfigFlag = Casual_ClimberPlugin.displayUIConfigFlag;

            if (displayUIFlag)
            {
                GUI_Patches.uiActive = !GUI_Patches.uiActive;
                Debug.Log("[Casual_Climber] Status " + (GUI_Patches.uiActive ? "Enabled" : "Disabled"));
                GUI_UI? gui_Instance = GUI_UI.Instance;
                gui_Instance?.DisplayValues(GUI_Patches.uiActive);
            }

            if (displayUIConfigFlag)
            {
                GUI_UI? gui_Instance = GUI_UI.Instance;
                gui_Instance?.DisplayConfig();
            }
        }
    }

    public class GUI_UI : MonoBehaviour
    {
        public static GUI_UI? Instance;
        public static bool ui_Active = GUI_Patches.uiActive;
        public bool isValuesVisible = false;
        public static bool isConfigVisible = false;
        public float lastTimeChange = -10f;
        public static string mod_ActiveStatus = "Disabled";
        public static Color colorDisplayed;

        public static string casualClimber_ActivatedString = Casual_ClimberPlugin.casualClimber_ActivatedString;
        public static string casualClimber_DeactivatedString = Casual_ClimberPlugin.casualClimber_DeactivatedString;
        public static string casualClimber_ActivationStatus = Casual_ClimberPlugin.casualClimber_ActivatedString;

        public static string jumpString = Casual_ClimberPlugin.jumpString;
        public static float jumpString_Value;
        public static float jumpString_DefaultValue;
        public static float jumpString_DisplayValue;

        public static string moveSpeedString = Casual_ClimberPlugin.moveSpeedString;
        public static float moveSpeedString_Value;
        public static float moveSpeedString_DefaultValue;
        public static float moveSpeedString_DisplayValue;

        public static string climbSpeedString = Casual_ClimberPlugin.climbSpeedString;
        public static float climbSpeedString_Value;
        public static float climbSpeedString_DefaultValue;
        public static float climbSpeedString_DisplayValue;

        public static string staminaModifierString = Casual_ClimberPlugin.staminaModifierString;
        public static bool staminaModifierString_Value;
        public static bool staminaModifierString_DefaultValue;
        public static bool staminaModifierString_DisplayValue;

        public static string hungerModifierString = Casual_ClimberPlugin.hungerModifierString;
        public static bool hungerModifierString_Value;
        public static bool hungerModifierString_DefaultValue;
        public static bool hungerModifierString_DisplayValue;

        public static string poisonModifierString = Casual_ClimberPlugin.poisonModifierString;
        public static bool poisonModifierString_Value;
        public static bool poisonModifierString_DefaultValue;
        public static bool poisonModifierString_DisplayValue;

        public static string heatModifierString = Casual_ClimberPlugin.heatModifierString;
        public static bool heatModifierString_Value;
        public static bool heatModifierString_DefaultValue;
        public static bool heatModifierString_DisplayValue;

        public static string coldModifierString = Casual_ClimberPlugin.coldModifierString;
        public static bool coldModifierString_Value;
        public static bool coldModifierString_DefaultValue;
        public static bool coldModifierString_DisplayValue;

        public static string drowsyModifierString = Casual_ClimberPlugin.drowsyModifierString;
        public static bool drowsyModifierString_Value;
        public static bool drowsyModifierString_DefaultValue;
        public static bool drowsyModifierString_DisplayValue;

        public static string curseModifierString = Casual_ClimberPlugin.curseModifierString;
        public static bool curseModifierString_Value;
        public static bool curseModifierString_DefaultValue;
        public static bool curseModifierString_DisplayValue;

        public static string injuryModifierString = Casual_ClimberPlugin.injuryModifierString;
        public static bool injuryModifierString_Value;
        public static bool injuryModifierString_DefaultValue;
        public static bool injuryModifierString_DisplayValue;


        public void DisplayValues(bool ui_Active)
        {
            if (ui_Active)
            {
                casualClimber_ActivationStatus = casualClimber_ActivatedString;
            }
            else
            {
                casualClimber_ActivationStatus = casualClimber_DeactivatedString;
            }

            mod_ActiveStatus = ui_Active ? "Enabled" : "Disabled";
            isValuesVisible = true;
            lastTimeChange = Time.time;
        }

        public void DisplayConfig()
        {
            if (isConfigVisible)
            {
                isConfigVisible = false;
                isValuesVisible = false;
                lastTimeChange = Time.time;
            }
            else
            {
                isValuesVisible = true;
                isConfigVisible = true;
                lastTimeChange = Time.time;
            }
        }


        public void OnGUI()
        {
            if (mod_ActiveStatus == "Enabled")
            { colorDisplayed = Color.green; }
            else
            { colorDisplayed = Color.yellow; }

            bool visibilityFlag = !isValuesVisible;
            if (!visibilityFlag)
            {
                bool timerFlag = Time.time - lastTimeChange > 2f;

                if (isConfigVisible)
                { timerFlag = false; }
                if (timerFlag)
                { isValuesVisible = false; }
                else
                {
                    if (timerFlag)
                    { isValuesVisible = false; }

                    jumpString_Value = Casual_ClimberPlugin.jumpString_Value;
                    jumpString_DefaultValue = Casual_ClimberPlugin.jumpString_DefaultValue;

                    moveSpeedString_Value = Casual_ClimberPlugin.moveSpeedString_Value;
                    moveSpeedString_DefaultValue = Casual_ClimberPlugin.moveSpeedString_DefaultValue;

                    climbSpeedString_Value = Casual_ClimberPlugin.climbSpeedString_Value;
                    climbSpeedString_DefaultValue = Casual_ClimberPlugin.climbSpeedString_DefaultValue;

                    staminaModifierString_Value = Casual_ClimberPlugin.staminaModifierString_Value;
                    staminaModifierString_DefaultValue = Casual_ClimberPlugin.staminaModifierString_DefaultValue;

                    hungerModifierString_Value = Casual_ClimberPlugin.hungerModifierString_Value;
                    hungerModifierString_DefaultValue = Casual_ClimberPlugin.hungerModifierString_DefaultValue;

                    poisonModifierString_Value = Casual_ClimberPlugin.poisonModifierString_Value;
                    poisonModifierString_DefaultValue = Casual_ClimberPlugin.poisonModifierString_DefaultValue;

                    heatModifierString_Value = Casual_ClimberPlugin.heatModifierString_Value;
                    heatModifierString_DefaultValue = Casual_ClimberPlugin.heatModifierString_DefaultValue;

                    coldModifierString_Value = Casual_ClimberPlugin.coldModifierString_Value;
                    coldModifierString_DefaultValue = Casual_ClimberPlugin.coldModifierString_DefaultValue;

                    drowsyModifierString_Value = Casual_ClimberPlugin.drowsyModifierString_Value;
                    drowsyModifierString_DefaultValue = Casual_ClimberPlugin.drowsyModifierString_DefaultValue;

                    curseModifierString_Value = Casual_ClimberPlugin.curseModifierString_Value;
                    curseModifierString_DefaultValue = Casual_ClimberPlugin.curseModifierString_DefaultValue;

                    injuryModifierString_Value = Casual_ClimberPlugin.injuryModifierString_Value;
                    injuryModifierString_DefaultValue = Casual_ClimberPlugin.injuryModifierString_DefaultValue;

                    if (mod_ActiveStatus == "Enabled")
                    {
                        jumpString_DisplayValue = jumpString_Value;
                        moveSpeedString_DisplayValue = moveSpeedString_Value;
                        climbSpeedString_DisplayValue = climbSpeedString_Value;
                        staminaModifierString_DisplayValue = staminaModifierString_Value;
                        hungerModifierString_DisplayValue = hungerModifierString_Value;
                        poisonModifierString_DisplayValue = poisonModifierString_Value;
                        heatModifierString_DisplayValue = heatModifierString_Value;
                        coldModifierString_DisplayValue = coldModifierString_Value;
                        drowsyModifierString_DisplayValue = drowsyModifierString_Value;
                        curseModifierString_DisplayValue = curseModifierString_Value;
                        injuryModifierString_DisplayValue = injuryModifierString_Value;
                    }
                    else
                    {
                        jumpString_DisplayValue = jumpString_DefaultValue;
                        moveSpeedString_DisplayValue = moveSpeedString_DefaultValue;
                        climbSpeedString_DisplayValue = climbSpeedString_DefaultValue;
                        staminaModifierString_DisplayValue = staminaModifierString_DefaultValue;
                        hungerModifierString_DisplayValue = hungerModifierString_DefaultValue;
                        poisonModifierString_DisplayValue = poisonModifierString_DefaultValue;
                        heatModifierString_DisplayValue = heatModifierString_DefaultValue;
                        coldModifierString_DisplayValue = coldModifierString_DefaultValue;
                        drowsyModifierString_DisplayValue = drowsyModifierString_DefaultValue;
                        curseModifierString_DisplayValue = curseModifierString_DefaultValue;
                        injuryModifierString_DisplayValue = injuryModifierString_DefaultValue;
                    }
   
                    GUI.color = Color.white;
                    GUI.contentColor = Color.white;
                    GUI.backgroundColor = new Color(255f, 255f, 255f, 1.0f);
                    //GUI.backgroundColor = Color.grey;

                    GUIStyle guistyle = new(GUI.skin.label)
                    {
                        fontSize = 18,
                        alignment = TextAnchor.UpperLeft,
                        fontStyle = FontStyle.Bold,
                        richText = true
                    };

                    GUILayout.BeginArea(new Rect(30f, 30f, 360f, 440f), GUI.skin.box);
                        GUILayout.BeginArea(new Rect(6f, 6f, 348, 428f), GUI.skin.box);
                            GUILayout.Label("Casual Climber: " + mod_ActiveStatus, guistyle, []);
                            GUI.color = colorDisplayed;
                            GUI.contentColor = colorDisplayed;
                            GUILayout.Label($"{casualClimber_ActivationStatus}", guistyle, []);
                            GUILayout.Space(26);
                            GUI.color = Color.white;
                            GUI.contentColor = Color.white;
                            GUILayout.Label(string.Format($"{jumpString} {jumpString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{moveSpeedString} {moveSpeedString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{climbSpeedString} {climbSpeedString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{staminaModifierString} {staminaModifierString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{hungerModifierString} {hungerModifierString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{poisonModifierString} {poisonModifierString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{heatModifierString} {heatModifierString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{coldModifierString} {coldModifierString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{drowsyModifierString} {drowsyModifierString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{curseModifierString} {curseModifierString_DisplayValue}"), guistyle, []);
                            GUILayout.Label(string.Format($"{injuryModifierString} {injuryModifierString_DisplayValue}"), guistyle, []);
                        GUILayout.EndArea();
                    GUILayout.EndArea();

                    if (isConfigVisible)
                    {
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;

                        GUILayout.BeginArea(new Rect(400, 30f, 360f, 440f), GUI.skin.box);
                        GUILayout.BeginArea(new Rect(6f, 6f, 348f, 428f), GUI.skin.button);

                        GUILayout.Label(string.Format($"Casual Climber Cofiguration"), guistyle, Array.Empty<GUILayoutOption>());

                        bool closeButton = GUI.Button(new Rect(320f, 8f, 24f, 24f), "X");
                        if (closeButton)
                        {
                            isConfigVisible = false;
                            isValuesVisible = false;
                            Debug.Log($"[Casual_Climber] Status " + $"Button Pressed! {closeButton}");
                        }

                        GUILayout.Space(10);

                                // jump slider
                                GUILayout.Label(string.Format($"Jump Height {Casual_ClimberPlugin.jumpGravity}"), []);
                                Casual_ClimberPlugin.JumpHeight.Value = GUILayout.HorizontalSlider(Casual_ClimberPlugin.JumpHeight.Value, 15f, 60f, []);
                                    GUILayout.Space(6);
                                // move speed slider
                                GUILayout.Label(string.Format($"Movement Speed {Casual_ClimberPlugin.movementForce}"), []);
                                Casual_ClimberPlugin.MovementSpeed.Value = GUILayout.HorizontalSlider(Casual_ClimberPlugin.MovementSpeed.Value, 25f, 50f, []);
                                    GUILayout.Space(6);
                                // climb speed slider
                                GUILayout.Label(string.Format($"Climb Speed {Casual_ClimberPlugin.climbSpeedMod}"), []);
                                Casual_ClimberPlugin.ClimbSpeedMod.Value = GUILayout.HorizontalSlider(Casual_ClimberPlugin.ClimbSpeedMod.Value, 1f, 2f, []);
                                    GUILayout.Space(10);
                                // stamina toggle
                                Casual_ClimberPlugin.StaminaModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.staminaModifier, $"Enable Stamina Modifier {Casual_ClimberPlugin.StaminaModifier.Value}");
                                    GUILayout.Space(7);
                                // hunger toggle
                                Casual_ClimberPlugin.HungerModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.hungerModifier, $"Disable Hunger {Casual_ClimberPlugin.HungerModifier.Value}");
                                    GUILayout.Space(7);
                                // poison toggle
                                Casual_ClimberPlugin.PoisonModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.poisonModifier, $"Disable Poison {Casual_ClimberPlugin.PoisonModifier.Value}");
                                GUILayout.Space(7);
                                // heat toggle
                                Casual_ClimberPlugin.HeatModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.heatModifier, $"Disable Heat {Casual_ClimberPlugin.HeatModifier.Value}");
                                    GUILayout.Space(7);
                                // cold toggle
                                Casual_ClimberPlugin.ColdModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.coldModifier, $"Disable Cold {Casual_ClimberPlugin.ColdModifier.Value}");
                                    GUILayout.Space(7);
                                // drowsy toggle
                                Casual_ClimberPlugin.DrowsyModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.drowsyModifier, $"Disable Drowsy {Casual_ClimberPlugin.DrowsyModifier.Value}");
                                    GUILayout.Space(7);
                                // curse toggle
                                Casual_ClimberPlugin.CurseModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.curseModifier, $"Disable Curse {Casual_ClimberPlugin.CurseModifier.Value}");
                                    GUILayout.Space(7);
                                // injury toggle
                                Casual_ClimberPlugin.InjuryModifier.Value = GUILayout.Toggle(Casual_ClimberPlugin.injuryModifier, $"Disable Injury {Casual_ClimberPlugin.InjuryModifier.Value}");
                                    GUILayout.Space(7); 

                            GUILayout.EndArea();
                        GUILayout.EndArea();
                    }
                }
            }
        }
    }
}





