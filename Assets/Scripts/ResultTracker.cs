using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTracker : MonoBehaviour
{
    public float timeTracker;
    public Text textBox;        // just for testing
    public List<float> results;
    private int currentTaskIndex;
    public bool trackTime = false;
    public int tasksDone = 0;

    void Start()
    {
        textBox.text = timeTracker.ToString("F2");
        currentTaskIndex = 0;
    }

    void Update()
    {
        
        
        if (trackTime)
        {
            timeTracker += Time.deltaTime;
            textBox.text = timeTracker.ToString("F2");
        }
    }

    public void StopTime()
    {
        if (trackTime == true)
        {        
            tasksDone = tasksDone + 1;
            currentTaskIndex++;
            results.Add(timeTracker);
            trackTime = false;

        }
    }

    public void TrackNextTime()
    {
        if (trackTime == false)
        {
            timeTracker = 0;
            trackTime = true;
           
        }

    }

    public void ShowResults()
    {
        for (int i = 0; i < results.Count; i++)
        {
            Debug.Log("Result " + (i + 1) + ": " + results[i] + " sek.");
        }
    }
}
