using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{

    private Animator animator;
    private GameObject sword;
    private Sword swordScript;
    private int countCheck;

    void Start()
    {
        sword = GameObject.Find("Sword 1");
        swordScript = sword.GetComponent<Sword>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        countCheck = swordScript.count;

        if (Input.GetButtonDown("Fire1") && countCheck < 5)
        {
            Chop();
        }

    }

    public void Chop()
    {
        animator.SetTrigger("Chop");
    }


}
