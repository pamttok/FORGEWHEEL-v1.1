using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LoseUI : MonoBehaviour
{
    [SerializeField] private GameObject loseUI;

    private void Update()
    {
        StartCoroutine(TimeUP());
    }
    IEnumerator TimeUP()
    {
        yield return new WaitForSeconds(46.6f);
        FindFirstObjectByType<ModeScore>().SaveFinalScore();
        loseUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

}