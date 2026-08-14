using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Handles the "time's up" lose condition: after a fixed delay,
/// saves the player's final score, shows the lose UI, and pauses
/// the game (both simulation time and audio).
/// </summary>
public class LoseUI : MonoBehaviour
{
    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("UI panel shown when the player runs out of time.")]
    [SerializeField] private GameObject loseUI;

    // ---------------------------------------------------------------
    // Unity Lifecycle
    // ---------------------------------------------------------------

    /// <summary>
    /// Fires every frame; kicks off the time-up coroutine.
    /// </summary>
    private void Update()
    {
        StartCoroutine(TimeUP());
    }

    // ---------------------------------------------------------------
    // Lose Condition
    // ---------------------------------------------------------------

    /// <summary>
    /// Waits out the level's time limit, then triggers the lose state:
    /// records the final score, displays the lose UI, and freezes
    /// gameplay and audio.
    /// </summary>
    IEnumerator TimeUP()
    {
        // Time limit for the level before the "lose" state triggers.
        yield return new WaitForSeconds(46.6f);

        // Persist the player's score at the moment time ran out.
        FindFirstObjectByType<ModeScore>().SaveFinalScore();

        // Show the lose screen.
        loseUI.SetActive(true);

        // Freeze gameplay simulation and mute audio.
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
}
