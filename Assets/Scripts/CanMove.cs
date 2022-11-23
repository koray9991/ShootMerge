using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CanMove : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GunParent.instance.canMove = true;
    }

   
   
}