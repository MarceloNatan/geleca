using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeCamera : MonoBehaviour {

    [SerializeField]
    Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(player.position.x>transform.position.x)
        {
            transform.position += new Vector3(0.025f,0,0);
        }

        if(player.position.y -3  > transform.position.y)
        {
            transform.position += new Vector3(0, 0.25f, 0);
        }

    }
}
