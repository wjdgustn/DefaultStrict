using HarmonyLib;
using UnityEngine;

namespace DefaultStrict.MainPatch {
    // public class Text : MonoBehaviour {
    //     public static string Content = "Wa sans!";
    //     
    //     void OnGUI() {
    //         Content = $"현재 판정 : {GCS.difficulty.ToString()}";
    //         
    //         GUIStyle style = new GUIStyle();
    //         style.fontSize = (int) 50.0f;
    //         style.font = RDString.GetFontDataForLanguage(RDString.language).font;
    //         style.normal.textColor = Color.white;
    //
    //         GUI.Label(new Rect(10, -10, Screen.width, Screen.height), Content, style);
    //     }
    // }

    [HarmonyPatch(typeof(scrUIController), "Awake")]

    internal static class DefaultStrict {
        private static void Postfix() {
            GCS.difficulty = Difficulty.Strict;
        }
    }
}