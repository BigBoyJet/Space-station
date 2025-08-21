using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HighlightAndSelectUI : MonoBehaviour
{
    public GameObject highlightEffect;  // Glow or outline effect
    public GameObject uiCanvas;         // The canvas to show when selected

    private XRRayInteractor rayInteractor;

    [Header("Input Actions")]
    public InputActionProperty triggerAction; // Assign from XR Controller (Trigger) in Inspector

    private bool uiVisible = false;      // Track if UI is currently visible
    private bool triggerHeld = false;    // Prevent multiple toggles per press

    private void Start()
    {
        rayInteractor = Object.FindFirstObjectByType<XRRayInteractor>();
        uiCanvas.SetActive(false); // Hide UI at start
        if (highlightEffect != null)
            highlightEffect.SetActive(false); // Hide highlight at start
    }

    private void Update()
    {
        // Check if the ray is hitting this object
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.transform == transform)
            {
                if (highlightEffect != null)
                    highlightEffect.SetActive(true);

                // Check trigger input
                bool triggerPressed = IsTriggerPressed();

                // Toggle only once per press
                if (triggerPressed && !triggerHeld)
                {
                    uiVisible = !uiVisible;            // Flip state
                    uiCanvas.SetActive(uiVisible);     // Show/hide UI
                    triggerHeld = true;                // Mark as held
                }
                else if (!triggerPressed)
                {
                    triggerHeld = false; // Reset when trigger released
                }
            }
            else
            {
                if (highlightEffect != null)
                    highlightEffect.SetActive(false);
            }
        }
        else
        {
            if (highlightEffect != null)
                highlightEffect.SetActive(false);
        }
    }

    private bool IsTriggerPressed()
    {
        return triggerAction.action != null && triggerAction.action.ReadValue<float>() > 0.5f;
    }
}
