using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_B : MonoBehaviour
{
    public Text taskName;
    public bool isActive;
    public GameObject greenBar;
    public GameObject blueBar;
    private UI_Manager_B ui;

    void Awake()
    {
        isActive = true;
        ui = FindObjectOfType<UI_Manager_B>();
    }

    public void SetNameTo(string str)
    {
        taskName.text = str;
    }

    public string GetTaskName()
    {
        return taskName.text;
    }

    public void EditTask()
    {
        ui.OpenEditTaskPanel();
    }
}
