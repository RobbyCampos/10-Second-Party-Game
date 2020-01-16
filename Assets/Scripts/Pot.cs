using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{

    public float speed = 10.0f;
    private Rigidbody2D rb;
   

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }
}
