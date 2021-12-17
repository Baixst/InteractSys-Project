using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public Text taskName;

    public void SetNameTo(string str)
    {
        taskName.text = str;
    }

    public string GetTaskName()
    {
        return taskName.text;
    }
}
