using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTracker : MonoBehaviour
{
    public float timeTracker;
    public Text textBox;        // just for testing
    public List<float> results;
    private int currentTaskIndex = 0;
    private bool trackTime = false;

    void Start()
    {
        textBox.text = timeTracker.ToString("F2");
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
        trackTime = false;
        results[currentTaskIndex] = timeTracker;
        currentTaskIndex++;
    }

    public void TrackNextTime()
    {
        timeTracker = 0;
        trackTime = true;
    }
}
