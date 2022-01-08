using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManagerB : MonoBehaviour
{
    public GameObject taskPrefab;
    private List<GameObject> tasks = new List<GameObject>();
    private List<bool> toggleStati = new List<bool>();
    public Transform activeScrollViewContent;
    public Transform doneScrollViewContent;
    private string taskName;
    public Color32 setToDoneColor;
    public Color32 setToActiveColor;

    public void UpdateTaskName(string str)
    {
        Debug.Log("update task Name");
        taskName = str;
    }

    public void CreateNewTask()
    {
        Debug.Log("creating new task");
        if (taskName == null)   return;

        if (taskName.Length > 0)
        {
            GameObject newTask = Instantiate(taskPrefab);
            newTask.transform.SetParent(activeScrollViewContent, false);
            newTask.GetComponentInChildren<Text>().text = taskName;
            tasks.Add(newTask);
            toggleStati.Add(newTask.GetComponent<Task_B>().isActive);
        }
    }

    private IEnumerator ToggleTask(GameObject listElement)
    {
        yield return new WaitForSeconds(0.4f);
        listElement.GetComponent<FadeObject_B>().fadeOut = true;
        yield return new WaitForSeconds(0.5f);

        if (!listElement.GetComponent<Task_B>().isActive)
        {
            listElement.transform.SetParent(doneScrollViewContent, false);
            listElement.GetComponent<Task_B>().greenBar.SetActive(false);
            listElement.GetComponent<Task_B>().blueBar.SetActive(true);
        }
        else
        {
            listElement.transform.SetParent(activeScrollViewContent, false);
            listElement.GetComponent<Task_B>().greenBar.SetActive(true);
            listElement.GetComponent<Task_B>().blueBar.SetActive(false);
        }
        listElement.GetComponent<FadeObject_B>().fadeIn = true;
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
            if (tasks[i].GetComponent<Task_B>().isActive != toggleStati[i])
            {
                StartCoroutine(ToggleTask(tasks[i]));
                toggleStati[i] = !toggleStati[i];
            }
        }
        if (indexToRemove < 1000)       tasks.RemoveAt(indexToRemove);
    }
}
