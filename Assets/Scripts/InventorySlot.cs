using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    int number;
    IEnumerator Merge()
    {
        yield return new WaitForSeconds(0.001f);
        if (number == 2)
        {
            var merged = Instantiate(GameManager.instance.objects[1], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        if (number == 3)
        {
            var merged = Instantiate(GameManager.instance.objects[2], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        if (number == 4)
        {
            var merged = Instantiate(GameManager.instance.objects[3], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        if (number == 5)
        {
            var merged = Instantiate(GameManager.instance.objects[4], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        if (number == 6)
        {
            var merged = Instantiate(GameManager.instance.objects[5], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        if (number == 7)
        {
            var merged = Instantiate(GameManager.instance.objects[6], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        if (number == 8)
        {
            var merged = Instantiate(GameManager.instance.objects[7], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        if (number == 9)
        {
            var merged = Instantiate(GameManager.instance.objects[8], transform.position, Quaternion.identity);
            merged.transform.parent = transform;
            merged.transform.localScale = new Vector3(1.3f, 1.8f, 1f);
        }
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        Destroy(transform.GetChild(1).gameObject);
        Destroy(transform.GetChild(0).gameObject);
        number = 0;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0)
        {
            if (GameManager.instance.holdedObjectNumber == 1 && transform.GetChild(0).tag == "1")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 2;
                StartCoroutine(Merge());
               


            }
            else if (GameManager.instance.holdedObjectNumber == 2 && transform.GetChild(0).tag == "2")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 3;
                StartCoroutine(Merge());
               
            }
            else if (GameManager.instance.holdedObjectNumber == 4 && transform.GetChild(0).tag == "4")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 4;
                StartCoroutine(Merge());
                
            }
            else if (GameManager.instance.holdedObjectNumber == 8 && transform.GetChild(0).tag == "8")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 5;
                StartCoroutine(Merge());
             
            }
            else if (GameManager.instance.holdedObjectNumber == 16 && transform.GetChild(0).tag == "16")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 6;
                StartCoroutine(Merge());

            }
            else if (GameManager.instance.holdedObjectNumber == 32 && transform.GetChild(0).tag == "32")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 7;
                StartCoroutine(Merge());

            }
            else if (GameManager.instance.holdedObjectNumber == 64 && transform.GetChild(0).tag == "64")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 8;
                StartCoroutine(Merge());

            }
            else if (GameManager.instance.holdedObjectNumber == 128 && transform.GetChild(0).tag == "128")
            {
                GameObject dropped = eventData.pointerDrag;
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                number = 9;
                StartCoroutine(Merge());

            }

        }
        else
        {

            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

        }






    }

}
