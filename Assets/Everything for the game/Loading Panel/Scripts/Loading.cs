using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider slider;
    public Text text;
    
    public void LoadScene(int scene)
    {
        StartCoroutine(LoadAsync(scene));
    }

    IEnumerator LoadAsync (int scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            text.text =  (float)Math.Round((double)progress * 100f, 1) + "%";
            yield return null;
        }
    }
}
