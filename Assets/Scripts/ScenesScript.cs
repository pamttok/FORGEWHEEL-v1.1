using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Central handler for menu navigation button callbacks — wires up UI
/// buttons across the main menu and related screens to scene transitions
/// (or quitting the application entirely).
/// </summary>
public class ScenesScript : MonoBehaviour
{
    // ---------------------------------------------------------------
    // Menu Navigation Callbacks
    // ---------------------------------------------------------------

    /// <summary>
    /// Begins a new game by loading the track selection screen.
    /// </summary>
    public void StartGameButton()
    {
        SceneManager.LoadScene("TrackSelect");
    }

    /// <summary>
    /// Quits the application. In the Unity Editor, stops Play Mode
    /// instead, since Application.Quit() has no effect there.
    /// </summary>
    public void ReturnToDesktopButton()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    /// <summary>
    /// Opens the credits screen.
    /// </summary>
    public void CreditButton()
    {
        SceneManager.LoadScene("Credits");
    }

    /// <summary>
    /// Generic "back" callback returning to the main menu.
    /// </summary>
    public void BackButtonOne()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Opens the garage/customization screen. Explicitly resets time
    /// scale to 1 in case this is reached from a paused state
    /// (e.g. pause menu -> garage).
    /// </summary>
    public void GarageButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Garage");
    }

    /// <summary>
    /// Opens the information/help screen.
    /// </summary>
    public void InformationButton()
    {
        SceneManager.LoadScene("Information");
    }
    
}
