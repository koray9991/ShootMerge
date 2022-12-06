using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [HideInInspector] public float timer;
   [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    public LayerMask layerMask;
    public Camera cam;
    public bool hold;

    
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        if (hold)
        {
            for (int i = 0; i < GameManager.instance.bgGreenList.Count; i++)
            {
                if (GameManager.instance.grid[i].transform.childCount != 0)
                {
                    if (GameManager.instance.holdedObjectNumber == 1 && GameManager.instance.grid[i].transform.GetChild(0).tag == "1")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }
                    if (GameManager.instance.holdedObjectNumber == 2 && GameManager.instance.grid[i].transform.GetChild(0).tag == "2")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }
                    if (GameManager.instance.holdedObjectNumber == 4 && GameManager.instance.grid[i].transform.GetChild(0).tag == "4")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }
                    if (GameManager.instance.holdedObjectNumber == 8 && GameManager.instance.grid[i].transform.GetChild(0).tag == "8")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }
                    if (GameManager.instance.holdedObjectNumber == 16 && GameManager.instance.grid[i].transform.GetChild(0).tag == "16")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }
                    if (GameManager.instance.holdedObjectNumber == 32 && GameManager.instance.grid[i].transform.GetChild(0).tag == "32")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }
                    if (GameManager.instance.holdedObjectNumber == 64 && GameManager.instance.grid[i].transform.GetChild(0).tag == "64")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }
                    if (GameManager.instance.holdedObjectNumber == 128 && GameManager.instance.grid[i].transform.GetChild(0).tag == "128")
                    {
                        GameManager.instance.bgGreenList[i].gameObject.SetActive(true);
                    }

                }
               
            }
        }
       
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        GameManager.instance.holdedObjectParent = transform.parent.gameObject;
        var nullObject = Instantiate(GameManager.instance.nullObjectPrefab, transform.position, Quaternion.identity);
        nullObject.transform.parent = GameManager.instance.holdedObjectParent.transform;
        
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        GameManager.instance.holdingObject = true;

        #region holdedObjectTags
        if (transform.tag == "1")
        {
            GameManager.instance.holdedObjectNumber = 1;
        }
        if (transform.tag == "2")
        {
            GameManager.instance.holdedObjectNumber = 2;
        }
        if (transform.tag == "4")
        {
            GameManager.instance.holdedObjectNumber = 4;
        }
        if (transform.tag == "8")
        {
            GameManager.instance.holdedObjectNumber = 8;
        }
        if (transform.tag == "16")
        {
            GameManager.instance.holdedObjectNumber = 16;
        }
        if (transform.tag == "32")
        {
            GameManager.instance.holdedObjectNumber = 32;
        }
        if (transform.tag == "64")
        {
            GameManager.instance.holdedObjectNumber = 64;
        }
        if (transform.tag == "128")
        {
            GameManager.instance.holdedObjectNumber = 128;
        }
        if (transform.tag == "256")
        {
            GameManager.instance.holdedObjectNumber = 256;
        }
        #endregion

        if (GunParent.instance.gunCount == 1)
        {
            GunParent.instance.aura2.SetActive(true);
            GunParent.instance.aura3.SetActive(true);
            GunParent.instance.aura4.SetActive(true);
        }
        else
        {
            GunParent.instance.aura1.SetActive(true);
            GunParent.instance.aura2.SetActive(true);
            GunParent.instance.aura3.SetActive(true);
            GunParent.instance.aura4.SetActive(true);
            GunParent.instance.aura5.SetActive(true);
        }

        hold = true;
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
      
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        hold = false;
        //if (parentAfterDrag.childCount == 0)
        //{
        transform.SetParent(parentAfterDrag);
        //}
        //else
        //{
        //    for (int i = 0; i < GameManager.instance.grid.Count; i++)
        //    {
        //        if (GameManager.instance.grid[i].transform.childCount == 0)
        //        {
        //            transform.SetParent(GameManager.instance.grid[i].transform);

        //        }
        //    }
        //}

        image.raycastTarget = true; 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            
            if(hit.transform.tag=="EmptySlot" && GameManager.instance.holdedObjectNumber == 1)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[0], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);
                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 2)
            {
                
                var newGun = Instantiate(GunParent.instance.GunObjects[1], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 4)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[2], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 8)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[3], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 16)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[4], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 32)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[5], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 64)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[6], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 128)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[7], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }
            if (hit.transform.tag == "EmptySlot" && GameManager.instance.holdedObjectNumber == 256)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[8], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform;
                newGun.transform.localPosition = new Vector3(0, 0, 0);
                newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[2]);

                Destroy(gameObject);
            }



            if (hit.transform.tag == "GunLevel1" && GameManager.instance.holdedObjectNumber==1)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[1], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            if (hit.transform.tag == "GunLevel2" && GameManager.instance.holdedObjectNumber == 2)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[2], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            if (hit.transform.tag == "GunLevel3" && GameManager.instance.holdedObjectNumber == 4)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[3], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            if (hit.transform.tag == "GunLevel4" && GameManager.instance.holdedObjectNumber == 8)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[4], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            if (hit.transform.tag == "GunLevel5" && GameManager.instance.holdedObjectNumber == 16)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[5], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            if (hit.transform.tag == "GunLevel6" && GameManager.instance.holdedObjectNumber == 32)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[6], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            if (hit.transform.tag == "GunLevel7" && GameManager.instance.holdedObjectNumber == 64)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[7], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            if (hit.transform.tag == "GunLevel8" && GameManager.instance.holdedObjectNumber == 128)
            {
                var newGun = Instantiate(GunParent.instance.GunObjects[8], transform.position, Quaternion.identity);
                newGun.transform.parent = hit.transform.parent;
                newGun.transform.position = hit.transform.position;
                newGun.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
        }
        
        GameManager.instance.holdingObject = false;
        GameManager.instance.holdedObjectNumber = 0;
        GunParent.instance.aura1.SetActive(false);
        GunParent.instance.aura2.SetActive(false);
        GunParent.instance.aura3.SetActive(false);
        GunParent.instance.aura4.SetActive(false);
        GunParent.instance.aura5.SetActive(false);

        for (int i = 0; i < GameManager.instance.bgGreenList.Count; i++)
        {

            GameManager.instance.bgGreenList[i].gameObject.SetActive(false);
             
        }

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            timer = 0;
            if ( transform.parent==null)
            {
                Destroy(gameObject);
            }else if (transform.parent.tag == "Finish" || (!GameManager.instance.holdingObject && transform.parent.tag=="Canvas"))
            {
                Destroy(gameObject);
            }

        }
    }

}
