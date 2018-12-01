using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Player : MonoBehaviour
{

    //bool jumping = false;
    
    [SerializeField]
    private GameObject Tiro;

    private byte countTiro = 0;

    //private Direcao direcao = Direcao.chao;

    [SerializeField]
   // private bool esquerda = false, direita, teto, chao;
   public bool colideComTerreno;
   public bool colideParedeEsquerda;
    public bool colideParedeDireita;
    public bool colideTeto;
    public bool pulando = false;

    bool teste = true;
    [SerializeField]
    private GameObject morte;

    [SerializeField]
    private bool gameOver;

    // Use this for initialization
    void Start()
    {
        teste = false;
        colideComTerreno = false;
        colideParedeEsquerda = false;
        colideTeto = false;
        Time.timeScale =1f - Time.deltaTime;
    }

    // Update is called oncea per frame
    void Update()
    {

        GetComponent<Animator>().SetInteger("estado", 0);

        if (gameOver)
            return;
        //-------------------------------------------------------
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (!pulando)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {


            GetComponent<SpriteRenderer>().flipX = true;

            if (!pulando)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
        }

        if (Input.GetAxis("Vertical") > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

            if (!pulando)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }

        }
        else if (Input.GetAxis("Vertical") < -0.01f)
        {

            GetComponent<SpriteRenderer>().flipX = true;

            if (!pulando)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
        }

        //if (!GetComponent<Animator>().GetBool("pulando"))
        //{
        //    GetComponent<SpriteRenderer>().flipX = true;
        //    GetComponent<Animator>().SetInteger("estado", 1);
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().flipX = false;
        //    GetComponent<Animator>().SetInteger("estado", 45);
        //}
    }

    //if (Input.GetAxis("Fire1") != 0 && !GetComponent<Animator>().GetBool("pulando"))
    //{
    //    //GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 500, 0));
    //    //jumping = true;
    //    if(teto || esquerda || direita)
    //    {
    //        GetComponent<Rigidbody2D>().gravityScale = 1;
    //        GetComponent<Animator>().SetBool("pulando", true);
    //    }
    //    else
    //    {
    //        GetComponent<Animator>().SetInteger("estado", 2);
    //    }



    //}

    /*if(jumping)
    {
        if(GetComponent<Animator>().GetBool("pulando"))
        {
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 2.723536f);
            GetComponent<BoxCollider2D>().size = new Vector2(3.15f, 7.396748f);
        }
    }*/



    private void FixedUpdate()
    {

        if (gameOver)
            return;

        sbyte direcao = 1;

        #region FisicaMovimentoCantos
        if ((colideParedeEsquerda && colideTeto && !teste) || (colideParedeDireita && colideTeto && !teste))
        {
            colideParedeDireita = false;
            colideParedeEsquerda = false;
            teste = true;
        }
        if (colideTeto && colideParedeEsquerda && teste || (colideParedeDireita && colideTeto && teste))
        {
            colideTeto = false;
            teste = false;
        } 
        #endregion

        //direita
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            direcao = 2;

            if (pulando)
                GetComponent<Rigidbody2D>().AddForce(new Vector3(3, 0, 0));
            else

                transform.position += new Vector3(0.05f, 0, 0);

        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            direcao = -1;
            if (pulando)
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-3, 0, 0));
            else
                transform.position -= new Vector3(0.05f, 0, 0);


        }

        //if (GetComponent<Animator>().GetBool("movendo"))
        //{


        //    if (((esquerda && !chao) && !teto) || (teto && esquerda))
        //    {
        //        transform.position -= new Vector3(0, 0.05f, 0);
        //    }
        //    else if (direita && teto)
        //    {
        //        transform.position -= new Vector3(0.05f, 0, 0);
        //    }

        //    else if (direita || (direita && chao))
        //    {
        //        transform.position += new Vector3(0, 0.05f, 0);
        //    }

        //    else if (teto)
        //    {
        //        transform.position -= new Vector3(0.05f, 0, 0);
        //    }
        //    else
        //    {
        //        transform.position += new Vector3(0.05f, 0, 0);
        //    }
        //}

        //   }
        //----------------------------------------------------------------------------------------------
        if (colideParedeEsquerda)
        {
           transform.position += new Vector3(-.05f, 0, 0);
            girarMenos90();
            if (Input.GetAxis("Vertical") > 0.01f)
            {
                Debug.Log("asdasdasdasd");
                transform.position += new Vector3(0, .05f, 0);
                //GetComponent<Rigidbody2D>().velocity = Vector3.zero;

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
        //-----------------------------------------------------------------
        //esquerda
        //if(Input.GetAxis("Horizontal")< -0.01f)
        //{
        //    direcao = -1;
        //    if (GetComponent<Animator>().GetBool("pulando"))
        //        GetComponent<Rigidbody2D>().AddForce(new Vector3(-3, 0, 0));
        //    else
        //    {


        //        //if ((esquerda ^= chao) || (direita ^= chao))
        //        //{
        //        //    transform.position += new Vector3(0, 0.05f, 0);
        //        //}
        //        //else
        //        //{

        //        //    transform.position -= new Vector3(0.05f, 0, 0);
        //        //}
        //        if (GetComponent<Animator>().GetBool("movendo"))
        //        {
        //            if (((esquerda && chao) || (esquerda && !chao)) && !teto)
        //            {
        //                transform.position += new Vector3(0, 0.05f, 0);
        //            }
        //            else if (direita && chao)
        //            {
        //                transform.position -= new Vector3(0.05f, 0, 0);
        //            }
        //            else if (direita || (teto && direita))
        //            {
        //                transform.position -= new Vector3(0, 0.05f, 0);
        //            }
        //            else if (teto)
        //            {
        //                transform.position += new Vector3(0.05f, 0, 0);
        //            }
        //            else
        //            {
        //                transform.position -= new Vector3(0.05f, 0, 0);
        //            }
        //        }



        //    }


        //}


        if (Input.GetAxis("Fire1") > 0 && colideParedeEsquerda) // se atiro a partir da parede!
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(500, 0, 0));
            pulando = true;


        }


        if (Input.GetAxis("Fire1") > 0 && colideParedeDireita)
        // se atiro a partir da parede!
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-500, 0, 0));
            pulando = true;

        }

        if (Input.GetAxis("Fire1") > 0 && colideComTerreno)

        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 300, 0));
            pulando= true;
            //Debug.Log(jumping);

        }


        if (Input.GetAxis("Fire1") > 0 && colideTeto)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -500, 0));
            pulando = true;

            //gravidadeZero();

        }

        //-----------------------------------------------------

        if (Input.GetAxis("Fire2") > 0 && countTiro == 0)
        {
            GameObject t = Instantiate(Tiro, transform.position, new Quaternion()) as GameObject;//MEXI AQUI tbS
            //GetComponent<Animator>().SetInteger("estado", 2);

            t.GetComponent<Tiro>().direcao = direcao;


            Destroy(t, 1f);

            countTiro++;
        }

        if (countTiro != 0)
        {
            countTiro = (byte)((countTiro + 1) % 10);
        }
        //Debug.Log(Input.GetAxis("Jump"));

    }
    #region GRAVIDADE
    public void GravidadeZero()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;

    }

    public void GravidadeAtiva()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Terrain":
                {
                    colideComTerreno = true;
                    pulando = false;
                    naoGirar();
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                }
                break;

            case "ParedeEsquerda":
                {
                    colideParedeEsquerda = true;

                    pulando = false;

                    GravidadeZero();
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                    ////GetComponent<SpriteRenderer>().flipX = true;

                    ////Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);


                    //transform.position = new Vector3(-8.877296f, transform.position.y);


                    //transform.rotation = Quaternion.Euler(0, 0, -90);

                    //GetComponent<Rigidbody2D>().gravityScale = 0;

                    ////direcao = Direcao.esquerda;

                    //esquerda = true;
                    ////Debug.Log("Esquerda:" + esquerda);
                }
                break;
            case "ParedeDireita":
                {
                    colideParedeDireita = true;

                    pulando = false;

                    GravidadeZero();
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    ////direcao = Direcao.direita;
                    ////transform.position = new Vector3(8.877299f, transform.position.y);
                    //transform.rotation = Quaternion.Euler(0, 0, 90);

                    //GetComponent<Rigidbody2D>().gravityScale = 0;
                    //direita = true;
                }
                break;
            case "Teto":
                {
                    colideTeto = true;
                    pulando = false;
                    girar180();
                    GravidadeZero();
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;


                    //teto = true;


                    //transform.rotation = Quaternion.Euler(0, 0, 180);

                }
                break;

            case "BloqueioInimigo":
            case "DanoInimigo":
                {
                    if (gameOver)
                        return;

                    GameObject m = Instantiate(morte);
                    m.transform.position = transform.position;
                    m.transform.rotation = transform.rotation;

                    //Destroy(this.gameObject);
                    GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

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


                    colideParedeEsquerda = false;
                    //transform.rotation = Quaternion.Euler(0, 0, 0);
                    //transform.position += new Vector3(1, 0, 0);
                }
                break;
            case "Terrain":
                {
                    colideComTerreno = false;
                    //Debug.Log("Chao false");
                }
                break;
            case "Teto":
                {
                    //teto = false;
                    colideTeto = false;
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
                    colideParedeDireita = false;

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

            //case "DesabilitaFisica":
            //    {
                    
            //        Debug.Log("dentDFSDFDroOK");
            //        GravidadeAtiva();

            //        // GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //    }
            //    break;
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
        //if (collision.tag == "ProjetilInimigo")
        //{
        //    //Destroy(collision.gameObject,0);
        //}
        if (collision.tag == "DesabilitaFisica")
        {

            Debug.Log("dentroOK");
            GravidadeAtiva();

            // GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Debug.Log("Colisao com o terreno");
            //////transform.rotation = new Quaternion();
            //////GetComponent<Animator>().SetBool("pulando", false);
            //////GetComponent<Animator>().SetInteger("estado", 0);
            //////chao = true;
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
