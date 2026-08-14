using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Drives the pre race countdown sequence ("3, 2, 1, GO!") at the start of a level.
/// Handles UI display, audio cues, and enabling gameplay-critical systems
/// (car controls, lap timer) once the countdown completes.
/// </summary>
public class Countdown : MonoBehaviour {

    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("UI GameObject containing the Text component used to display the countdown digits.")]
    public GameObject countDown;

    [Tooltip("Audio cue played for each countdown tick (3, 2, 1).")]
    public AudioSource getReady;

    [Tooltip("Audio cue played once the countdown reaches 'GO'.")]
    public AudioSource goAudio;

    [Tooltip("Background music that starts once the race begins.")]
    public AudioSource levelMusic;

    [Tooltip("UI element tracking lap time; enabled once the race starts.")]
    public GameObject lapTimer;

    [Tooltip("Script/UI component granting player control of the car; enabled once the race starts.")]
    public GameObject carControls;

    // ---------------------------------------------------------------
    // Unity Lifecycle
    // ---------------------------------------------------------------

    /// <summary>
    /// Kicks off the countdown sequence as soon as the scene starts.
    /// </summary>
    private void Start () {
        StartCoroutine(CountStart());
		
	}

    // ---------------------------------------------------------------
    // Countdown Sequence
    // ---------------------------------------------------------------

    /// <summary>
    /// Coroutine that steps through the countdown UI/audio and then
    /// hands control over to the player once the race begins.
    /// </summary>
    IEnumerator CountStart()
    {
        // Small buffer before the countdown starts, so the scene doesn't
        // feel like it's snapping straight into gameplay.
        yield return new WaitForSeconds(0.5f);

        // --- "3" ---
        countDown.GetComponent<Text>().text = "3";
        getReady.Play();
        countDown.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);

        // --- "2" ---
        countDown.GetComponent<Text>().text = "2";
        getReady.Play();
        countDown.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);

        // --- "1" ---
        countDown.GetComponent<Text>().text = "1";
        getReady.Play();
        countDown.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);

        // --- "GO" ---
        // Countdown UI stays hidden here; the "GO" cue is audio-only.
        goAudio.Play();
        getReady.Stop(); // Ensure no lingering tick sound overlaps with the go cue.
        levelMusic.Play();

        // Race officially starts: unlock the timer and player input.
        lapTimer.SetActive(true);
        carControls.SetActive(true);
    }
}
