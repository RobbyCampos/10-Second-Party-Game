using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployer : MonoBehaviour
{

    public GameObject potPrefab;
    public float respawnTime = 1;

    private bool startCheck;

    private GameObject sword;
    private Sword swordScript;
    private int countCheck;

    private GameObject timer;
    private Timer timerScript;

    private GameObject hud;
    private HUD hudScript;


    void Start()
    {
        sword = GameObject.Find("Sword 1");
        swordScript = sword.GetComponent<Sword>();

        timer = GameObject.Find("TimeText");
        timerScript = timer.GetComponent<Timer>();

        hud = GameObject.Find("GameManager");
        hudScript = hud.GetComponent<HUD>();

        startCheck = false;

        //StartCoroutine("potWave");
    }

    private void Update()
    {
        countCheck = swordScript.count;
        //Debug.Log(countCheck);

        if (hudScript.started == true && startCheck == false)
        {
            StartCoroutine("potWave");
            startCheck = true;
        }

    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(potPrefab) as GameObject;
        a.transform.position = new Vector2(10, Random.Range(-2, 2));
    }

    IEnumerator potWave()
    {
        while(true)
         {
            if (countCheck == 5 || timerScript.timeleft <= 0)
            {
                GameObject[] boardWipe = GameObject.FindGameObjectsWithTag("Pot");
                for (int i = 0; i < boardWipe.Length; i++)
                {
                    Destroy(boardWipe[i]);
                }
                yield break;
            }
            else
            {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            }
         }
 
    }

}
