using System;
using Harmony;
using UnityEngine;
using LobotomyBaseMod;

namespace UnlimitedLOBPoints
{
    public class Harmony_Patch
    {
        public Harmony_Patch()
        {
            try
            {
                ModDebug.Log("[UnlimitedLOBPoints] Loading patches...");
                HarmonyInstance harmonyInstance = HarmonyInstance.Create("UnlimitedLOBPoints");
                
                harmonyInstance.Patch(
                    typeof(MoneyModel).GetMethod("EnoughCheck", AccessTools.all),
                    new HarmonyMethod(typeof(Harmony_Patch).GetMethod("EnoughCheck_Prefix")),
                    null
                );

                harmonyInstance.Patch(
                    typeof(MoneyModel).GetMethod("Pay", AccessTools.all),
                    new HarmonyMethod(typeof(Harmony_Patch).GetMethod("Pay_Prefix")),
                    null
                );

                harmonyInstance.Patch(
                    typeof(MoneyModel).GetMethod("LoadData", AccessTools.all),
                    null,
                    new HarmonyMethod(typeof(Harmony_Patch).GetMethod("LoadData_Postfix"))
                );

                harmonyInstance.Patch(
                    typeof(DeployUI).GetMethod("Update", AccessTools.all),
                    null,
                    new HarmonyMethod(typeof(Harmony_Patch).GetMethod("DeployUI_Update_Postfix"))
                );

                harmonyInstance.Patch(
                    typeof(DeployUI).GetMethod("GetHireText", AccessTools.all),
                    null,
                    new HarmonyMethod(typeof(Harmony_Patch).GetMethod("GetHireText_Postfix"))
                );

                harmonyInstance.Patch(
                    typeof(DeployUI).GetMethod("BuyAgent", AccessTools.all),
                    new HarmonyMethod(typeof(Harmony_Patch).GetMethod("BuyAgent_Prefix")),
                    null
                );

                harmonyInstance.Patch(
                    typeof(DeployAgentList).GetMethod("Update", AccessTools.all),
                    null,
                    new HarmonyMethod(typeof(Harmony_Patch).GetMethod("DeployAgentList_Update_Postfix"))
                );

                ModDebug.Log("[UnlimitedLOBPoints] Patches successfully loaded!");
            }
            catch (Exception ex)
            {
                ModDebug.Log("[UnlimitedLOBPoints] Error initializing patches: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        [HarmonyPriority(Priority.First)]
        public static bool EnoughCheck_Prefix(ref bool __result)
        {
            __result = true;
            return false;
        }

        [HarmonyPriority(Priority.First)]
        public static bool Pay_Prefix(ref bool __result)
        {
            MoneyModel.instance.money = 999999;
            __result = true;
            return false;
        }

        public static void LoadData_Postfix()
        {
            MoneyModel.instance.money = 999999;
        }

        public static void DeployUI_Update_Postfix(DeployUI __instance)
        {
            MoneyModel.instance.money = 999999;
            if (__instance != null && __instance.pointCount != null)
            {
                __instance.pointCount.text = "∞";
            }
        }

        [HarmonyPriority(Priority.Last)]
        public static void GetHireText_Postfix(DeployUI __instance, bool isEnter, ref string __result)
        {
            if (isEnter)
            {
                __result = "LOB 1";
            }
            else
            {
                string hireStr = "Hire";
                try
                {
                    if (LocalizeTextDataModel.instance != null)
                    {
                        hireStr = LocalizeTextDataModel.instance.GetText("Hire");
                    }
                }
                catch { }
                __result = hireStr + " (∞)";
            }
        }

        [HarmonyPriority(Priority.First)]
        public static bool BuyAgent_Prefix(DeployUI __instance)
        {
            try
            {
                if (MoneyModel.instance != null)
                {
                    MoneyModel.instance.money = 999999;
                }
                __instance.OpenCustomizingWindow();
            }
            catch (Exception ex)
            {
                ModDebug.Log("[UnlimitedLOBPoints] BuyAgent error: " + ex.Message);
            }
            return false;
        }

        public static void DeployAgentList_Update_Postfix(DeployAgentList __instance)
        {
            if (__instance != null && __instance.HireText != null)
            {
                __instance.HireText.text = DeployUI.instance.GetHireText(false);
            }
        }
    }
}
