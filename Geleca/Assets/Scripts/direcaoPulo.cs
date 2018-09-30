using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direcaoPulo : MonoBehaviour {

    public Vector3 posicaoMouse;
    public float velocidadeMovi = 0.1f;
    public Vector2 minhaPosicao;
    public GameObject PosPlayer;
	// Use this for initialization

	void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        float movimentoVertical = Input.GetAxis("Vertical");

        minhaPosicao = new Vector2(transform.position.x, transform.position.y);//posicao atual

        this.transform.position = PosPlayer.transform.position;//Seta pega posicção do jogador para ficar anexada a ele sempre

        //-------------------- Rotação da seta de direção do salto
        // posicaoMouse = Input.mousePosition;
        // posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);
        //   Vector2 direcao = new Vector2(posicaoMouse.x - transform.position.x , 
        //                               posicaoMouse.y - transform.position.y);

        Vector2 movimentacao = new Vector2(movimentoHorizontal, movimentoVertical);
        transform.up = movimentacao ;
        //-------------------- Linha de Debug do jogador até o ponteiro do mouse


    }

}
