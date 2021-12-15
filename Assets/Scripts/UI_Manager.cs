using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject bottomBar;
    public GameObject inputField;
    public GameObject submitButton;
    private Vector3 bottomBarStart, inputFieldStart, submitButtonStart;

    void Start()
    {
        bottomBarStart = bottomBar.transform.position;
        inputFieldStart = inputField.transform.position;
        submitButtonStart = submitButton.transform.position;
    }

    public void OnInputFieldSelected()
    {
        var tmp = bottomBar.transform.position;
        tmp.y += 5.8f;
        bottomBar.transform.position = tmp;

        tmp = inputField.transform.position;
        tmp.y += 5.8f;
        inputField.transform.position = tmp;

        tmp = submitButton.transform.position;
        tmp.y += 5.8f;
        submitButton.transform.position = tmp;
    }

    public void OnInputFieldDeselected()
    {
        bottomBar.transform.position = bottomBarStart;
        inputField.transform.position = inputFieldStart;
        submitButton.transform.position = submitButtonStart;
    }
}
