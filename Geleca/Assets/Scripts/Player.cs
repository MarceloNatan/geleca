using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Player : MonoBehaviour {

    bool jumping = false;

    [SerializeField]
    private GameObject tiro;

    private byte countTiro = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        sbyte direcao = 1;

        //GetComponent<Animator>().SetInteger("status", 0);
        GetComponent<Animator>().SetInteger("status", 0);

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            direcao = 2;
            
            if(jumping)
                GetComponent<Rigidbody2D>().AddForce(new Vector3(3, 0, 0));
            else
                transform.position += new Vector3(0.05f, 0, 0);

            if (!jumping)
            {
                GetComponent<Animator>().SetInteger("status", 1);
            }
        }
        else if(Input.GetAxis("Horizontal")< -0.01f)
        {
            direcao = -1;
            if (jumping)
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-3, 0, 0));
            else
                transform.position -= new Vector3(0.05f, 0, 0);

            if (!jumping)
            {
                GetComponent<Animator>().SetInteger("status", 1);
            }
        }

        if(Input.GetAxis("Jump") != 0 && !jumping)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0,500,0));
            jumping = true;
        }

        if(Input.GetAxis("Fire1")>0 && countTiro == 0)
        {
            GameObject t = Instantiate(tiro, transform.position, new Quaternion());
            GetComponent<Animator>().SetInteger("status", 2);

            t.GetComponent<Tiro>().direcao = direcao;

            Destroy(t, 1f);

            countTiro++;
        }

        if(countTiro != 0)
        {
            countTiro = (byte)((countTiro+1) % 10);    
        }


        

        //Debug.Log(Input.GetAxis("Jump"));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            jumping = false;
        }

        Debug.Log(collision.gameObject.tag);
    }



}
