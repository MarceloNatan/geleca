using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour {
    public Rigidbody2D rb;
    public float velocidade = 7;
    //public float velPulo = 7;
    // Use this for initialization
    
	void Start () {
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector2 movimentacao = new Vector2(movimentoHorizontal, movimentoVertical);

        rb.AddForce(movimentacao * velocidade);
	}
  
    void Update()
    {

    }
}
