using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Player : MonoBehaviour {

    //bool jumping = false;

    [SerializeField]
    private GameObject tiro;

    private byte countTiro = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (GetComponent<Animator>().GetInteger("estado") == 0)
        //{
        //    jumping = false;
        //}
        //GetComponent<Animator>().SetInteger("status", 0);
        //GetComponent<Animator>().SetInteger("estado", 0);

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;       

            if (!GetComponent<Animator>().GetBool("pulando"))
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
            else
            {
                GetComponent<Animator>().SetInteger("estado", 315);
            }
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {

            

            if (!GetComponent<Animator>().GetBool("pulando"))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetInteger("estado", 1);
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetInteger("estado", 45);
            }
        }
        else if (!GetComponent<Animator>().GetBool("pulando") && Input.GetAxis("Horizontal") > -0.01f && Input.GetAxis("Horizontal") < 0.01f)
        {
            GetComponent<Animator>().SetInteger("estado", 0);
            //GetComponent<SpriteRenderer>().flipX = false;
        }



        if (Input.GetAxis("Fire1") != 0 && !GetComponent<Animator>().GetBool("pulando"))
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 500, 0));
            GetComponent<Animator>().SetInteger("estado", 2);
            //jumping = true;

            

            
        }

        /*if(jumping)
        {
            if(GetComponent<Animator>().GetBool("pulando"))
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(0, 2.723536f);
                GetComponent<BoxCollider2D>().size = new Vector2(3.15f, 7.396748f);
            }
        }*/

    }

    private void FixedUpdate()
    {

        sbyte direcao = 1;
        
        

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            direcao = 2;
            
            if(GetComponent<Animator>().GetBool("pulando"))
                GetComponent<Rigidbody2D>().AddForce(new Vector3(3, 0, 0));
            else
                transform.position += new Vector3(0.05f, 0, 0);

            
        }
        else if(Input.GetAxis("Horizontal")< -0.01f)
        {
            direcao = -1;
            if (GetComponent<Animator>().GetBool("pulando"))
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-3, 0, 0));
            else
                transform.position -= new Vector3(0.05f, 0, 0);

            
        }

        

        if(Input.GetAxis("Fire2")>0 && countTiro == 0)
        {
            GameObject t = Instantiate(tiro, transform.position, new Quaternion()) as GameObject;
            //GetComponent<Animator>().SetInteger("estado", 2);

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
            GetComponent<Animator>().SetBool("pulando", false);
            /*GetComponent<BoxCollider2D>().offset = new Vector2(0, 1.887504f);
            GetComponent<BoxCollider2D>().size = new Vector2(3.15f, 3.529676f);*/
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ProjetilInimigo")
        {
            Destroy(collision.gameObject,0);
        }else if(collision.tag == "Terrain")
        {
            //Debug.Log("Colisao com o terreno");
            transform.rotation = new Quaternion();
            GetComponent<Animator>().SetBool("pulando", false);
            GetComponent<Animator>().SetInteger("estado", 0);
            
        }
    }


}
