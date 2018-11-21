using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilInimigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //transform.Rotate(new Vector3(0, 0, 45));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //transform.position -= new Vector3(0.25f, 0, 0);

        transform.Translate(new Vector3(-0.095f, 0, 0));

	}
}
