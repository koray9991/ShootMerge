using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    
    public float maxHealth;
    public float health;
    public TextMeshProUGUI healthText;
    public ParticleSystem psBlode;
   public float maxHeight;
    float oran;
    public bool MainBool;
    public bool getBigger;
    public float timer;
    public float currentX, currentY, currentZ;
    public float scaleIndex;
    public bool dontSmaller;
    public GameObject moneyObject;
    private void Start()
    {
        health = maxHealth;
        healthText.text = health.ToString();
        if (transform.tag == "CoinEnemy")
        {
            maxHeight = transform.localScale.z;
            
        }
        if (transform.tag == "DollarEnemy")
        {
            maxHeight = transform.localScale.y;

        }
    }
    void FixedUpdate()
    {
        
        if (MainBool)
        {
            if (transform.tag == "DollarEnemy")
            {
                getBigger = true;
                timer += Time.deltaTime;
                if (timer > 0.05f)
                {
                    getBigger = false;
                }
                if (timer > 0.1f)
                {
                    MainBool = false;
                    timer = 0;

                }
                if (getBigger == true)
                {
                    transform.localScale = new Vector3(transform.transform.localScale.x + scaleIndex, transform.localScale.y, transform.transform.localScale.z + scaleIndex);
                }
                else
                {
                    transform.localScale = new Vector3(transform.transform.localScale.x - scaleIndex, transform.localScale.y, transform.transform.localScale.z - scaleIndex);
                }
            }
            if(transform.tag == "CoinEnemy")
            {
                getBigger = true;
                timer += Time.deltaTime;
                if (timer > 0.05f)
                {
                    getBigger = false;
                }
                if (timer > 0.1f)
                {
                    MainBool = false;
                    timer = 0;

                }
                if (getBigger == true)
                {
                    transform.localScale = new Vector3(transform.transform.localScale.x + scaleIndex, transform.transform.localScale.y + scaleIndex, transform.transform.localScale.z );
                }
                else
                {
                    transform.localScale = new Vector3(transform.transform.localScale.x - scaleIndex, transform.transform.localScale.y - scaleIndex, transform.transform.localScale.z );
                }
            }
           
        }
        else
        {
            if (transform.localScale.x != currentX)
            {
                if (transform.tag == "DollarEnemy")
                {
                    transform.localScale = new Vector3(currentX, transform.localScale.y, currentZ);
                }
                if (transform.tag == "CoinEnemy")
                {
                    transform.localScale = new Vector3(currentX, currentY, transform.localScale.z);
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            MainBool = true;
            Instantiate(moneyObject, other.transform.position, Quaternion.identity);
            health -= other.GetComponent<Bullet>().damage;
            GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.voices[0]);
            healthText.text = health.ToString();
            GameManager.instance.score += other.GetComponent<Bullet>().damage;
            GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
            Destroy(other.gameObject);
            psBlode.Play();
            if (transform.tag == "CoinEnemy" && !dontSmaller)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, (health / maxHealth) * maxHeight);
            }
            if (transform.tag == "DollarEnemy" && !dontSmaller)
            {
                transform.localScale = new Vector3(transform.localScale.x, (health / maxHealth) * maxHeight, transform.localScale.z);
            }

            if (health <= 0)
            {
                Destroyed();
            }
        }
        if (other.tag == "Finish")
        {
            Time.timeScale = 0;
            GameManager.instance.gameOver = true;
        }
    }
    void Destroyed()
    {
        Destroy(gameObject.transform.parent.gameObject, 1f);
        Destroy(gameObject);
       

    }
}
