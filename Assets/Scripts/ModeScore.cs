using UnityEngine;
using TMPro;

/// <summary>
/// Tracks the player's current score for Score Attack mode, persists
/// the all-time high score via PlayerPrefs, and updates the live score
/// display as well as the win/lose end-screen summaries.
/// </summary>
public class ModeScore : MonoBehaviour
{
    // ---------------------------------------------------------------
    // Inspector References
    // ---------------------------------------------------------------

    [Tooltip("UI text showing the live, in-game running score.")]
    [SerializeField] private TMP_Text scoreValue;

    [Tooltip("UI text on the Win screen showing the final score.")]
    [SerializeField] private TMP_Text winFinalScore;

    [Tooltip("UI text on the Win screen showing the all-time high score.")]
    [SerializeField] private TMP_Text winHighScore;

    [Tooltip("UI text on the Lose screen showing the final score.")]
    [SerializeField] private TMP_Text loseFinalScore;

    [Tooltip("UI text on the Lose screen showing the all-time high score.")]
    [SerializeField] private TMP_Text loseHighScore;

    // ---------------------------------------------------------------
    // Score State
    // ---------------------------------------------------------------

    /// <summary>The player's current score, shared/accessible across other scripts.</summary>
    public static int currentScore;

    /// <summary>PlayerPrefs key used to persist the Score Attack high score.</summary>
    private const string HighScoreKey = "ScoreAttackHighScore";

    /// <summary>Cached high score loaded from PlayerPrefs at run start.</summary>
    private int highScore;

    // ---------------------------------------------------------------
    // Unity Lifecycle
    // ---------------------------------------------------------------

    /// <summary>
    /// Resets the current run's score and loads the persisted high score.
    /// </summary>
    private void Start()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    /// <summary>
    /// Keeps the live score display in sync with the current score every frame.
    /// </summary>
    private void Update()
    {
        scoreValue.text = currentScore.ToString();
    }

    // ---------------------------------------------------------------
    // End-of-Game Handling
    // ---------------------------------------------------------------

    /// <summary>
    /// Call this when the game ends (Win or Lose).
    /// </summary>
    public void SaveFinalScore()
    {
        // Update and persist the high score if the player beat it this run.
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
        }

        // Win Screen
        if (winFinalScore != null)
            winFinalScore.text = "Final Score:" + currentScore;
        if (winHighScore != null)
            winHighScore.text = "High Score:" + highScore;

        // Lose Screen
        if (loseFinalScore != null)
            loseFinalScore.text = "Final Score:" + currentScore;
        if (loseHighScore != null)
            loseHighScore.text = "High Score:" + highScore;
    }
}
