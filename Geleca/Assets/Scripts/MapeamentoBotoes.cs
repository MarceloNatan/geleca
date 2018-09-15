using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapeamentoBotoes : MonoBehaviour {
    GameObject btnA;
    GameObject btnB;
    GameObject btnX;
    GameObject btnY;
    // Use this for initialization
    void Start () {

        btnA = GameObject.Find("btnA");
        btnA.SetActive(false);

        btnB = GameObject.Find("btnB");
        btnB.SetActive(false);

        btnX = GameObject.Find("btnX");
        btnX.SetActive(false);

        btnY = GameObject.Find("btnY");
        btnY.SetActive(false);



    }
	
	// Update is called once per frame
	void Update () {
        Botao();
    }

    void Botao()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            btnA.SetActive(true);
        }
        else
        {
            if (Input.GetKeyUp("joystick button 0"))
            {
                btnA.SetActive(false);
            }
        }


        if (Input.GetKeyDown("joystick button 1"))
        {
            btnB.SetActive(true);
        }
        else
        {
            if (Input.GetKeyUp("joystick button 1"))
            {
                btnB.SetActive(false);
            }
        }
        //-------------------------------------------------------
        if (Input.GetKeyDown("joystick button 2"))
        {
            btnX.SetActive(true);
        }
        else
        {
            if (Input.GetKeyUp("joystick button 2"))
            {
                btnX.SetActive(false);
            }
        }
        //------------------------------------------------------

        if (Input.GetKeyDown("joystick button 3"))
        {
            btnY.SetActive(true);
        }
        else
        {
            if (Input.GetKeyUp("joystick button 3"))
            {
                btnY.SetActive(false);
            }
        }
        //------------------------------------------------------
    }


}
