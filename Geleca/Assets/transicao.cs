using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transicao : MonoBehaviour {
    public Image black;
    public Animator anim;
    // Use this for initialization
    void Start () {
        StartCoroutine(Tempo());
        StartCoroutine(Fading());
        
    }
	
	// Update is called once per frame
	void Update () {
      

    }

  public  void Retornar() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }

    public void CenaCredito()
    {
        SceneManager.LoadScene("Creditos", LoadSceneMode.Single);

    }

    public void Carregamento() {
        SceneManager.LoadScene("Carregamento", LoadSceneMode.Single);
    }
    IEnumerator Fading() {
        anim.SetBool("Fade", true);

        yield return new WaitUntil(() => black.color.a == 0);

    }

    IEnumerator Tempo()
    {
       
        Debug.Log("Teste");
        yield return new WaitForSeconds(3);
        Retornar();
    }

}
