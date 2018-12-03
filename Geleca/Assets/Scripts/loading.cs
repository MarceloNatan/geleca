using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class loading : MonoBehaviour
{
    public GameObject txt100;
    public GameObject start;
    public GameObject loadin;
    public Slider slider;

    AsyncOperation async;

    void Start()
    {
        LoadingJogo();
      // ThisTxt = this.GetComponent<TextMesh>();
    }

    public void LoadingJogo()
    {
        StartCoroutine(LoadingTela());
    }

    IEnumerator LoadingTela()
    {
        loadin.SetActive(true);
        async = SceneManager.LoadSceneAsync(3);
        async.allowSceneActivation = false;
        while (async.isDone == false) {
            slider.value = async.progress;

            if (async.progress == 0.9f)
            {
                start.SetActive(true);
                txt100.SetActive(true);
                if (Input.anyKey)
                {
                   
                    slider.value = 1f;
                    async.allowSceneActivation = true;
                }
            }
            yield return null;
                 
        }

    }
}
