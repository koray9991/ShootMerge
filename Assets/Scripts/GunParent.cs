using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParent : MonoBehaviour
{
    public int gunCount;
    public static GunParent instance;
    public GameObject[] GunObjects;
    [SerializeField] float XSpeed;
    float Vec = 8;

    [SerializeField] float MaxX,minX;
    Vector3 MovementVector;
    public GameObject slot1, slot2, slot3, slot4, slot5;
    public GameObject gun1, gun2, gun3, gun4, gun5;
    public GameObject aura1, aura2, aura3, aura4, aura5;
    
    float gunCheckerTimer;
    public bool canMove;
    public bool fail1Time;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameManager.instance.gameOver && !fail1Time)
        { 
            fail1Time = true;
            if (slot1.transform.childCount != 0)
            {
                Instantiate(GameManager.instance.failExplosion, slot1.transform.position, Quaternion.identity);
                gun1.SetActive(false);
            }
            if (slot2.transform.childCount != 0)
            {
                Instantiate(GameManager.instance.failExplosion, slot2.transform.position, Quaternion.identity);
                gun2.SetActive(false);
            }
            if (slot3.transform.childCount != 0)
            {
                Instantiate(GameManager.instance.failExplosion, slot3.transform.position, Quaternion.identity);
                gun3.SetActive(false);
            }
            if (slot4.transform.childCount != 0)
            {
                Instantiate(GameManager.instance.failExplosion, slot4.transform.position, Quaternion.identity);
                gun4.SetActive(false);
            }
            if (slot5.transform.childCount != 0)
            {
                Instantiate(GameManager.instance.failExplosion, slot5.transform.position, Quaternion.identity);
                gun5.SetActive(false);
            }
          
           
            
            
           
        }
        gunCheckerTimer += Time.deltaTime;
        if (gunCheckerTimer > 0.5f)
        {
            gunCheckerTimer = 0;
            Check();
        }
      
        if (Input.GetMouseButton(0) && !GameManager.instance.holdingObject && canMove) 
        {
            Movement();

        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
    }
    public void Check()
    {
        
            
            if (slot1.transform.childCount != 0)
            {
                gun1 = slot1.transform.GetChild(0).gameObject;
            }
            if (slot2.transform.childCount != 0)
            {
                gun2 = slot2.transform.GetChild(0).gameObject;
            }
            if (slot3.transform.childCount != 0)
            {
                gun3 = slot3.transform.GetChild(0).gameObject;
            }
            if (slot4.transform.childCount != 0)
            {
                gun4 = slot4.transform.GetChild(0).gameObject;
            }
            if (slot5.transform.childCount != 0)
            {
                gun5 = slot5.transform.GetChild(0).gameObject;
            }





            if (gun1 != null && gun2 == null)
            {
                gun1.transform.parent = slot2.transform;
                gun1.transform.localPosition = Vector3.zero;
                gun1.transform.localRotation = Quaternion.Euler(0, 180, 0);
                slot1.GetComponent<BoxCollider>().enabled = true;
                gun2 = gun1;
                gun1 = null;

            }
            if (gun5 != null && gun4 == null)
            {
                gun5.transform.parent = slot4.transform;
                gun5.transform.localPosition = Vector3.zero;
                gun5.transform.localRotation = Quaternion.Euler(0, 180, 0);
                slot5.GetComponent<BoxCollider>().enabled = true;
                gun4 = gun5;
                gun5 = null;

            }



            if (gun1 != null && gun2 != null)
            {
                if (gun1.GetComponent<Gun>().gunLevel == gun2.GetComponent<Gun>().gunLevel)
                {
                    Destroy(slot1.transform.GetChild(0).gameObject);
                    Destroy(slot2.transform.GetChild(0).gameObject);

                    var newGun = Instantiate(GunObjects[gun1.GetComponent<Gun>().gunLevel], transform.position, Quaternion.identity);
                    newGun.transform.parent = slot2.transform;
                    newGun.transform.localPosition = Vector3.zero;
                    newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);



                    slot1.GetComponent<BoxCollider>().enabled = true;
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
            }
            }
            if (gun2 != null && gun3 != null)
            {
                if (gun2.GetComponent<Gun>().gunLevel == gun3.GetComponent<Gun>().gunLevel)
                {
                    Destroy(slot2.transform.GetChild(0).gameObject);
                    Destroy(slot3.transform.GetChild(0).gameObject);

                    var newGun = Instantiate(GunObjects[gun2.GetComponent<Gun>().gunLevel], transform.position, Quaternion.identity);
                    newGun.transform.parent = slot3.transform;
                    newGun.transform.localPosition = Vector3.zero;
                    newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);

                slot2.GetComponent<BoxCollider>().enabled = true;
                return;
                }
            }
            if (gun3 != null && gun4 != null)
            {
                if (gun3.GetComponent<Gun>().gunLevel == gun4.GetComponent<Gun>().gunLevel)
                {
                    Destroy(slot3.transform.GetChild(0).gameObject);
                    Destroy(slot4.transform.GetChild(0).gameObject);

                    var newGun = Instantiate(GunObjects[gun3.GetComponent<Gun>().gunLevel], transform.position, Quaternion.identity);
                    newGun.transform.parent = slot3.transform;
                    newGun.transform.localPosition = Vector3.zero;
                    newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);

                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
                slot4.GetComponent<BoxCollider>().enabled = true;
                return;
            }
            }
            if (gun4 != null && gun5 != null)
            {
                if (gun4.GetComponent<Gun>().gunLevel == gun5.GetComponent<Gun>().gunLevel)
                {
                    Destroy(slot4.transform.GetChild(0).gameObject);
                    Destroy(slot5.transform.GetChild(0).gameObject);
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[1]);
                var newGun = Instantiate(GunObjects[gun4.GetComponent<Gun>().gunLevel], transform.position, Quaternion.identity);
                    newGun.transform.parent = slot4.transform;
                    newGun.transform.localPosition = Vector3.zero;
                    newGun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    slot5.GetComponent<BoxCollider>().enabled = true;
                return;
            }
            }


            gunCount = 0;
            if (gun1 != null)
            {
                gunCount++;
            }
            if (gun2 != null)
            {
                gunCount++;
            }
            if (gun3 != null)
            {
                gunCount++;
            }
            if (gun4 != null)
            {
                gunCount++;
            }
            if (gun5 != null)
            {
                gunCount++;
            }
            if (gunCount == 1)
            {
                MaxX = 2f;
                minX = -2f;
            }
            if (gun4 != null && gun5 == null)
            {
                MaxX = 1.2f;
            }
            if (gun4 != null && gun5 != null)
            {
                MaxX = 0.5f;
            }
            if (gun4 == null && gun5 == null)
            {
                MaxX = 2f;
            }
            if (gun2 != null && gun1 == null)
            {
                minX = -1.2f;
            }
            if (gun1 != null && gun2 != null)
            {
                minX = -0.5f;
            }
            if (gun2 == null && gun1 == null)
            {
                minX = -2f;
            }
        
    }
    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            MovementVector.x = Input.GetAxis("Mouse X") * XSpeed;
        }
        else
        {
            MovementVector.x = 0;
        }
        transform.Translate(Vec * Time.deltaTime * MovementVector);
          transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX, MaxX), transform.position.y, transform.position.z);
       
    }
}
