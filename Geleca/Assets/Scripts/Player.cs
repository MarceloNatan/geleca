using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Player : MonoBehaviour {

    //bool jumping = false;

    [SerializeField]
    private GameObject tiro;

    private byte countTiro = 0;

    //private Direcao direcao = Direcao.chao;

    [SerializeField]
    private bool esquerda = false, direita, teto, chao;

    [SerializeField]
    private GameObject morte;

    [SerializeField]
    private bool gameOver;

    int vida = 3;
    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (gameOver)
            return;

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
            //jumping = true;
            if(teto || esquerda || direita)
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Animator>().SetBool("pulando", true);
            }
            else
            {
                GetComponent<Animator>().SetInteger("estado", 2);
            }



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

        if (gameOver)
            return;

        sbyte direcao = 1;
        
        
        //direita
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            direcao = 2;

            if (GetComponent<Animator>().GetBool("pulando"))
                GetComponent<Rigidbody2D>().AddForce(new Vector3(3, 0, 0));
            else
            {


                if (GetComponent<Animator>().GetBool("movendo"))
                {


                    if (((esquerda && !chao) && !teto) || (teto && esquerda))
                    {
                        transform.position -= new Vector3(0, 0.05f, 0);
                    }
                    else if (direita && teto)
                    {
                        transform.position -= new Vector3(0.05f, 0, 0);
                    }

                    else if (direita || (direita && chao))
                    {
                        transform.position += new Vector3(0, 0.05f, 0);
                    }

                    else if (teto)
                    {
                        transform.position -= new Vector3(0.05f, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(0.05f, 0, 0);
                    }
                }

            }

            
        }//esquerda
        else if(Input.GetAxis("Horizontal")< -0.01f)
        {
            direcao = -1;
            if (GetComponent<Animator>().GetBool("pulando"))
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-3, 0, 0));
            else
            {


                //if ((esquerda ^= chao) || (direita ^= chao))
                //{
                //    transform.position += new Vector3(0, 0.05f, 0);
                //}
                //else
                //{

                //    transform.position -= new Vector3(0.05f, 0, 0);
                //}
                if (GetComponent<Animator>().GetBool("movendo"))
                {
                    if (((esquerda && chao) || (esquerda && !chao)) && !teto)
                    {
                        transform.position += new Vector3(0, 0.05f, 0);
                    }
                    else if (direita && chao)
                    {
                        transform.position -= new Vector3(0.05f, 0, 0);
                    }
                    else if (direita || (teto && direita))
                    {
                        transform.position -= new Vector3(0, 0.05f, 0);
                    }
                    else if (teto)
                    {
                        transform.position += new Vector3(0.05f, 0, 0);
                    }
                    else
                    {
                        transform.position -= new Vector3(0.05f, 0, 0);
                    }
                }



            }


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

        //Debug.Log("enter: "  + collision.gameObject.tag);

        

        switch (collision.gameObject.tag)
        {
            case "Terrain":
                {
                    GetComponent<Animator>().SetBool("pulando", false);
                    //direcao = Direcao.chao;
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                    chao = true;

                }
                break;

            case "ParedeEsquerda":
                {

                    //GetComponent<SpriteRenderer>().flipX = true;

                    //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);


                    transform.position = new Vector3(-8.877296f, transform.position.y);
                    

                    transform.rotation = Quaternion.Euler(0, 0, -90);

                    GetComponent<Rigidbody2D>().gravityScale = 0;

                    //direcao = Direcao.esquerda;

                    esquerda = true;
                    //Debug.Log("Esquerda:" + esquerda);
                }
                break;
            case "ParedeDireita":
                {
                    //direcao = Direcao.direita;
                    //transform.position = new Vector3(8.877299f, transform.position.y);
                    transform.rotation = Quaternion.Euler(0, 0, 90);

                    GetComponent<Rigidbody2D>().gravityScale = 0;
                    direita = true;
                }
                break;
            case "Teto":
                {
                    teto = true;
                   

                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    
                }
                break;

            case "BloqueioInimigo":
            case "DanoInimigo":
                {
                    vida -= 1;
                    if (gameOver)
                        return;
                    if (vida < 1)
                    {
                        Debug.Log("Morreu");
                        GameObject m = Instantiate(morte);
                        m.transform.position = transform.position;
                        m.transform.rotation = transform.rotation;

                        //Destroy(this.gameObject);
                        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    }
                    gameOver = true;
                }
                break;

        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("exit: " + collision.gameObject.tag);
        switch (collision.gameObject.tag)
        {
            case "ParedeEsquerda":
                {
                    esquerda = false;

                    if (!teto)
                        GetComponent<Rigidbody2D>().gravityScale = 1;

                    //transform.rotation = Quaternion.Euler(0, 0, 0);
                    //transform.position += new Vector3(1, 0, 0);
                }
                break;
            case "Terrain":
                {
                    chao = false;
                    //Debug.Log("Chao false");
                }
                break;
            case "Teto":
                {
                    teto = false;

                    //if(direita)
                    //{
                    //    transform.rotation = Quaternion.Euler(0, 0, 90);
                    //    GetComponent<Rigidbody2D>().gravityScale = 0;
                    //}
                    //else if(esquerda)
                    //{
                    //    transform.rotation = Quaternion.Euler(0, 0, -90);
                    //    GetComponent<Rigidbody2D>().gravityScale = 0;
                    //}
                }
                break;
            case "ParedeDireita":
                {
                    direita = false;

                    if (!teto)
                        GetComponent<Rigidbody2D>().gravityScale = 1;
                }                
                break;
            case "ProjetilInimigo":
                {
                    if (gameOver)
                        return;

                    GameObject m = Instantiate(morte);
                    m.transform.position = transform.position;
                    m.transform.rotation = transform.rotation;

                    //Destroy(this.gameObject);
                    GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    Destroy(collision.gameObject, 0);

                    gameOver = true;
                }
                break;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    //Debug.Log("teste");
    //    switch (collision.tag)
    //    {
    //        case "ParedeEsquerda":
    //            {

    //            }
    //            break;
    //        case "Terrain":
    //            {
    //                chao = true;
    //            }
    //            break;
    //    }
    //}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ProjetilInimigo")
        {
            //Destroy(collision.gameObject,0);
        }else if(collision.tag == "Terrain")
        {
            //Debug.Log("Colisao com o terreno");
            transform.rotation = new Quaternion();
            GetComponent<Animator>().SetBool("pulando", false);
            GetComponent<Animator>().SetInteger("estado", 0);
            chao = true;
        }
        //else if (collision.tag == "ParedeEsquerda")
        //{
        //    esquerda = true;
        //    Debug.Log("Enter Esquerda: " + esquerda);
        //}
        //else if (collision.tag == "ParedeEsquerda")
        //{
        //    chao = true;
        //}
    }

    public enum Direcao
    {
        direita, esquerda, teto, chao
    }

}
