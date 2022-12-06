using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyParent : MonoBehaviour
{
    public float healths;
    private void Start()
    {
        healths = GameManager.instance.gameTimer;
        if (GameManager.instance.gameTimer < 20)
        {
            healths = 10;
        }
        else
        {
            float more = GameManager.instance.gameTimer % 10;
            healths = GameManager.instance.gameTimer - more;
            healths = healths / 2;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetChild(0).GetComponent<Enemy>().maxHealth = healths*2;
                transform.GetChild(i).GetChild(0).GetComponent<Enemy>().health = healths*2;
                transform.GetChild(i).GetChild(0).GetComponent<Enemy>().healthText.text = (healths*2).ToString();
            }
        }
       
    }
}
