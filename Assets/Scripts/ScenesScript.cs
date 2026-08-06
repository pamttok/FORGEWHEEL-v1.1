using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesScript : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("TrackSelect");
    }

    public void ReturnToDesktopButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void CreditButton()
    {
        SceneManager.LoadScene("Credits");
    }
    public void BackButtonOne()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GarageButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Garage");
    }
    public void InformationButton()
    {
        SceneManager.LoadScene("Information");
    }
    
}
