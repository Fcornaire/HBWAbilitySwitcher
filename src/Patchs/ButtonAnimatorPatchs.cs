extern alias UnityEngineCoreModule;
using HarmonyLib;
using UnityEngine;
using UnityEngineCoreModule::UnityEngine;


namespace HBWAbilitySwitcher.Patchs
{
    [HarmonyPatch(typeof(ButtonAnimator))]

    /// <summary>
    /// Patch class for ButtonAnimator 
    /// </summary>
    internal class ButtonAnimatorPatchs
    {
        /// <summary>
        /// Patch for the Update method of ButtonAnimator to steal the sfxHoverOn audio clips.
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void UpdatePatch(ButtonAnimator __instance)
        {
            if (Plugin.SFX_HOVER_ON != null || __instance.sfxSelect == null || __instance.sfxSelect.clips == null)
            {
                //Already initialized or no audio clips to steal
                return;
            }

            if (Traverse.Create(__instance.sfxHoverOn).Field("clips").GetValue() is AudioClip[] originalClips)
            {
                Plugin.SFX_HOVER_ON = new SFX_Instance();
                var go = GameObject.Instantiate(Plugin.SFX_HOVER_ON);
                GameObject.DontDestroyOnLoad(go);
                Plugin.SFX_HOVER_ON.clips = originalClips;
                Plugin.SFX_HOVER_ON.settings.volume = 0.2f;
                Plugin.SFX_HOVER_ON.settings.pitch_Variation = 0.0f;
            }
        }
    }
}
