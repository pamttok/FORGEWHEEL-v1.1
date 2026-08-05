using UnityEngine;
using UnityEngine.UI;
public class LapComplete : MonoBehaviour
{
    // Reference to the lap completion trigger.
    [SerializeField] private GameObject lapCompleteTrigger;

    // Reference to the halfway lap trigger.
    [SerializeField] private GameObject halfLapTrigger;
    [SerializeField] private GameObject winUI;

    private void OnTriggerEnter()
    {
        // Enable the halfway trigger
        halfLapTrigger.SetActive(true);
        // Disable the lap completion trigger until the halfway point is reached.
        lapCompleteTrigger.SetActive(true);
        FindFirstObjectByType<ModeScore>().SaveFinalScore();
        winUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
}