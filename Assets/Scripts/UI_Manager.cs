using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject newTaskPanel;
    public GameObject menuButton;
    public GameObject searchButton;
    public GameObject activeScrollView;
    public GameObject doneScrollView;
    public GameObject DoneAllButton;
    public GameObject DeleteAllButton;
    public GameObject ActivateAllButton;
    public SpriteRenderer activeListBar;
    public SpriteRenderer doneListBar;
    public Color selectedColor;
    public Color deselectedColor;

    void Start()
    {
        newTaskPanel.SetActive(false);
        doneScrollView.SetActive(false);
        ActivateAllButton.SetActive(false);
    }

    public void OpenNewTaskPanel()
    {
        newTaskPanel.SetActive(true);
        searchButton.SetActive(false);
        menuButton.SetActive(false);
        DoneAllButton.SetActive(false);
        DeleteAllButton.SetActive(false);
        ActivateAllButton.SetActive(false);
    }

    public void CloseNewTaskPanel()
    {
        newTaskPanel.SetActive(false);
        searchButton.SetActive(true);
        menuButton.SetActive(true);
        DoneAllButton.SetActive(true);
        DeleteAllButton.SetActive(true);
        ActivateAllButton.SetActive(false);
    }

    public void GoToActiveList()
    {
        activeListBar.color = selectedColor;
        doneListBar.color = deselectedColor;
        activeScrollView.SetActive(true);
        doneScrollView.SetActive(false);
        DoneAllButton.SetActive(true);
        ActivateAllButton.SetActive(false);

    }

    public void GoToDoneList()
    {
        activeListBar.color = deselectedColor;
        doneListBar.color = selectedColor;
        activeScrollView.SetActive(false);
        doneScrollView.SetActive(true);
        DoneAllButton.SetActive(false);
        ActivateAllButton.SetActive(true);

    }
}
