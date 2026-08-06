using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads the race scene after a predefined delay.
/// Typically used for splash screens or loading sequences.
/// </summary>
public class LoadToGame : MonoBehaviour
{
    /// <summary>
    /// Starts the delayed scene loading process
    /// when the scene is initialized.
    /// </summary>
    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadRaceArea());
    }

    /// <summary>
    /// Waits for the specified duration before
    /// loading the race scene.
    /// </summary>
    IEnumerator LoadRaceArea()
    {
        // Initial loading delay.
        yield return new WaitForSeconds(3);
        Time.timeScale = 1f;

        // Load the race scene by its build index.
        SceneManager.LoadScene("RaceArea");
    }
}