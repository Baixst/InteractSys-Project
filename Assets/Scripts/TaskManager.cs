using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public GameObject taskPrefab;
    public Transform scrollViewContent;

    public void createNewTask(string str)
    { 
        GameObject newTask = Instantiate(taskPrefab);
        newTask.transform.SetParent(scrollViewContent, false);
        newTask.GetComponent<Task>().SetNameTo(str);
    }
}
