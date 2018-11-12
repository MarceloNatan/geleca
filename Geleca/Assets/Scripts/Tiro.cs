using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

    public sbyte direcao = 1;
    public float speed = 0.05f;
    public float moveSpeed = 100f;
    public float turnSpeed = 50f;

    [SerializeField]
    public float valorDoDano;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //transform.R(new Vector3(0,0,25f) );  
        transform.Translate(new Vector3(0.1f,0,0));

    }
}
