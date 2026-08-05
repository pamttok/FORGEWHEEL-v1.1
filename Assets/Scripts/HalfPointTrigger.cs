using UnityEngine;

/// <summary>
/// Activates the lap completion trigger once the player reaches
/// the halfway point of the track, preventing the lap from being
/// completed without passing the midpoint.
/// </summary>
public class HalfPointTrigger : MonoBehaviour
{
    // Reference to the lap completion trigger.
    [SerializeField] private GameObject lapCompleteTrigger;

    // Reference to the halfway trigger.
    [SerializeField] private GameObject halfLapTrigger;

    /// <summary>
    /// Called when the player enters the halfway trigger.
    /// Enables the lap completion trigger and disables
    /// the halfway trigger until the next lap.
    /// </summary>
    private void OnTriggerEnter()
    {
        // Enable the lap completion trigger.
        lapCompleteTrigger.SetActive(true);

        // Disable the halfway trigger.
        halfLapTrigger.SetActive(false);
    }
}