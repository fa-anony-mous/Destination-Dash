using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStarter : MonoBehaviour
{

    int once = 1;
    public TMP_Text lapTimeText; // Reference to the UI text element to display lap time
    public TMP_Text bestLapTimeText; // Reference to the UI text element to display lap time
    private float lapStartTime; // Time when the lap started
    private float lapTime; // Lap time in seconds
    public int game = 0;
    public GameObject[] gameCanvas;
    public GameObject[] aiObjects;
    public GameObject[] humanObjects;

    float bestTime = Mathf.Infinity;


    void Start()
    {
        PlayerPrefs.SetFloat("bestTime", Mathf.Infinity);
    }
    public void HumanPlay(){
        game = -1;
        foreach(GameObject obj in humanObjects){
            obj.SetActive(true);
        }
        foreach(GameObject obj in aiObjects){
            obj.SetActive(false);
        }
        foreach(GameObject obj in gameCanvas){
            obj.SetActive(false);
        }
        
        // Initialize lap time variables
        lapStartTime = Time.time;
        lapTime = 0f;

        if(PlayerPrefs.GetFloat("bestTime") == Mathf.Infinity){
            bestLapTimeText.text = "Lap Time: " + FormatTime(0f);
        }
        else{
            bestLapTimeText.text = "Lap Time: " + FormatTime(PlayerPrefs.GetFloat("bestTime"));
        }
    }
    public void AiPlay(){
        Debug.Log("AiPlay");
        game = -1;
        foreach(GameObject obj in humanObjects){
            obj.SetActive(false);
        }
        foreach(GameObject obj in aiObjects){
            obj.SetActive(true);
        }
        foreach(GameObject obj in gameCanvas){
            obj.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && game == 0)
        {
            AiPlay();
        }
        if (Input.GetKeyDown(KeyCode.P) && game == 0)
        {
            HumanPlay();
        }

        // Calculate lap time
        lapTime = Time.time - lapStartTime;

        // Update lap time UI text
        if(lapTimeText.isActiveAndEnabled){
            lapTimeText.text = "Lap Time: " + FormatTime(lapTime);
        }
        
    }
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
    public void ResetLapTime()
    {
        lapStartTime = Time.time;
        lapTime = 0f;
    }
    public void FinishedLap(){
        if(once<1){
            return;
        }
        Debug.Log("updated");
        once--;
        if(lapTime < bestTime){
            bestTime = lapTime;
        }
        bestLapTimeText.text = "Lap Time: " + FormatTime(bestTime);
        PlayerPrefs.SetFloat("bestTime", bestTime);
        ResetLapTime();
    }
}
