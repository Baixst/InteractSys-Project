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
    public UI_Manager UI;
    public int toggledTasks;

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

    private IEnumerator ToggleTask(GameObject listElement, bool destroy)
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
            Destroy(listElement);
            tasks.Remove(tasks[tasks.Count - 1]);
        }
    }

    void Update()
    {
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
                StartCoroutine(ToggleTask(tasks[i], true));

            }
        }
        if (indexToRemove < 1000) tasks.RemoveAt(indexToRemove);
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
                StartCoroutine(ToggleTask(tasks[i], false));
     
              } 
          
         
        }
        if (indexToRemove < 1000) tasks.RemoveAt(indexToRemove);
    }

    public void checkToggledTasks()
    {
        toggledTasks = 0;
        if (tasks != null)
        {
            
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].GetComponentInChildren<Toggle>().isOn)
                {
                    toggledTasks++;
                }

            }
        }
        Debug.Log("Tasks: " + toggledTasks)
;       
    }
}
