using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager_B : MonoBehaviour
{
    public GameObject newTaskPanel;
    public GameObject menuButton;
    public GameObject searchButton;
    public GameObject activeScrollView;
    public GameObject doneScrollView;
    public SpriteRenderer activeListBar;
    public SpriteRenderer doneListBar;
    public Color selectedColor;
    public Color deselectedColor;

    void Start()
    {
        newTaskPanel.SetActive(false);
        doneScrollView.SetActive(false);
    }

    public void OpenNewTaskPanel()
    {
        newTaskPanel.SetActive(true);
        searchButton.SetActive(false);
        menuButton.SetActive(false);
    }

    public void CloseNewTaskPanel()
    {
        newTaskPanel.SetActive(false);
        searchButton.SetActive(true);
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
}
