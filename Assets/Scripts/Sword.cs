using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    
    public GameObject broken;
    public Text countText;
    public bool gameOn;
    public int count;

    private GameObject sword;

    private GameObject hud;
    private HUD hudScript;


    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("GameManager");
        hudScript = hud.GetComponent<HUD>();

        sword = GameObject.Find("Sword 1");
        this.gameObject.GetComponent<Renderer>().enabled = false;


        gameOn = false;
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if(hudScript.started == true && gameOn == false)
        {
            //Debug.Log("poop");
            this.gameObject.GetComponent<Renderer>().enabled = true;
            gameOn = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag == "Pot" && gameOn == true)
        {
            count++;
            SetCountText();
            GameObject b = Instantiate(broken) as GameObject;
            b.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(b, .5f);

            if(count == 5)
            {
                gameOn = false;
            }

        }
    }

    void SetCountText()
    {
        countText.text = "Pots: " + count.ToString();
    }

}
