using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;

    void Awake()
    {
        //DragController controller = FindObjectsOfType<DragController>();
    }

    void Update()
    {
        //if (controller.dragingSomething)
        //{
        //    Vector3 mousePos = Input.mousePoition;
        //}
        
    }

    private void InitDrag()
    {

    }

    private void Drag()
    {

    }

    private void Drop()
    {

    }
}
