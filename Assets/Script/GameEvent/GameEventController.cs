using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEventController : Singleton<GameEventController>
{
    public GameEventItem[] randomEvent;
    public GameEventItem[] mainEvent;

    GameDataValue data;

    public GameObject UIPanel;
    public Text infoText;

    float randomNum;

    private void Awake()
    {
        data = GameObject.Find("ValueOfGame").transform.GetComponent<GameDataValue>();
        randomNum = 0.2f;
    }

    public void DoEvent()
    {
        int round = data.Round;
        GameEventItem item=new GameEventItem();
        switch (round)
        {
            case 20:
                mainEvent[0].Event();
                UiUpdate(mainEvent[0]);
                break;
            case 50:break;
            case 70:break;
            case 100:break;
            default:
                item = GetRandomEvent();
               
               
                if (item != null)
                {
                    UiUpdate(item);
                    item.Event();
                }
                    
                break;
        }
    }
    GameEventItem GetRandomEvent()
    {
        if (Random.Range(0f, 1f) < randomNum)
        {
            return randomEvent[Random.Range(0, randomEvent.Length)];
        }
        else
        {
            return null;
        }
    }
    void UiUpdate(GameEventItem item)
    {
        infoText.text = item.infoText;
        UIPanel.SetActive(true);
    }
}
