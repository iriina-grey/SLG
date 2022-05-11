using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.EventMessenger;

public class PlayerIns : Singleton<PlayerIns>
{
    public int moveRangeNum;
    Vector3 mainPosition;

    public Transform moveAreaCenterPoint;
    public GameObject moveAreaPrefabe;
    public GameObject losePanel;
    
    Vector3 centerPosition;
    Vector3 move_Horizontal;
    Vector3 move_Vertical;

    

    GameDataValue dataValue;
    private void Awake()
    {
        dataValue = GameObject.Find("ValueOfGame").GetComponent<GameDataValue>();
        moveRangeNum = dataValue.moveRangeNum;
        //
       move_Horizontal = new Vector3(100f, 0f, 0f); 
        move_Vertical = new Vector3(0f, 0f, 100f);

        centerPosition = moveAreaCenterPoint.position + new Vector3(0f, -50, 0f);
        MoveAreaIns();
        
        
    }
    private void Start()
    {
        LoadData();
    }
    public  void MoveAreaIns()
    {
        int k;
        centerPosition = moveAreaCenterPoint.position + new Vector3(0f, -50, 0f);
        foreach (Transform ss in moveAreaCenterPoint.transform)
        {
            Destroy(ss.gameObject);
        }
        for (int i = 0; i < moveRangeNum; i++)
        {
            k = 2 * i;
            for (int j=0; j <=k; j++)
            {
                Vector3 newAreaPosition;
                Vector3 offset;

                offset = move_Vertical * (moveRangeNum - i) + j * move_Horizontal- i* move_Horizontal;
                
                InsMoveAreaPrefabe(newAreaPosition = centerPosition + offset );
                InsMoveAreaPrefabe(newAreaPosition = centerPosition - offset );
            }
        }
        for(int j = 0; j <= moveRangeNum * 2; j++)
        {
            Vector3 newAreaPosition;
            Vector3 offset;

            offset = move_Vertical * 0 + j * move_Horizontal - moveRangeNum * move_Horizontal;
            InsMoveAreaPrefabe(newAreaPosition = centerPosition + offset);
        }

    }
    public void MoveAreaIns_p(Vector3 centerPosition_f)
    {
        int k;
        for (int i = 0; i < moveRangeNum; i++)
        {
            k = 2 * i;
            for (int j = 0; j <= k; j++)
            {
                Vector3 newAreaPosition;
                Vector3 offset;

                offset = move_Vertical * (moveRangeNum - i) + j * move_Horizontal - i * move_Horizontal;

                InsMoveAreaPrefabe(newAreaPosition = centerPosition_f + offset);
                InsMoveAreaPrefabe(newAreaPosition = centerPosition_f - offset);
            }
        }
        for (int j = 0; j <= moveRangeNum * 2; j++)
        {
            Vector3 newAreaPosition;
            Vector3 offset;

            offset = move_Vertical * 0 + j * move_Horizontal - moveRangeNum * move_Horizontal;
            InsMoveAreaPrefabe(newAreaPosition = centerPosition_f + offset);
        }

    }
    void InsMoveAreaPrefabe(Vector3 position)
    {
        GameObject gameObject = Instantiate(moveAreaPrefabe, position, Quaternion.identity);
        gameObject.transform.SetParent(moveAreaCenterPoint);
    }
    public void SaveData()
    {
        dataValue.mainPlayerPosition = this.gameObject.transform.position;
    }
    public void LoadData()
    {
        this.gameObject.transform.position = dataValue.mainPlayerPosition;
        moveRangeNum = dataValue.moveRangeNum;

    }
    public void ExpendMoveArea()
    {
        moveRangeNum = dataValue.moveRangeNum;
        for (int i = 1; i < moveAreaCenterPoint.childCount; i++)
        {
            Destroy(moveAreaCenterPoint.GetChild(i).gameObject);
        }
        MoveAreaIns();
    }
    public void LoseGame()
    {
        float[] f = dataValue.GetBaseValue_All();
        foreach(float i in f)
        {
            if (i < -100)
                StartCoroutine(Lose());
        }
    }
    IEnumerator Lose()
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
}
