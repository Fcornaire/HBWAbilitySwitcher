using HarmonyLib;
using HBWAbilitySwitcher.Component;
using Landfall.Haste;

namespace HBWAbilitySwitcher.Pathcs
{
    /// <summary>
    /// Harmony patch class for modifying the PlayerInput behavior.
    /// </summary>
    [HarmonyPatch(typeof(PlayerCharacter.PlayerInput))]
    internal class PlayerInputPatchs
    {
        /// <summary>
        /// Checks and activates abilities based on dpad input.
        /// (up = BoardBoost, left = Fly, right = Grapple, down = Slomo)
        /// (Might not work on all controllers ?)
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch("SampleInput")]
        private static void SampleInputPatch(PlayerCharacter character)
        {
            CheckAndActivateAbility(UnityEngine.InputSystem.XInput.XInputController.current.dpad.up.wasPressedThisFrame, AbilityKind.BoardBoost, character);
            CheckAndActivateAbility(UnityEngine.InputSystem.XInput.XInputController.current.dpad.left.wasPressedThisFrame, AbilityKind.Fly, character);
            CheckAndActivateAbility(UnityEngine.InputSystem.XInput.XInputController.current.dpad.right.wasPressedThisFrame, AbilityKind.Grapple, character);
            CheckAndActivateAbility(UnityEngine.InputSystem.XInput.XInputController.current.dpad.down.wasPressedThisFrame, AbilityKind.Slomo, character);
        }

        /// <summary>
        /// Checks if an ability activation input was pressed and activates the ability if conditions are met.
        /// </summary>
        private static void CheckAndActivateAbility(bool wasPressed, AbilityKind abilityKind, PlayerCharacter character)
        {
            if (wasPressed)
            {
                if (MetaProgression.IsUnlocked(abilityKind) && FactSystem.GetFact(MetaProgression.ActiveAbility) != (float)abilityKind)
                {
                    var abilitySwitcher = character.GetComponent<AbilitySwitcher>();
                    if (abilitySwitcher != null)
                    {
                        abilitySwitcher.UpdateAbilityToSwitch(abilityKind);
                    }
                }
            }
        }
    }
}
