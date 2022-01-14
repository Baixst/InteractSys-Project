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
    public bool onActivePage;
    public bool onNewTaskPage;
 

    void Start()
    {
        newTaskPanel.SetActive(false);
        doneScrollView.SetActive(false);
        ActivateAllButton.SetActive(false);
        DoneAllButton.SetActive(false);
        DeleteAllButton.SetActive(false);
        onActivePage = true;
        onNewTaskPage = false;

    }

    public void OpenNewTaskPanel()
    {
        newTaskPanel.SetActive(true);
        searchButton.SetActive(false);
        menuButton.SetActive(false);
        onNewTaskPage = true;
    }

    public void CloseNewTaskPanel()
    {
        newTaskPanel.SetActive(false);
        searchButton.SetActive(true);
        menuButton.SetActive(true);
        onNewTaskPage = false;
    }

    public void GoToActiveList()
    {
        activeListBar.color = selectedColor;
        doneListBar.color = deselectedColor;
        activeScrollView.SetActive(true);
        doneScrollView.SetActive(false);
        onActivePage = true;

    }

    public void GoToDoneList()
    {
        activeListBar.color = deselectedColor;
        doneListBar.color = selectedColor;
        activeScrollView.SetActive(false);
        doneScrollView.SetActive(true);
        onActivePage = false;
    }

    public void ActivateActiveButtons()
    {
        ActivateAllButton.SetActive(false);
        DoneAllButton.SetActive(true);
        DeleteAllButton.SetActive(true);
    }
    public void ActivateDoneButtons()
    {
        ActivateAllButton.SetActive(true);
        DoneAllButton.SetActive(false);
        DeleteAllButton.SetActive(true);
    }

    public void DeactivateAllButtons()
    {
        ActivateAllButton.SetActive(false);
        DoneAllButton.SetActive(false);
        DeleteAllButton.SetActive(false);
    }
}
