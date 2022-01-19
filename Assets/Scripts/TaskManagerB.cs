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
    public ResultTracker tracker;
    public InstructionManager instructionManager;

    bool TaskRunning = false;
    private int tasksToggeled = 0;
    private int tasksDeleted = 0;

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
        if ((tasks.Count == 1 && tracker.tasksDone == 0) || (tasks.Count == 2 && tracker.tasksDone == 2) || (tasks.Count == 5 && tracker.tasksDone == 4)
            || (tasks.Count == 6 && tracker.tasksDone == 5))
        {
            tracker.StopTime();     //erste, dritte, vierte, fuenfte Task Ende
            instructionManager.ShowNextInstruction();
        }

        if (tracker.tasksDone== 8 && TaskRunning == false)
        {
            tracker.tasksDone = 9;
        }

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

    public void CheckOnDelete()
    {
        if (tracker.tasksDone == 9)
        {
            tasksDeleted++;

            if (tasksDeleted == 5)
            {
                TaskRunning = false;
                tracker.StopTime();
                tracker.ShowResults();
            }
        }
    }

    public void CheckOnToggle()
    {
        if (tracker.tasksDone == 1 || tracker.tasksDone == 3 || tracker.tasksDone == 7)
        {
            tracker.StopTime();
            instructionManager.ShowNextInstruction();
            return;
        }

        if (tracker.tasksDone == 6)
        {
            tasksToggeled++;
        }

        if (tasksToggeled == 4)
        {
            tracker.StopTime();
            instructionManager.ShowNextInstruction();
        }
    }
}
