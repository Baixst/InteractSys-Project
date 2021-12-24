using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject taskPrefab;
    private List<GameObject> tasks = new List<GameObject>();
    private List<bool> toggleStati = new List<bool>();
    public Transform activeScrollViewContent;
    public Transform doneScrollViewContent;
    private string taskName;

    public void UpdateTaskName(string str)
    {
        taskName = str;
    }

    public void CreateNewTask()
    {
        if (taskName == null)   return;

        if (taskName.Length > 0)
        {
            GameObject newTask = Instantiate(taskPrefab);
            newTask.transform.SetParent(activeScrollViewContent, false);
            newTask.GetComponentInChildren<Text>().text = taskName;
            tasks.Add(newTask);
            toggleStati.Add(newTask.GetComponentInChildren<Toggle>().isOn);
        }
    }

    private IEnumerator ToggleTask(GameObject listElement)
    {
        yield return new WaitForSeconds(0.2f);
        listElement.GetComponent<FadeObject>().fadeOut = true;
        yield return new WaitForSeconds(0.35f);

        if (listElement.GetComponentInChildren<Toggle>().isOn)
        {
            listElement.transform.SetParent(doneScrollViewContent, false);
            listElement.GetComponent<FadeObject>().fadeIn = true;
        }
        else
        {
            listElement.transform.SetParent(activeScrollViewContent, false);
            listElement.GetComponent<FadeObject>().fadeIn = true;
        }
    }

    void Update()
    {
        if (tasks == null)  return;
        int indexToRemove = 1000;

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i] == null)
            {
                indexToRemove = i;
                continue;
            }
            if (tasks[i].GetComponentInChildren<Toggle>().isOn != toggleStati[i])
            {
                StartCoroutine(ToggleTask(tasks[i]));
                toggleStati[i] = !toggleStati[i];
            }
        }
        if (indexToRemove < 1000)       tasks.RemoveAt(indexToRemove);
    }
}
