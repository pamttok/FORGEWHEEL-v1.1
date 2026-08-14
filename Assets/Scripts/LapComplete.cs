using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles lap-completion logic: increments the lap counter, checks/updates
/// the best lap time (persisted via PlayerPrefs), refreshes the lap time UI,
/// resets the live lap timer for the next lap, and triggers race-finish
/// once the required number of laps is done.
/// </summary>
public class LapComplete : MonoBehaviour {

    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("Trigger collider that fires this lap-complete logic; disabled after use until re-armed.")]
    public GameObject lapCompleteTrig;

    [Tooltip("Trigger collider marking the halfway point of the next lap; re-armed after this lap completes.")]
    public GameObject halfLapTrig;

    [Tooltip("UI text element displaying the best lap's minutes.")]
    public GameObject minuteDisplay;

    [Tooltip("UI text element displaying the best lap's seconds.")]
    public GameObject secondDisplay;

    [Tooltip("UI text element displaying the best lap's milliseconds.")]
    public GameObject milliDisplay;

    [Tooltip("Container UI element holding the lap time display.")]
    public GameObject lapTimeBox;

    [Tooltip("UI text element showing the total number of completed laps.")]
    public GameObject lapCounter;

    [Tooltip("Total number of laps completed so far.")]
    public int lapsDone;

    // ---------------------------------------------------------------
    // Internal State
    // ---------------------------------------------------------------

    [Tooltip("Cached best raw lap time loaded from PlayerPrefs, used for comparison against the current lap.")]
    public float _rawTime;

    [Tooltip("Object activated once the race is finished (required lap count reached).")]
    public GameObject raceFinish;

    // ---------------------------------------------------------------
    // Unity Lifecycle
    // ---------------------------------------------------------------

    /// <summary>
    /// Checks each frame whether the race is complete (2 laps done)
    /// and activates the race-finish object once it is.
    /// </summary>
    private void Update()
    {
        if (lapsDone == 2)
        {
            raceFinish.SetActive(true);
        }
    }

    // ---------------------------------------------------------------
    // Trigger Events
    // ---------------------------------------------------------------

    /// <summary>
    /// Fired when the player crosses the lap-complete trigger.
    /// Updates lap count, compares/updates the best lap time display,
    /// persists best-lap data, resets the live timer, and re-arms
    /// the triggers for the next lap.
    /// </summary>
    void OnTriggerEnter()
    {
        lapsDone += 1;

        // Load the previously saved best raw lap time for comparison.
        _rawTime = PlayerPrefs.GetFloat("rawTime");

        // Only update the displayed best lap time if this lap beat (or tied) the saved best.
        if (LapTimeManager.rawTime <= _rawTime)
        {
            // --- Seconds display (zero-padded, with special-case prefix formatting) ---
            if (LapTimeManager.secondCount <= 9)
            {
                secondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.secondCount + ".";
            }
            else
            {
                secondDisplay.GetComponent<Text>().text = ":" + LapTimeManager.secondCount + ".";
            }

            // --- Minutes display (zero-padded) ---
            if (LapTimeManager.minuteCount <= 9)
            {
                minuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.minuteCount + ".";
            }
            else
            {
                minuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.minuteCount + ".";
            }

            // --- Milliseconds display ---
            milliDisplay.GetComponent<Text>().text = "" + LapTimeManager.milliCount;
        }

        // Persist this lap's time as the new saved best-lap data.
        PlayerPrefs.SetInt("MinSave", LapTimeManager.minuteCount);
        PlayerPrefs.SetInt("SecSave", LapTimeManager.secondCount);
        PlayerPrefs.SetFloat("MilliSave", LapTimeManager.milliCount);
        PlayerPrefs.SetFloat("_rawTime", LapTimeManager.rawTime);

        // Reset the live lap timer ready for the next lap.
        LapTimeManager.minuteCount = 0;
        LapTimeManager.secondCount = 0;
        LapTimeManager.milliCount = 0;
        LapTimeManager.rawTime = 0;

        // Update the on-screen lap counter.
        lapCounter.GetComponent<Text>().text = "" + lapsDone;

        // Re-arm the half-lap trigger for the next lap, disarm this one until reset.
        halfLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);
    }
}
