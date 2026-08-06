using UnityEngine;
using TMPro;

public class ModeScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreValue;

    [SerializeField] private TMP_Text winFinalScore;
    [SerializeField] private TMP_Text winHighScore;

    [SerializeField] private TMP_Text loseFinalScore;
    [SerializeField] private TMP_Text loseHighScore;

    public static int currentScore;

    private const string HighScoreKey = "ScoreAttackHighScore";

    private int highScore;

    private void Start()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    private void Update()
    {
        scoreValue.text = currentScore.ToString();
    }

    /// <summary>
    /// Call this when the game ends (Win or Lose).
    /// </summary>
    public void SaveFinalScore()
    {
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