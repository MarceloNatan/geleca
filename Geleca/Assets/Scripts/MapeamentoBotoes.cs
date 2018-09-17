using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapeamentoBotoes : MonoBehaviour {
    GameObject btnA;
    GameObject btnB;
    GameObject btnX;
    GameObject btnY;
    GameObject btnLB;
    GameObject btnRB;
    GameObject btnLT;
    GameObject btnRT;
    
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

        btnLB = GameObject.Find("EsquerdoFrente");
        btnLB.SetActive(false);

        btnRB = GameObject.Find("DireitoFrente");
        btnRB.SetActive(false);

        btnLT = GameObject.Find("LT");
        btnLT.SetActive(false);

        btnRT = GameObject.Find("RT");
        btnRT.SetActive(false);
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


        if (Input.GetKeyDown("joystick button 4"))
        {
            btnLB.SetActive(true);
        }
        else
        {
            if (Input.GetKeyUp("joystick button 4"))
            {
                btnLB.SetActive(false);
            }
        }

        //------------------------------------------------------
        if (Input.GetKeyDown("joystick button 5"))
        {
            btnRB.SetActive(true);
        }
        else
        {
            if (Input.GetKeyUp("joystick button 5"))
            {
                btnRB.SetActive(false);
            }
        }
        //------------------------------------------------------
        if (Input.GetAxis("GatilhoLT")==1)
        {
            btnLT.SetActive(true);
        }
        else
        {
            if (Input.GetAxis("GatilhoLT") == 0)
            {
                btnLT.SetActive(false);
            }
        }
        //------------------------------------------------------
        if (Input.GetAxis("GatilhoRT") == 1)
        {
            btnRT.SetActive(true);
        }
        else
        {
            if (Input.GetAxis("GatilhoRT") == 0)
            {
                btnRT.SetActive(false);
            }
        }

    }


}
