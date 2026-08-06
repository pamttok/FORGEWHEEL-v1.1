using UnityEngine;

/// <summary>
/// Awards points to the player when this object is triggered
/// and then disables itself to prevent repeated scoring.
/// </summary>
public class GreenScore : MonoBehaviour
{
    [SerializeField] private AudioSource collectAudio;
    /// <summary>
    /// Called when another collider enters this trigger.
    /// Increases the player's score, play the audio and deactivates this object.
    /// </summary>
    public void OnTriggerEnter()
    {
        collectAudio.Play();
        // Add points to the player's current score.
        ModeScore.currentScore += 50;

        // Disable this scoring object after it has been collected.
        gameObject.SetActive(false);
    }
}