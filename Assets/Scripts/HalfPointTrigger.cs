using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Marks the halfway point of a lap. When triggered, enables the
/// lap-complete trigger (so crossing the finish line now counts)
/// and disables itself so it can't be re-triggered until reset.
/// </summary>
public class HalfPointTrigger : MonoBehaviour {

    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("Trigger collider that registers a completed lap once the halfway point has been passed.")]
    public GameObject lapCompleteTrig;

    [Tooltip("This half-lap trigger's own GameObject; disabled after firing to prevent re-triggering.")]
    public GameObject halfLapTrig;

    // ---------------------------------------------------------------
    // Trigger Events
    // ---------------------------------------------------------------

    /// <summary>
    /// Fired when something enters this trigger's collider (intended
    /// to be the player's car passing the halfway marker).
    /// Arms the lap-complete trigger and disarms this one.
    /// </summary>
    private void OnTriggerEnter()
    {
        lapCompleteTrig.SetActive(true);
        halfLapTrig.SetActive(false);
    }
}
