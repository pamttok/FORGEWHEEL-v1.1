using UnityEngine;
using TMPro;
using System.Collections;
public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] float remainingTime;
    

    private void Update()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3.85f);
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timer.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
