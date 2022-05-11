using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BettleManager : MonoBehaviour
{
    public int level;
    public int enemyLevel;
    bool isWin;

    public float product;
    public float energe;

    public Camera mainCamera;
    public GameObject mainCavas;
    public GameObject panel;
    public Text text;

    public AudioSource source;
    private void Awake()
    {
        level = 1;
        enemyLevel = 1;
        product = 10;
        energe = 10;
    }
    public void LoadBettleScene(int level)
    {
        mainCamera.gameObject.SetActive(false);
        source.Stop();
        SceneManager.LoadScene("CardBattle", LoadSceneMode.Additive);
    }
    public void ShutBettleScene()
    {
        mainCamera.gameObject.SetActive(true);
        AsyncOperation async= SceneManager.UnloadSceneAsync("CardBattle");
        StartCoroutine(WinEvent(async));
    }
    public void WinBettle()
    {
        //UI
        UIupdate.Instance.ValueReduceView(product*level,"products",3);
        UIupdate.Instance.ValueReduceView(energe * level, "energy",1);
        source.Play();
        panel.SetActive(true);
        text.text ="战斗胜利：\n消耗:能量："+" "+level*energe+"工业品："+level*product;
        EnemyObjectController.Instance.BackThisSceene();
    }
    IEnumerator WinEvent(AsyncOperation async)
    {
        while (!async.isDone)
        {
            yield return 0;
        }
        
        WinBettle();
    }
    public void LoadBettleScene()
    {
        
        SceneManager.LoadScene("CardBattle", LoadSceneMode.Additive);
        mainCamera.gameObject.SetActive(false);
    }
}
