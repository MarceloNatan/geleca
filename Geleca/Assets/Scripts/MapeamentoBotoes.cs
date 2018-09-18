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

    GameObject stickDireitoDireita;
    GameObject stickDireitoEsquerda;
    GameObject stickDireitoCima;
    GameObject stickDireitoBaixo;

    GameObject stickEsquerdoDireita;
    GameObject stickEsquerdoEsquerda;
    GameObject stickEsquerdoCima;
    GameObject stickEsquerdoBaixo;

    GameObject direcionalDireito;
    GameObject direcionalEsquerdo;
    GameObject direcionalCima;
    GameObject direcionalBaixo;



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

        //============================================================================

        stickDireitoDireita  = GameObject.Find("analogicoDireitoDireita");
        stickDireitoDireita.SetActive(false);

        stickDireitoEsquerda = GameObject.Find("analogicoDireitoEsquerda");
        stickDireitoEsquerda.SetActive(false);

        stickDireitoCima     = GameObject.Find("analogicoDireitoCima");
        stickDireitoCima.SetActive(false);

        stickDireitoBaixo    = GameObject.Find("analogicoDireitoBaixo");
        stickDireitoBaixo.SetActive(false);
        //XXXXXXXX
        stickEsquerdoDireita  = GameObject.Find("analogicoEsquerdoDireita");
        stickEsquerdoDireita.SetActive(false);

        stickEsquerdoEsquerda = GameObject.Find("analogicoEsquerdoEsquerda");
        stickEsquerdoEsquerda.SetActive(false);

        stickEsquerdoCima     = GameObject.Find("analogicoEsquerdoCima");
        stickEsquerdoCima.SetActive(false);

        stickEsquerdoBaixo    = GameObject.Find("analogicoEsquerdoBaixo");
        stickEsquerdoBaixo.SetActive(false);

        //============================================================================

        direcionalDireito = GameObject.Find("DirDireito");
        direcionalDireito.SetActive(false);

        direcionalEsquerdo = GameObject.Find("DirEsquerdo");
        direcionalEsquerdo.SetActive(false);

        direcionalCima = GameObject.Find("DirUp");
        direcionalCima.SetActive(false);

        direcionalBaixo = GameObject.Find("DirDown");
        direcionalBaixo.SetActive(false);

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
        //------------------------------------------------------
        if (Input.GetAxis("DirDireito") > 0.19)
        {
            direcionalDireito.SetActive(true);
        }
        else
        {
            if (Input.GetAxis("DirDireito") == 0)
            {
                direcionalDireito.SetActive(false);
            }
        }
        //------------------------------------------------------
        if (Input.GetAxis("DirEsquerdo") < 0)
        {
            direcionalEsquerdo.SetActive(true);
        }
        else
        {
            if (Input.GetAxis("DirEsquerdo") == 0)
            {
                direcionalEsquerdo.SetActive(false);
            }
        }

        //------------------------------------------------------
        if (Input.GetAxis("DirCima") > 0.19)
        {
            direcionalCima.SetActive(true);
        }
        else
        {
            if (Input.GetAxis("DirCima") == 0)
            {
                direcionalCima.SetActive(false);
            }
        }
        //------------------------------------------------------
        if (Input.GetAxis("DirBaixo") < 0)
        {
            direcionalBaixo.SetActive(true);
        }
        else
        {
            if (Input.GetAxis("DirBaixo") == 0)
            {
                direcionalBaixo.SetActive(false);
            }
        }
        //----------------------------------------------------
        if (Input.GetAxis("Horizontal") > 0)
        {
            stickEsquerdoEsquerda.SetActive(false);

        } else if (Input.GetAxis("Horizontal") == 0)
        {
            stickEsquerdoEsquerda.SetActive(false);
        }
    }


}
