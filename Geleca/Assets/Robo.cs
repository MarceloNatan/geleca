using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

    private bool patrulhar = true;

    [SerializeField]
    private Transform player;

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
            Debug.Log("Atirar");
        }
	}
}
