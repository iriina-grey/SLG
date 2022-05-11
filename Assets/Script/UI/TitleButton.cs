using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleButton : MonoBehaviour
{
    public AudioSource[] audios;

    public void StartGame()
    {
        audios[0].Play();
        Invoke("StartGame_Load", 0.2f);

    }
    void StartGame_Load()
    {
        SceneManager.LoadSceneAsync("AwakeScene");
    }
    public void QuitGame()
    {
        audios[0].Play();
        Invoke("Quit", 0.2f);
    }
    void Quit()
    {

#if UNITY_EDITOR    //在编辑器模式下
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
