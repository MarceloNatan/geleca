using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo01 : MonoBehaviour {

    Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if(rigidbody.velocity.y < 0)
        {
            rigidbody.AddForce(new Vector3(0, 20f, 0));
        }

        //Debug.Log(rigidbody.velocity.y);

	}
}
