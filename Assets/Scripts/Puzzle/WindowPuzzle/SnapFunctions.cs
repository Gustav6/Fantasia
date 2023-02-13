using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapFunctions : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragDropFunctions draggableItem = dropped.GetComponent<DragDropFunctions>();
        draggableItem.parentAfterDrag = transform;
    }
}
