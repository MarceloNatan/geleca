using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour {
    public Rigidbody2D rb;
    public float velocidade = 20;
    //public float velPulo = 7;
    // Use this for initialization
    //direcaoPulo direcao;
    //bool pulo = false;
   // GameObject btnLT;
    GameObject DirecaoPulo;

    void Start () {
      //  btnLT = GameObject.Find("LT");
        DirecaoPulo = GameObject.Find("DirecaoPulo");
        DirecaoPulo.SetActive(false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float movimentoHorizontal = Input.GetAxis("Horizontal");

        float movimentoVertical = Input.GetAxis("Vertical");

        Vector2 movimentacao = new Vector2(movimentoHorizontal, movimentoVertical);

        rb.AddForce(movimentacao * velocidade);


        if (Input.GetAxis("GatilhoLT") == 1)
        {
            DirecaoPulo.SetActive(true);
            velocidade = 0;

        }
        else
        {
            if (Input.GetAxis("GatilhoLT") == 0)
            {
                DirecaoPulo.SetActive(false);
                velocidade = 20f;
            }
        }
    }
  
}
