using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultTracker : MonoBehaviour
{
    public float timeTracker;
    public Text textBox;        // just for testing
    public List<float> results;
    private int currentTaskIndex;
    public bool trackTime = false;
    public int tasksDone = 0;
    public TextMeshProUGUI result_task2;
    public TextMeshProUGUI result_task4;
    public TextMeshProUGUI result_task7;
    public TextMeshProUGUI result_task8;
    public TextMeshProUGUI result_task9;
    public GameObject resultCanvas;

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
            WriteResult();
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

    private void WriteResult()
    {
        if (results.Count == 2)     result_task2.text = results[results.Count-1].ToString("0.00");
        if (results.Count == 4)     result_task4.text = results[results.Count-1].ToString("0.00");
        if (results.Count == 7)     result_task7.text = results[results.Count-1].ToString("0.00");
        if (results.Count == 8)     result_task8.text = results[results.Count-1].ToString("0.00");
        if (results.Count == 9)     result_task9.text = results[results.Count-1].ToString("0.00");
    }

    public void ShowResults()
    {
        for (int i = 0; i < results.Count; i++)
        {
            Debug.Log("Result " + (i + 1) + ": " + results[i] + " sek.");
        }

        StartCoroutine(OpenResultPanel());
    }

    private IEnumerator OpenResultPanel()
    {
        yield return new WaitForSeconds(1f);
        resultCanvas.SetActive(true);
    }
}
