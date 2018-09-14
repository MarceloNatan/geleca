using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direcaoPulo : MonoBehaviour {
    public Vector3 posicaoMouse;
    public float velocidadeMovi = .1f;
    public Vector2 minhaPosicao;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

         minhaPosicao = new Vector2(transform.position.x, transform.position.y);

        //-------------------- Rotação da seta de direção do salto
        posicaoMouse = Input.mousePosition;
        posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);
        Vector2 direcao = new Vector2(posicaoMouse.x - transform.position.x , 
                                      posicaoMouse.y - transform.position.y);

        transform.up = direcao;


        //-------------------- Linha de Debug do jogador até o ponteiro do mouse
        Color cor = new Color(201, 0, 0);
        Debug.DrawLine(minhaPosicao, posicaoMouse, cor);
    }
}
