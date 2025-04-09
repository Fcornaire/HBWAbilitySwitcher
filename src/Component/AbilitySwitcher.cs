extern alias UnityEngineCoreModule;

using HarmonyLib;
using Landfall.Haste;
using System.Collections;
using UnityEngine.UI;
using UnityEngineCoreModule::UnityEngine;
using Zorro.Core;

namespace HBWAbilitySwitcher.Component
{
    internal class AbilitySwitcher : MonoBehaviour
    {
        private GameObject iconObject = new GameObject("AbilityIcon");
        Image image;
        private AbilityKind toSwitch;
        private bool hasSwitched = true;
        private Coroutine fadeCoroutine;
        private bool isCoroutineRunning = false;


        private void Awake()
        {
            image = iconObject.AddComponent<Image>();
            RectTransform rectTransform = iconObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 1f);
            rectTransform.anchorMax = new Vector2(0.5f, 1f);
            rectTransform.pivot = new Vector2(0.5f, 1f);
            rectTransform.anchoredPosition = new Vector2(0f, -50f);
            rectTransform.sizeDelta = new Vector2(150f, 150f);
        }


        public void UpdateAbilityoSwitch(AbilityKind abilityKind)
        {
            toSwitch = abilityKind;
            hasSwitched = false;
            if (isCoroutineRunning)
            {
                StopCoroutine(fadeCoroutine);
                fadeCoroutine = null;
                isCoroutineRunning = false;


                Color color = image.color;
                color.a = 0f;
                image.color = color;

            }
        }

        private void Update()
        {
            //Get all SFX_INSTACE
            var sfxInstances = GameObject.FindObjectsOfType<SFX_Instance>();

            foreach (var sfxInstance in sfxInstances)
            {
                Plugin.Logger.LogInfo($"SFX_INSTANCE: {sfxInstance.name}");
            }

            if (!hasSwitched)
            {
                var animator = GameObject.FindAnyObjectByType<ButtonAnimator>();
                if (animator != null)
                {
                    Plugin.Logger.LogInfo($"Switching to {toSwitch}");
                    animator.sfxSelect.Play();
                }

                FactSystem.SetFact(MetaProgression.ActiveAbility, (float)toSwitch);
                MetaProgression.AbilityEntry entry = SingletonAsset<MetaProgression>.Instance.GetEntry(toSwitch);
                if (entry.icon != null)
                {
                    image.sprite = entry.icon;
                    if (iconObject.transform.parent == null)
                    {
                        UnityEngine.Canvas canvas = Traverse.Create(GameplayUIManager.instance).Field("canvas").GetValue() as UnityEngine.Canvas;
                        iconObject.transform.SetParent(canvas.transform, false);
                    }
                    fadeCoroutine = StartCoroutine(FadeInOutImage());
                    isCoroutineRunning = true;
                }
                hasSwitched = true;
            }
        }

        private IEnumerator FadeInOutImage()
        {
            float fadeInDuration = 0.1f;
            float fadeOutDuration = 1f;
            float waitDuration = 1f;

            // Fade In
            float elapsedTime = 0f;
            Color color = image.color;
            color.a = 0f;
            image.color = color;

            while (elapsedTime < fadeInDuration)
            {
                elapsedTime += Time.deltaTime;
                color.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
                image.color = color;
                yield return null;
            }

            // Wait
            yield return new WaitForSeconds(waitDuration);

            // Fade Out
            elapsedTime = 0f;
            while (elapsedTime < fadeOutDuration)
            {
                elapsedTime += Time.deltaTime;
                color.a = Mathf.Clamp01(1f - (elapsedTime / fadeOutDuration));
                image.color = color;
                yield return null;
            }

            isCoroutineRunning = false;
        }
    }
}
