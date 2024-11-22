using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class G003_BlinkingEffect : MonoBehaviour
{
    [SerializeField] private Image targetRenderer; // The Renderer whose color you want to change
    [SerializeField] private Color blinkColor = Color.red; // The color to blink to
    [SerializeField] private float blinkDuration = 0.5f; // Duration of one blink cycle

    private Color originalColor; // Original color of the material
    private Tween blinkTween;

    private void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Target Renderer is not assigned.");
            return;
        }

        originalColor = targetRenderer.color;

        // Create a looping color tween
        blinkTween = targetRenderer.DOColor(blinkColor, blinkDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .OnKill(() =>
            {
                // Reset color to original when tween is killed
                targetRenderer.color = originalColor;
            });
    }

    private void OnDestroy()
    {
        if (blinkTween != null && blinkTween.IsActive())
        {
            blinkTween.Kill();
        }
    }
}
