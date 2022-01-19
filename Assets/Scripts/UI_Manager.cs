using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject newTaskPanel;
    public GameObject editTaskPanel;
    public GameObject menuButton;
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
    public TaskManager taskManager;
    public GameObject burgerMenuPanel;
    private bool burgerMenuOpen = false;

    void Start()
    {
        newTaskPanel.SetActive(false);
        doneScrollView.SetActive(false);
        ActivateAllButton.SetActive(false);
        DoneAllButton.SetActive(false);
        DeleteAllButton.SetActive(false);
        onActivePage = true;
        onNewTaskPage = false;
        burgerMenuPanel.SetActive(false);
        editTaskPanel.SetActive(false);
    }

    public void OpenNewTaskPanel()
    {
        newTaskPanel.SetActive(true);
        menuButton.SetActive(false);
        onNewTaskPage = true;
    }

    public void CloseNewTaskPanel()
    {
        newTaskPanel.SetActive(false);
        menuButton.SetActive(true);
        onNewTaskPage = false;
    }

    public void OpenEditTaskPanel()
    {
        editTaskPanel.SetActive(true);
        menuButton.SetActive(false);
    }

    public void CloseEditTaskPanel()
    {
        editTaskPanel.SetActive(false);
        menuButton.SetActive(true);
    }

    public void GoToActiveList()
    {
        activeListBar.color = selectedColor;
        doneListBar.color = deselectedColor;
        activeScrollView.SetActive(true);
        doneScrollView.SetActive(false);
        onActivePage = true;
        taskManager.allowTask_8_completion = false;
    }

    public void GoToDoneList()
    {
        activeListBar.color = deselectedColor;
        doneListBar.color = selectedColor;
        activeScrollView.SetActive(false);
        doneScrollView.SetActive(true);
        onActivePage = false;
        taskManager.allowTask_8_completion = true;
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

    public void ToggleBurgerMenu()
    {
        if (burgerMenuOpen)
        {
            CloseBurgerMenu();
        }
        else
        {
            OpenBurgerMenu();
        }
    }

    public void OpenBurgerMenu()
    {
        burgerMenuPanel.SetActive(true);
        burgerMenuOpen = true;
    }

    public void CloseBurgerMenu()
    {
        burgerMenuPanel.SetActive(false);
        burgerMenuOpen = false;
    }
}
