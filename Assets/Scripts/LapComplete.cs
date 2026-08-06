using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {
    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;

    public GameObject minuteDisplay;
    public GameObject secondDisplay;
    public GameObject milliDisplay;

    public GameObject lapTimeBox;

    public GameObject lapCounter;
    public int lapsDone;
    public float _rawTime;
    public GameObject raceFinish;


    private void Update()
    {
        if (lapsDone == 2)
        {
            raceFinish.SetActive(true);
        }
    }


    void OnTriggerEnter()
    {
        lapsDone += 1;
        _rawTime = PlayerPrefs.GetFloat("rawTime");
        if (LapTimeManager.rawTime <= _rawTime)
        {
            if (LapTimeManager.secondCount <= 9)
            {
                secondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.secondCount + ".";
            }
            else
            {
                secondDisplay.GetComponent<Text>().text = ":" + LapTimeManager.secondCount + ".";
            }
            if (LapTimeManager.minuteCount <= 9)
            {
                minuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.minuteCount + ".";
            }
            else
            {
                minuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.minuteCount + ".";
            }
            milliDisplay.GetComponent<Text>().text = "" + LapTimeManager.milliCount;
        }
        PlayerPrefs.SetInt("MinSave", LapTimeManager.minuteCount);
        PlayerPrefs.SetInt("SecSave", LapTimeManager.secondCount);
        PlayerPrefs.SetFloat("MilliSave", LapTimeManager.milliCount);
        PlayerPrefs.SetFloat("_rawTime", LapTimeManager.rawTime);
        LapTimeManager.minuteCount = 0;
        LapTimeManager.secondCount = 0;
        LapTimeManager.milliCount = 0;
        LapTimeManager.rawTime = 0;
        lapCounter.GetComponent<Text>().text = "" + lapsDone;

        halfLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);
    }
}