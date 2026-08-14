using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks and displays the live lap timer (minutes : seconds . milliseconds).
/// Values are static so other scripts (e.g. LapComplete) can read/reset
/// the current lap time when a lap boundary is crossed.
/// </summary>
public class LapTimeManager : MonoBehaviour {

    // ---------------------------------------------------------------
    // Static Timer State (shared across scripts, e.g. LapComplete)
    // ---------------------------------------------------------------

    /// <summary>Current minutes elapsed on the active lap.</summary>
    public static int minuteCount;

    /// <summary>Current seconds elapsed on the active lap (0-59).</summary>
    public static int secondCount;

    /// <summary>Current "milli" tick count (0-9), driving the fractional-second display.</summary>
    public static float milliCount;

    /// <summary>Formatted string version of milliCount, used for UI display.</summary>
    public static string milliDisplay;

    /// <summary>Total elapsed time for the current lap, in raw seconds (unformatted).</summary>
    public static float rawTime;

    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("UI GameObject displaying the minutes portion of the timer.")]
    public GameObject minuteBox;

    [Tooltip("UI GameObject displaying the seconds portion of the timer.")]
    public GameObject secondBox;

    [Tooltip("UI GameObject displaying the milliseconds portion of the timer.")]
    public GameObject milliBox;

    // ---------------------------------------------------------------
    // Unity Lifecycle
    // ---------------------------------------------------------------

    /// <summary>
    /// Advances the lap timer every frame and refreshes the
    /// minute/second/milli UI displays accordingly.
    /// </summary>
    private void Update () {
        // Advance the "milli" tick (0-9 range, scaled by 10 rather than true milliseconds)
        // and the true raw elapsed time in parallel.
        milliCount += Time.deltaTime * 10;
        rawTime += Time.deltaTime;

        // Update the milliseconds display.
        milliDisplay = milliCount.ToString("F0");
        milliBox.GetComponent<Text>().text = "" + milliDisplay;

        // Roll over into seconds once the milli tick hits its max.
        if (milliCount >= 10)
        {
            milliCount = 0;
            secondCount += 1;
        }

        // Update the seconds display, zero-padded below 10.
        if (secondCount <= 9)
        {
            secondBox.GetComponent<Text>().text = "0" + secondCount + ".";
        }
        else
        {
            secondBox.GetComponent<Text>().text = "" + secondCount + ".";
        }

        // Roll over into minutes once seconds hits 60.
        if (secondCount >= 60)
        {
            secondCount = 0;
            minuteCount += 1;
        }

        // Update the minutes display, zero-padded below 10.
        if (minuteCount <= 9)
        {
            minuteBox.GetComponent<Text>().text = "0" + minuteCount + ":";
        }
        else
        {
            minuteBox.GetComponent<Text>().text = "" + minuteCount + ":";
        }
	}
}
