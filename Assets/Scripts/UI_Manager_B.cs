using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager_B : MonoBehaviour
{
    public GameObject newTaskPanel;
    public GameObject editTaskPanel;
    public GameObject menuButton;
    public GameObject activeScrollView;
    public GameObject doneScrollView;
    public SpriteRenderer activeListBar;
    public SpriteRenderer doneListBar;
    public Color selectedColor;
    public Color deselectedColor;
    public GameObject burgerMenuPanel;
    private bool burgerMenuOpen = false;

    void Start()
    {
        newTaskPanel.SetActive(false);
        doneScrollView.SetActive(false);
        burgerMenuPanel.SetActive(false);
        editTaskPanel.SetActive(false);
    }

    public void OpenNewTaskPanel()
    {
        newTaskPanel.SetActive(true);
        menuButton.SetActive(false);
    }

    public void CloseNewTaskPanel()
    {
        newTaskPanel.SetActive(false);
        menuButton.SetActive(true);
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
    }

    public void GoToDoneList()
    {
        activeListBar.color = deselectedColor;
        doneListBar.color = selectedColor;
        activeScrollView.SetActive(false);
        doneScrollView.SetActive(true);
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
