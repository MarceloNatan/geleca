using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Player : MonoBehaviour
{

    #region VARIAVEIS
    bool jumping = false;
    bool canto;
    [SerializeField]
    private GameObject tiro;

    bool colideComTerreno;
    bool colideParedeEsquerda;
    bool colideParedeDireita;
    bool colideTeto;

    private byte countTiro = 0;
    #endregion

    #region START()
    void Start()
    {
        // canto = false;
        colideComTerreno = false;
        colideParedeEsquerda = false;
        colideTeto = false;
    }
    #endregion

    #region UPDATE()
    void Update()
    {



        GetComponent<Animator>().SetInteger("estado", 0);

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

            if (!jumping)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }

        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {

            GetComponent<SpriteRenderer>().flipX = true;

            if (!jumping)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
        }

        if (Input.GetAxis("Vertical") > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

            if (!jumping)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }

        }
        else if (Input.GetAxis("Vertical") < -0.01f)
        {

            GetComponent<SpriteRenderer>().flipX = true;

            if (!jumping)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
        }




    }
    #endregion

    #region FIXEDUPDATE()
    private void FixedUpdate()
    {

        sbyte direcao = 1;


        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            direcao = 2;

            if (jumping)
                GetComponent<Rigidbody2D>().AddForce(new Vector3(3, 0, 0));
            else
                transform.position += new Vector3(0.05f, 0, 0);


        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            direcao = -1;
            if (jumping)
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-3, 0, 0));
            else
                transform.position -= new Vector3(0.05f, 0, 0);


        }

        //-----------------------------------HOOOOOO------------------------------
        if (colideParedeEsquerda)
        {
            transform.position += new Vector3(-.05f, 0, 0);
            girarMenos90();
            if (Input.GetAxis("Vertical") > 0.01f)
            {

                transform.position += new Vector3(0, .05f, 0);


                direcao = -1;
                //if (jumping && noMuro)
                //    GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 0, 0));


            }
            if (Input.GetAxis("Vertical") < -0.01f)
            {


                transform.position -= new Vector3(0, .05f, 0);
                direcao = -1;
                Debug.Log("Baixo");
            }

        }


        if (colideParedeDireita)
        {
            transform.position += new Vector3(.05f, 0, 0);
            Debug.Log("PAREDE DIREITA");
            girar90();
            if (Input.GetAxis("Vertical") > 0.01f)
            {

                transform.position += new Vector3(0, .05f, 0);


                direcao = -1;
                //if (jumping && noMuro)
                //    GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 0, 0));


            }
            if (Input.GetAxis("Vertical") < -0.01f)
            {


                transform.position -= new Vector3(0, .05f, 0);
                direcao = -1;
                Debug.Log("Baixo");
            }

        }


        //====================================================
        if (colideTeto)
        {
            transform.position += new Vector3(0, .05f, 0);
            girar180();

            // girar180();
            if (Input.GetAxis("Horizontal") > 0.01f)
            {

                transform.position += new Vector3(0, 0.05f, 0);


                direcao = -1;
                //if (jumping && noMuro)
                //    GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 0, 0));


            }
            if (Input.GetAxis("Horizontal") < -0.01f)
            {

                // girarMenos90();
                transform.position -= new Vector3(0, -0.05f, 0);
                direcao = 2;
                Debug.Log("Baixo");

            }

        }


        //-----------------------------------------------------------------

        if (Input.GetAxis("Fire1") > 0 && colideParedeEsquerda) // se atiro a partir da parede!
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(500, 0, 0));
            jumping = true;
           

        }

        if (Input.GetAxis("Fire1") > 0 && colideParedeDireita) // se atiro a partir da parede!
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-500, 0, 0));
            jumping = true;

        }

        if (Input.GetAxis("Fire1") > 0 && colideComTerreno)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 300, 0));
            jumping = true;
            //Debug.Log(jumping);

        }

        if (Input.GetAxis("Fire1") > 0 && colideTeto)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -500, 0));
            jumping = true;

            //gravidadeZero();

        }
        // Debug.Log("Colidiu com parede");
        // Debug.Log(jumping);


        #region Disparo
        if (Input.GetAxis("Fire2") > 0 && countTiro == 0)
        {
            GameObject t = Instantiate(tiro, transform.position, new Quaternion());


            t.GetComponent<Tiro>().direcao = direcao;

            Destroy(t, 1f);

            countTiro++;
        }

        if (countTiro != 0)
        {
            countTiro = (byte)((countTiro + 1) % 10);
        }
        #endregion


    }
    #endregion

    #region GRAVIDADE
    private void gravidadeZero()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;

    }

    private void gravidadeAtiva()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1.0f;

    }
    #endregion

    #region GIRAR
    private void girar90()
    {
        transform.eulerAngles = new Vector3(0, 0, 90);
    }
    private void girarMenos90()
    {
        transform.eulerAngles = new Vector3(0, 0, -90);
    }
    private void girar180()
    {
        transform.eulerAngles = new Vector3(0, 0, 180);
    }
    private void naoGirar()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void girarMenos180()
    {
        transform.eulerAngles = new Vector3(0, 0, -180);
    }
    #endregion

    #region COLISAO
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Paredes")
        {
            colideParedeEsquerda = true;

            jumping = false;

            gravidadeZero();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }


        if (collision.gameObject.tag == "ParedeDireita")
        {
            colideParedeDireita = true;

            jumping = false;

            gravidadeZero();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        if (collision.gameObject.tag == "Terrain")
        {
            colideComTerreno = true;
            jumping = false;
            naoGirar();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        }

        if (collision.gameObject.tag == "Teto")
        {
            colideTeto = true;
            jumping = false;
            girar180();
            gravidadeZero();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paredes")
        {
            colideParedeEsquerda = false;

        }

        if (collision.gameObject.tag == "ParedeDireita")
        {
            colideParedeDireita = false;

        }

        if (collision.gameObject.tag == "Terrain")
        {
            colideComTerreno = false;

        }

        if (collision.gameObject.tag == "Teto")
        {
            colideTeto = false;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ProjetilInimigo")
        {
            Destroy(collision.gameObject, 0);
        }
        if (collision.tag == "Cair")
        {
            Debug.Log("dentro");
            this.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    #endregion


}
