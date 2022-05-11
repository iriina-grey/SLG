using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectController : Singleton<EnemyObjectController>
{
    public EnemyState[] states;
    public bool isDoing;
    public List<GameObject> enemyList;
    
    public bool isNext;
    int listCount;
    int nowNum;
    bool isMoving;
    bool isInThisScene;

    Vector3 move_Horizontal = new Vector3(100f, 0f, 0f);
    Vector3 move_Vertical = new Vector3(0f, 0f, 100f);
    Vector3 movePosition;
    Transform self;
    float speed=2f;

    BettleManager bettleManager;
    private void Awake()
    {
        isNext = false;
        isDoing = false;
        isInThisScene = true;
        listCount = 0;
        nowNum = 0;

        bettleManager = GameObject.Find("BattleManager").GetComponent<BettleManager>();
        
    }

    private void Start()
    {
        enemyList = MapInsController.Instance.enemyList;
    }
    private void Update()
    {
        EnemyMove();
    }
    public void EnemyMove()
    {
        if (isInThisScene)
        {
            if (isDoing)
            {
                if (isNext)
                {
                    nowNum++;
                    if (nowNum > listCount)
                    {
                        nowNum = 0;
                        isDoing = false;
                    }
                    else
                    {

                        self = enemyList[nowNum - 1].transform;

                        movePosition = GetMovePosition(2);
                        self.Find("ShipModle").transform.LookAt(movePosition);
                    }
                    isNext = false;
                }
                else
                {
                    if (!Moveing())
                    {
                        isNext = true;
                    }
                }

            }
        }
    }
    bool Moveing()
    {
        
        if (self.position != movePosition)
        {
            self.Translate((movePosition - self.position) * speed * Time.deltaTime);
            if (Mathf.Abs((movePosition - self.position).magnitude) <= 0.5)
                self.position = movePosition;
            return true;
        }
        else
        {
            Event_SwichScene();
            return false;
        }
    }
    Vector3 GetMovePosition(int level)
    {
        Vector3 playerPosition = this.gameObject.transform.position;
        Vector3 selfPosition = self.position;
        Vector3 offer = playerPosition - selfPosition;
        Vector3 offer_ = new Vector3();
        if (selfPosition == playerPosition)
            return selfPosition;
        for (int i = 0; i < level; i++)
        {
            if (Mathf.Abs(offer.x) > Mathf.Abs(offer.z))
            {
                if (offer.x > 0)
                {
                    offer_ += move_Horizontal;
                }
                else
                {
                    offer_ -= move_Horizontal;
                }
                
            }
            else
            {
                if (offer.z > 0)
                {
                    offer_ += move_Vertical;
                }
                else
                {
                    offer_ -= move_Vertical;
                }
                
            }
            if (offer_ + selfPosition == playerPosition)
                return offer_ + selfPosition;
        }
        return offer_ + selfPosition;
    }
    public void EnemyRoundStart()
    {
        //获取enemy列表和
        listCount = enemyList.Count;
        
        if (listCount == 0)
            this.isDoing = false;
        else
        {
            this.isDoing = true;
            this.isNext = true;
            
        }
        
        
    }
    void Event_SwichScene()
    {
        
        if (self.position == this.gameObject.transform.position)
        {
            isInThisScene = false;
            bettleManager.LoadBettleScene(2);
        }
    }
    public void BackThisSceene()
    {
        this.nowNum--;
        this.listCount--;
        enemyList.Remove(self.gameObject);
        Destroy(self.gameObject);

        isInThisScene = true;
    }
    public void NextItem()
    {
        this.isNext = true;
    }
}
