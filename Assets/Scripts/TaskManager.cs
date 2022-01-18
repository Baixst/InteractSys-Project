using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject taskPrefab;
    public List<GameObject> tasks = new List<GameObject>();
    private List<bool> toggleStati = new List<bool>();
    public Transform activeScrollViewContent;
    public Transform doneScrollViewContent;
    private string taskName;
    public UI_Manager UI;
    public ResultTracker tracker;
    public int toggledTasks;
    public InstructionManager instructionManager;

    bool TaskRunning = false;

    private void Start()
    {
        toggledTasks = 0;
    }
    public void UpdateTaskName(string str)
    {
        taskName = str;
    }

    public void CreateNewTask()
    {
        if (taskName == null) return;

        if (taskName.Length > 0)
        {
            GameObject newTask = Instantiate(taskPrefab);
            newTask.transform.SetParent(activeScrollViewContent, false);
            newTask.GetComponentInChildren<Text>().text = taskName;
            tasks.Add(newTask);
            toggleStati.Add(newTask.GetComponentInChildren<Toggle>().isOn);


        }
    }

    private IEnumerator ToggleTask(GameObject listElement, int listPosition, bool destroy)
    {
        yield return new WaitForSeconds(0.2f);
        listElement.GetComponent<FadeObject>().fadeOut = true;
        yield return new WaitForSeconds(0.35f);


        if (listElement.GetComponentInChildren<Toggle>().isOn && UI.onActivePage)
        {
            listElement.transform.SetParent(doneScrollViewContent, false);
            listElement.GetComponent<FadeObject>().fadeIn = true;
            listElement.GetComponentInChildren<Toggle>().isOn = false;
        }
        else if (listElement.GetComponentInChildren<Toggle>().isOn && UI.onActivePage == false)
        {
            listElement.transform.SetParent(activeScrollViewContent, false);
            listElement.GetComponent<FadeObject>().fadeIn = true;
            listElement.GetComponentInChildren<Toggle>().isOn = false;

        }

        if (destroy)
        {

            //tasks.RemoveAt(listPosition);
            //Destroy(listElement);
            ArrangeTasks(listPosition);
            
           
        }
    }

    void Update()
    {
        if ((tasks.Count == 1 && tracker.tasksDone == 0) || (tasks.Count == 2 && tracker.tasksDone == 2) || (tasks.Count == 5 && tracker.tasksDone == 4)
            || (tasks.Count == 6 && tracker.tasksDone == 5))
        {
            tracker.StopTime();     //erste, dritte, vierte, fünfte Task Ende
            instructionManager.ShowNextInstruction();
            //tracker.ShowResults();
        }

        if (tracker.tasksDone==8 && TaskRunning==false && UI.onActivePage)
        {
            tracker.tasksDone = 9;
        }

        checkToggledTasks();
        if (toggledTasks > 0)
        {
            
            if (UI.onNewTaskPage)
            {
                UI.DeactivateAllButtons();
            }
            else if (UI.onNewTaskPage == false && UI.onActivePage)
            {
                UI.ActivateActiveButtons();
            }
            else
            {
                UI.ActivateDoneButtons();
            }

        }
        else
        {
            UI.DeactivateAllButtons();
        }


    }

    public void deleteChecked()
    {
        if (tasks == null) return;
        int indexToRemove = 1000;

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i] == null)
            {
                indexToRemove = i;
                continue;
            }
            if (tasks[i].GetComponentInChildren<Toggle>().isOn)
            {
                toggleStati[i] = !toggleStati[i];
                StartCoroutine(ToggleTask(tasks[i], i, true));

            }
        }
        if (indexToRemove < 1000) tasks.RemoveAt(indexToRemove);
       
        if (tracker.tasksDone == 8 )
        { 
                TaskRunning = false;
                tracker.StopTime();
                //neunte(zehnte) Task beenden
                tracker.ShowResults();
        }
    }

    public void doneChecked()
    {

        if (tasks == null) return;
        int indexToRemove = 1000;

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i] == null)
            {
                indexToRemove = i;
                continue;
            }
            if (tasks[i].GetComponentInChildren<Toggle>().isOn)
            {
                toggleStati[i] = !toggleStati[i];
                StartCoroutine(ToggleTask(tasks[i], i, false));

            }


        }
        if (indexToRemove < 1000) tasks.RemoveAt(indexToRemove);

        if (tracker.tasksDone == 1 || tracker.tasksDone == 3 || tracker.tasksDone == 6 || tracker.tasksDone == 7)
        {
          //  if (TaskRunning == true)
          //  {
               
                tracker.StopTime();
        //        TaskRunning = false;
                instructionManager.ShowNextInstruction();
                //zweite, vierte, siebte, achte Task beenden

       //     }

        }
    }

    public void checkToggledTasks()
    {
        toggledTasks = 0;
        if (tasks != null)
        {

            for (int i = 0; i < tasks.Count; i++)
            {
                if ( tasks[i] != null && tasks[i].GetComponentInChildren<Toggle>().isOn)
                {
                    toggledTasks++;
                }

            }
        }
        //Debug.Log("Tasks: " + toggledTasks)

    }

    void ArrangeTasks(int listPosition)
    {
       

        if (tasks != null)
        {

            for (int i = 0; i < tasks.Count; i++)
            {
                if (i == listPosition)
                {
                    Destroy(tasks[i]);
                    tasks.RemoveAt(i);

                }
            }

        }
    }
}
