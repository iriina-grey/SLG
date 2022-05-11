using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadPanel : MonoBehaviour
{
    public GameObject loadScrern;
    public Slider slider;
    public Text text;

    public void Start()
    {
        LoadNext();
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(1);
       // StartCoroutine(LoadScene());
    }
    //IEnumerator LoadScene()
    //{
    //    loadScrern.SetActive(true);
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(1);
    //    operation.allowSceneActivation = false;
    //    while (!operation.isDone)
    //    {
    //        slider.value = operation.progress;
    //        text.text = operation.progress * 100 + "%";
    //        if (operation.progress >= 0.9)
    //        {
    //            slider.value = 1;
    //            text.text = "100%";

    //            Debug.Log(12);
    //         operation.allowSceneActivation = true;
                
    //        }
    //        yield return 0;
    //    }
    //    operation.allowSceneActivation = true;

    //}
}
