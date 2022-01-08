using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform draggingObjectRectTransform;

    private bool firstDrag = true;
    private float startX;
    private float startY;
    private float startZ;
    private Vector3 mousePositionStart;
    private bool recordMousePositionStart = true;
    private TaskManagerB taskManager;
    private bool allowDragEnd;

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
        taskManager = FindObjectOfType<TaskManagerB>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position,
            eventData.pressEventCamera, out var globalMousePosition))
        {
            if(recordMousePositionStart)
            {
                mousePositionStart = globalMousePosition;
                recordMousePositionStart = false;
                Debug.Log("mouse position start:" + globalMousePosition);
            }

            // object gets basicly parented to mouse, which makes it jump
            // subtract the mousePosition on drag start to avoid that jump
            var tempGlobalMousePosition= globalMousePosition;
            var tempMousePostionStart = mousePositionStart;
            tempGlobalMousePosition.y = startY;
            tempGlobalMousePosition.z = startZ;
            tempGlobalMousePosition.x -= tempMousePostionStart.x;
            
            draggingObjectRectTransform.transform.position = tempGlobalMousePosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (firstDrag) 
        {
            startX = transform.position.x;
            firstDrag = false;
        }
        startY = transform.position.y;
        startZ = transform.position.z;

        allowDragEnd = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!allowDragEnd)  return;

        // Delete Object or move it back
        Debug.Log("x position on drag end: " + draggingObjectRectTransform.position.x);
        if (draggingObjectRectTransform.position.x < -2.18f)
        {
            StartCoroutine(MoveOverSecondsAndDelete(gameObject, new Vector3 (-5.65f, startY, startZ), 0.25f));
        }
        else if (draggingObjectRectTransform.position.x > 2.5f)
        {
            StartCoroutine(MoveOverSecondsAndToggle(gameObject, new Vector3 (5.75f, startY, startZ), 0.25f));
        }
        else
        {
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3 (startX, startY, startZ), 0.25f));
        }
        recordMousePositionStart = true;
        allowDragEnd = false;
    }

    public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 endPosition, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, endPosition, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = endPosition;
    }

    public IEnumerator MoveOverSecondsAndDelete (GameObject objectToMove, Vector3 endPosition, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, endPosition, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = endPosition;
        yield return new WaitForSeconds(0.5f);

        // TO-DO: Fade and wait a bit
        if (gameObject.GetComponent<FadeObject_B>() != null)
        {
            gameObject.GetComponent<FadeObject_B>().fadeOut = true;
            yield return new WaitForSeconds(0.5f);
        }

        Destroy(gameObject);
    }

    public IEnumerator MoveOverSecondsAndToggle (GameObject objectToMove, Vector3 endPosition, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, endPosition, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = endPosition;
        
        objectToMove.GetComponent<Task_B>().isActive = !objectToMove.GetComponent<Task_B>().isActive;
    }
}
