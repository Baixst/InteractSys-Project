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

    void Awake()
    {
        isActive = true;
    }

    public void SetNameTo(string str)
    {
        taskName.text = str;
    }

    public string GetTaskName()
    {
        return taskName.text;
    }
}
