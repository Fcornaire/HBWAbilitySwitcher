using HarmonyLib;
using HBWAbilitySwitcher.Component;

namespace HBWAbilitySwitcher.Patchs
{
    [HarmonyPatch(typeof(PlayerCharacter))]

    internal class PlayerCharacterPatchs
    {

        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        private static void AwakePatch(PlayerCharacter __instance)
        {
            __instance.gameObject.AddComponent<AbilitySwitcher>();
        }
    }
}
