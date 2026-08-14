using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the pause menu: toggling it open via the Escape key,
/// resuming gameplay, returning to the main menu. Manages time scale and audio pausing alongside
/// the UI state.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("Root UI container for the pause menu panel.")]
    [SerializeField] private GameObject container;

    // ---------------------------------------------------------------
    // Unity Lifecycle
    // ---------------------------------------------------------------

    /// <summary>
    /// Listens for the pause input each frame and opens the pause
    /// menu (freezing time and audio) when pressed.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
    }

    // ---------------------------------------------------------------
    // Button Callbacks
    // ---------------------------------------------------------------

    /// <summary>
    /// Closes the pause menu and resumes normal gameplay speed and audio.
    /// </summary>
    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    /// <summary>
    /// Unpauses audio and returns the player to the main menu scene.
    /// </summary>
    public void MainMenu()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Resumes time/audio and reloads the current level from the start.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(4);
    }
}
