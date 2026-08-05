using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the race countdown sequence before gameplay begins.
/// Displays the countdown, plays audio cues, starts the race timer,
/// enables vehicle controls, and begins the level music.
/// </summary>
public class Countdown : MonoBehaviour
{
    // Reference to the countdown UI text object.
    [SerializeField] private GameObject countDown;

    // Audio played during the "3", "2", and "1" countdown.
    [SerializeField] private AudioSource getReady;

    // Audio played when the race starts.
    [SerializeField] private AudioSource goAudio;
    [SerializeField] private AudioSource levelMusic;

    /// <summary>
    /// Starts the countdown sequence when the scene loads.
    /// </summary>
    private void Start()
    {
        StartCoroutine(CountStart());
    }
    /// <summary>
    /// Performs the race countdown, plays the appropriate
    /// sound effects, and enables gameplay once complete.
    /// </summary>
    IEnumerator CountStart()
    {
        // Small delay before displaying the countdown.
        yield return new WaitForSeconds(0.5f);

        // Display "3".
        countDown.GetComponent<TMPro.TMP_Text>().text = "3";
        getReady.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);

        // Display "2".
        countDown.SetActive(false);
        countDown.GetComponent<TMPro.TMP_Text>().text = "2";
        getReady.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);

        // Display "1".
        countDown.SetActive(false);
        countDown.GetComponent<TMPro.TMP_Text>().text = "1";
        getReady.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);

        // Hide the countdown and start the race.
        countDown.SetActive(false);

        // Play the race start sound.
        goAudio.Play();

        //play the level music
        levelMusic.Play();
    }
}