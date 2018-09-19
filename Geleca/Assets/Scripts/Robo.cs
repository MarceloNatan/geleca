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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(patrulhar)
        {

        }

        if(Vector3.Distance(transform.position, player.position) < 10)
        {
            //Debug.Log("Atirar");

            

            if ( countTiro == 0)
            {
                GameObject t = Instantiate(projetil, transform.position, new Quaternion());
                Destroy(t, 6);

                countTiro++;
            }

            if (countTiro != 0)
            {
                countTiro = (byte)((countTiro + 1) % 100);
            }

        }
	}
}
