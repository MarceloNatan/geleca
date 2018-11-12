using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBloqueioTiro : MonoBehaviour {

    [SerializeField]
    Animator anim;

    Vector3 ataque = new Vector3(1.68f, 1.18f, 0);

    private void Update()
    {
        
        switch (anim.GetInteger("IdAnimacao"))
        {
            case 5:

                transform.rotation = Quaternion.Euler(new Vector3(0,0, 180));

                break;

            case 6:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                transform.localPosition = ataque;
                break;
            case 0:
            case 1:
            case 2:
                transform.rotation = new Quaternion();
                transform.localPosition = new Vector3();
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tiro")
        {
            Destroy(collision.gameObject);
        }
    }


}
