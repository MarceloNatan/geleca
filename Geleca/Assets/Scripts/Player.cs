﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool jumping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {


        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            transform.position += new Vector3(0.05f,0,0);
        }else if(Input.GetAxis("Horizontal")< -0.01f)
        {
            transform.position -= new Vector3(0.05f, 0, 0);
        }

        if(Input.GetAxis("Jump") != 0 && !jumping)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0,500,0));
            jumping = true;
        }

        //Debug.Log(Input.GetAxis("Jump"));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            jumping = false;
        }

        Debug.Log(collision.gameObject.tag);
    }



}