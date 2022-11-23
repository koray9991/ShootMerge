using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool holdingObject;
    public int holdedObjectNumber;
    public GameObject[] objects;
    public List<GameObject> grid;
    float timer;
    public float spawnTimer;
    public Transform enemySpawnPoint;
     float enemyTimer;
    public float maxEnemyTimer;
    public GameObject[] enemy;
    int enemyRandomInt;
    public LayerMask layerMask;
    public Camera cam;
    public GameObject holdedObjectParent;
    public bool gameOver;
    float gameOverTimer;
    public GameObject gameOverPanel;
    public int gridObjectCount;
    float checkTimer;
    public GameObject nullObjectPrefab;
    float healtTimer;
    public float score;
    public TextMeshProUGUI scoreText;
    public float gameTimer;
    bool bossBool;
    public GameObject boss;
    public Transform bossSpawnPoint;
    public GameObject bossText;
    public bool winBool;
    public GameObject winPanel;
    public GameObject confetti;
    public GameObject bossEffect;
    public Image timeBar;
    public AudioClip[] voices;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    private void Start()
    {
        Time.timeScale = 1;
        GameObject gridObject = GameObject.FindGameObjectWithTag("Grid");
        for (int i = 0; i < gridObject.transform.childCount; i++)
        {
            grid.Add(gridObject.transform.GetChild(i).gameObject);
        }
        enemyTimer = 0;
        enemyRandomInt = Random.Range(0, enemy.Length);
        var newEnemy = Instantiate(enemy[enemyRandomInt], enemySpawnPoint.position , Quaternion.identity);
        
    }
  
    private void Update()
    {
        gameTimer += Time.deltaTime;
        timeBar.fillAmount = gameTimer / 100;
        if (gameTimer > 100 && !bossBool)
        {
            timeBar.gameObject.SetActive(false);
            bossText.SetActive(true);
            bossEffect.SetActive(true);
            maxEnemyTimer = 9999;
            if (!bossBool)
            {
                Instantiate(boss, bossSpawnPoint.position, Quaternion.identity);
            }
            bossBool = true;
            

        }
        if (gameTimer > 103)
        {
            bossText.SetActive(false);
            bossEffect.SetActive(false);
        }

        if (winBool && Time.timeScale!=0)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            confetti.SetActive(true);

        }


        healtTimer += Time.deltaTime;
        
        if (Input.GetMouseButtonUp(0))
        {
            holdingObject = false;
            if (holdedObjectParent != null)
            {
                Destroy(holdedObjectParent.transform.GetChild(0).gameObject);
            }
            holdedObjectParent = null;
            
        }
        if (gameOver)
        {
            gameOverTimer += Time.fixedDeltaTime/2;
            if (gameOverTimer > 1)
            {
                gameOverPanel.SetActive(true);
            }
        }
       
        timer += Time.deltaTime;
        checkTimer += Time.deltaTime;
        if (checkTimer > 0.2f)
        {
            checkTimer = 0;
            gridObjectCount = 0;
            for (int i = 0; i < grid.Count; i++)
            {
                if (grid[i].transform.childCount != 0)
                {
                    gridObjectCount++;
                }
            }
        }


        if (timer > spawnTimer && (gridObjectCount<10))
        {
            var spawnObject = Instantiate(objects[0], transform.position, Quaternion.identity);
            for (int i = 0; i < grid.Count; i++)
            {
                if(grid[i].transform.childCount == 0)
                {
                    spawnObject.transform.parent = grid[i].transform;
                    spawnObject.transform.localScale = new Vector3(2, 2, 2);
                    break;
                }
            }
            timer = 0;
        }
        enemyTimer += Time.deltaTime;
        if (enemyTimer > maxEnemyTimer)
        {
            enemyTimer = 0;
            enemyRandomInt = Random.Range(0, enemy.Length);
          var newEnemy=  Instantiate(enemy[enemyRandomInt], enemySpawnPoint.position,Quaternion.identity);
           
          
        }
    }
    public void Buttons(int buttonNo)
    {
        if (buttonNo == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (buttonNo == 2)
        {
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }
}
