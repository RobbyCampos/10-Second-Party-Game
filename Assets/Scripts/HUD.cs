using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class HUD : MonoBehaviour
{
    public Text winText;
    public Text loseText;
    public Text startText;
    public RectTransform mPanelGameOver;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip shwing;
    public AudioSource player;
    public bool started;

    private GameObject sword;
    private Sword swordScript;
    private int countCheck;
    private bool played;

    private GameObject timer;
    private Timer timerScript;


    void Start()
    {
        StartCoroutine(GameStart());

        player = GetComponent<AudioSource>();
        played = false;

        winText.text = "";
        loseText.text = "";

        sword = GameObject.Find("Sword 1");
        swordScript = sword.GetComponent<Sword>();

        timer = GameObject.Find("TimeText");
        timerScript = timer.GetComponent<Timer>();
    }

    
    void Update()
    {

        if(swordScript.count != 5 && timerScript.timeleft <= 0)
        {
            sword.gameObject.SetActive(false);
            mPanelGameOver.gameObject.SetActive(true);
            player.clip = lose;
            player.Play();
            loseText.text = "FAILURE";
            if (played == false)
            {
                ///bug.Log(played);
                player.PlayOneShot(lose);
                played = true;
            }
        }

        if(swordScript.count == 5)
        {

            sword.gameObject.SetActive(false);
            mPanelGameOver.gameObject.SetActive(true);
            winText.text = "SUCCESS";
            if(played == false)
            {
               ///Debug.Log(played);
                player.PlayOneShot(win);
                played = true;
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    IEnumerator GameStart()
    {
        //Debug.Log("Enumerator ACTIVE");
        player.PlayOneShot(shwing);
        mPanelGameOver.gameObject.SetActive(true);
        startText.text = "USE LEFT MOUSE BUTTON TO SWING YOUR SWORD\n BREAK FIVE POTS";
        yield return new WaitForSeconds(3);
        mPanelGameOver.gameObject.SetActive(false);
        startText.text = "";
        started = true;

    }

}


