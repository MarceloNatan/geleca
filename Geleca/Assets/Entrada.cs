using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada : MonoBehaviour
{
    bool pulando;
    Rigidbody2D rb;
    Collision2D col;
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        pulando = false;
     

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > .01f)
        {
            transform.position += new Vector3(.1f, 0, 0);
            
        }

        if (Input.GetAxis("Horizontal") < -.01f)
        {
            transform.position -= new Vector3(.1f, 0, 0);
           
        }
        //Debug.Log(pulando);
        if (Input.GetKeyDown(KeyCode.Space) && !pulando)
        {
            rb.AddForce(new Vector2(0, 100 * 5));
            pulando = true;
     
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            pulando = false;
        }
    }
}
