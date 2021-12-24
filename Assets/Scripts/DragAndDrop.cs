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

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position,
            eventData.pressEventCamera, out var globalMousePosition))
        {
            var tempTransform = globalMousePosition;
            tempTransform.y = startY;
            tempTransform.z = startZ;
            
            if (tempTransform.x > startX)
            {
                tempTransform.x = startX;
            }
            draggingObjectRectTransform.transform.position = tempTransform;
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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Delete Object or move it back
        Debug.Log("x position on drag end: " + draggingObjectRectTransform.position.x);
        if (draggingObjectRectTransform.position.x < -2.18f)
        {
            StartCoroutine(MoveOverSecondsAndDelete(gameObject, new Vector3 (-5.35f, startY, startZ), 0.2f));
        }
        else
        {
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3 (startX, startY, startZ), 0.2f));
        }
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
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
