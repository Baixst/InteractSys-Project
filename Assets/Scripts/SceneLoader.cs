using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneA()
    {
        SceneManager.LoadScene("Version A (Checkboxes)");
    }

    public void LoadSceneB()
    {
        SceneManager.LoadScene("Version B (Swipe)");
    } 
}
