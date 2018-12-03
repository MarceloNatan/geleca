using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

    private bool patrulhar = true;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject projetil;
    private int countTiro;

    public float velocidade;
    public bool movimentoDireita = true;
    public Transform detectaCHao;
    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        transform.Translate(Vector2.right * velocidade* Time.deltaTime);
        RaycastHit2D chaoInfo = Physics2D.Raycast(detectaCHao.position, Vector2.down, 2f);
        if (chaoInfo.collider == false) {
            if(movimentoDireita == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movimentoDireita = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movimentoDireita = true;
                    }
        }
    }
    // Update is called once per frame
    void FixedUpdate () {


		if(patrulhar)
        {

        }

      //Debug.Log("Atirar");

            

            if ( countTiro == 0)
            {
                GameObject t = Instantiate(projetil, transform.position, new Quaternion(-1,-1,0,0));
                Destroy(t, 6);

                countTiro++;
            }

            if (countTiro != 0)
            {
                countTiro = (byte)((countTiro + 1) % 100);
            }

        
	}
}
