using UnityEngine;
using TMPro;
using System.Collections;

/// <summary>
/// Displays a countdown timer in HH:MM:SS format on a TextMeshPro UI element.
/// Timer text turns red once time has expired.
/// </summary>
public class CountdownTimer : MonoBehaviour
{
    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("UI text element used to display the formatted countdown.")]
    [SerializeField] private TextMeshProUGUI timer;

    [Tooltip("Time remaining on the countdown, in seconds.")]
    [SerializeField] float remainingTime;

    // ---------------------------------------------------------------
    // Unity Lifecycle
    // ---------------------------------------------------------------

    /// <summary>
    /// Fires every frame; kicks off the timer update coroutine.
    /// </summary>
    private void Update()
    {
        StartCoroutine(Timer());
    }

    // ---------------------------------------------------------------
    // Timer Logic
    // ---------------------------------------------------------------

    /// <summary>
    /// Waits briefly, then decrements the remaining time (if any left),
    /// clamps it at zero and flags expiry with a red color change,
    /// and refreshes the displayed MM:SS text.
    /// </summary>
    IEnumerator Timer()
    {
        // Delay before applying this tick's time update.
        yield return new WaitForSeconds(3.85f);

        if (remainingTime > 0)
        {
            // Countdown still active: tick time down.
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            // Timer has expired: clamp to zero and signal visually.
            remainingTime = 0;
            timer.color = Color.red;
        }

        // Convert remaining seconds into minutes/seconds for display.
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
