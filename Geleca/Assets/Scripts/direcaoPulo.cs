using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direcaoPulo : MonoBehaviour {

    public Vector3 posicaoMouse;
    public float velocidadeMovi = 0.1f;
    public Vector2 minhaPosicao;
    public GameObject PosPlayer;
    private int countTiro;

    [SerializeField]
    private GameObject projetil;

    public Quaternion frente;

    // Use this for initialization

    void Start () {
        

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float movimentoHorizontal = Input.GetAxis("HorizontalY");

        float movimentoVertical = Input.GetAxis("VerticalY");

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
        //Color cor = new Color(201, 0, 0);
        //Debug.DrawLine(minhaPosicao, posicaoMouse, cor);

        frente = transform.rotation;

        movimentoHorizontal = movimentoHorizontal < 0 ? movimentoHorizontal * -1 : movimentoHorizontal;
        movimentoVertical = movimentoVertical < 0 ? movimentoVertical * -1 : movimentoVertical;
        if (countTiro == 0 && (movimentoHorizontal >= 1f || movimentoVertical>=1f) )
        {
            Vector3 angulos = transform.rotation.eulerAngles;

            Quaternion target = Quaternion.Euler(new Vector3(angulos.x,angulos.y, angulos.z + 85));

            GameObject t = Instantiate(projetil, transform.position, target );
            t.GetComponent<SpriteRenderer>().sortingOrder = 100;
            //t.transform.rotation = Quaternion.Slerp(t.transform.rotation, target, Time.deltaTime * smooth);

            //t.GetComponent<Tiro>().direcao = direcao;

            //Debug.Log("Vertical:" + movimentoVertical);
            //Debug.Log("Horizontal:" + movimentoHorizontal);
            Destroy(t, 5f);

            countTiro++;
        }

        if (countTiro != 0)
        {
            countTiro = (byte)((countTiro + 1) % 20);
        }

        //========




    }
}
