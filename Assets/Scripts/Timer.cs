using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{

    public int timeleft = 10;
    public Text countdown;
    public bool timerStart;

    private GameObject sword;
    private Sword swordScript;
    private int countCheck;

    private GameObject hud;
    private HUD hudScript;

    void Start()
    {
        timerStart = false;
        Time.timeScale = 1;

        sword = GameObject.Find("Sword 1");
        swordScript = sword.GetComponent<Sword>();

        hud = GameObject.Find("GameManager");
        hudScript = hud.GetComponent<HUD>();

    }


    void Update()
    {
        countCheck = swordScript.count;
        //Debug.Log(countCheck);

        if (hudScript.started == true && timerStart == false)
        {
            StartCoroutine("LoseTime");
            timerStart = true;
        }

        if (hudScript.started == true)
            if (timeleft >= 0 && countCheck != 5)
            {
                countdown.text = ("" + timeleft);
            }

    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeleft--;
        }
    }
}
