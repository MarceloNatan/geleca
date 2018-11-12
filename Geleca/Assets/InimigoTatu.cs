using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoTatu : MonoBehaviour {

    Animator animator;

    [SerializeField]
    float rodar = 0;

    [SerializeField]
    float multiplicador = 1;

    [SerializeField]
    private Transform[] position;
    [SerializeField]
    private float speed;

    [SerializeField]
    private byte posIda;

    [SerializeField]
    private bool reiniciarAnimacao;

    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private float vida = 100;

    Vector2 offset = new Vector2(0.13f, 0.2f);
    Vector2 size = new Vector2(4.1595f, 0.9424f);
    



    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if(animator.GetInteger("IdAnimacao") == 4 && !reiniciarAnimacao)
        {
            transform.Rotate(new Vector3(0,0, rodar));



            if (rodar < 30)
            {
                rodar += (0.01f * multiplicador);


                if (rodar > 3)
                {
                    multiplicador += 0.001f;
                }
                else
                {
                    multiplicador += 0.05f;

                }
            }
            

            if(rodar > 13)
            {
                transform.position += (position[posIda].position - transform.position) * Time.deltaTime * speed;

                if(Vector3.Distance(transform.position, position[posIda].position) < 0.1)
                {
                    posIda = (byte)(((posIda) + 1)%position.Length);

                    if(speed<10)
                    {
                        speed += 0.5f;
                    }else
                    {
                        if(posIda == position.Length-1)
                        {
                            reiniciarAnimacao = true;
                        }
                    }
                }
            }
        }

        
        if(reiniciarAnimacao)
        {
            transform.Rotate(new Vector3(0, 0, rodar));      
            
            if(Vector3.Distance(transform.position, position[position.Length - 1].position)>distanciaMinima)
            {
                transform.position += (position[position.Length - 1].position - transform.position) * Time.deltaTime * speed;

                
            }
            else
            {
                if (rodar > 0)
                {
                    rodar -= 0.09f;
                }else if(rodar<0)
                {
                    rodar = 0;
                }else if(rodar == 0)
                {
                    if(transform.position.z != 0)
                    {
                        if(transform.position.z >-1 && transform.position.z<1)
                        {
                            reiniciarAnimacao = false;
                            animator.SetInteger("IdAnimacao", 5);
                            transform.rotation = new Quaternion();
                            rodar = 10;
                            speed = 1;
                            multiplicador = 1;
                        }
                        else
                        {
                            transform.Rotate(new Vector3(0, 0, -0.5f));
                        }
                    }
                }
            }
        }


        if(GetComponent<SpriteRenderer>().color.a<1)
        {
            GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.05f);
        }

        BoxCollider2D box = GetComponent<BoxCollider2D>();

        if (animator.GetInteger("IdAnimacao") == 6)
        {  
            box.offset = new Vector2(1.396931f, 1.571151f);
            box.size = new Vector2(0.940393f,4.283875f);
        }else
        {
            box.offset = offset;
            box.size = size;
        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Tiro")
        {
            if (animator.GetInteger("IdAnimacao") > 4)
            {
                GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.35f);
                vida -= collision.gameObject.GetComponent<Tiro>().valorDoDano;
            }

            Destroy(collision.gameObject);
        }
        

        
    }
}
