using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTest : MonoBehaviour
{
    public GameObject harro;
    
    void Start()
    {
        harro.SetActive(false);
    }

    public void showObject()
    {
        harro.SetActive(true);
    }
}
