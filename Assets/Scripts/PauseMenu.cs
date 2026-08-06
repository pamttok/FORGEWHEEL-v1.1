using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject container;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
    }
    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void MainMenu()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(4);
    }
}
