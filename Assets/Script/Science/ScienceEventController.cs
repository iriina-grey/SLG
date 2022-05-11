using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.EventMessenger;
public class ScienceEventController : Singleton<ScienceEventController>
{
    public List<LoadMessage> loadMessages;
    
    public ScienceItem[] event_1;    
    public ScienceItem[] event_2;
    public ScienceItem[] event_3;
    public ScienceItem[] event_4;
    List<int> index_1;
    List<int> index_2;
    List<int> index_3;
    List<int> index_4;
    int[] maxIndex;
    int[] minIndex;
    bool[] isFull;

    GameDataValue Data;
    private void  Awake()
    {
        Data = GameObject.FindGameObjectWithTag("Data").transform.GetComponent<GameDataValue>();

    }
    
    private void Start()
    {
        SciencePanelUIUpdate.Instance.ViewPoint(Data.SciencePoint);
        
        maxIndex = Data.maxIndex;
        minIndex = Data.minIndex;
        isFull = Data.isFull;
        index_1 = Data.index_1;
        index_2 = Data.index_2;
        index_3 = Data.index_3;
        index_4 = Data.index_4;
        loadMessages = Data.loadMessages_science;
        LoadData();
    }
    void SciencebuildCreat(int type)
    {
        switch (type)
        {
            case 1:
                Debug.Log("isfull:" + isFull);

                if (!isFull[0]&&ScienceSpend())
                {
                    Creatbulid(type, event_1, index_1);
                    isFull[0] = true;
                }
                
                
                else
                {
                    Debug.Log("队列已满");
                }
                ; break;
            case 2:
                if (!isFull[1] && ScienceSpend())
                {
                    Creatbulid(type, event_2, index_2);
                    isFull[1] = true;
                }
                    
                else
                {

                }
                break;
            case 3:
                if (!isFull[2] && ScienceSpend())
                {
                    Creatbulid(type, event_3, index_3);
                    isFull[2] = true;
                   
                }
                    
                else
                {

                }
                break;
            default:
                if (!isFull[3] && ScienceSpend())
                {
                    Creatbulid(type, event_4, index_4);
                    isFull[3] = true;
                }
                    
                else
                {

                }
                break;
        }
    }
    void Creatbulid(int type,ScienceItem[] sciences,List<int> iList)
    {
        bool isScienceFinish=false;
        bool isScienceSame = false;
        ScienceItem build = new ScienceItem();
        int randomNum=0;
        LevelUp(type, iList);
        if (sciences.Length > iList.Count)
        {
            while (!isScienceFinish)
            {
                randomNum = Random.Range(minIndex[type - 1], maxIndex[type - 1]);
                isScienceSame = false;
                foreach (int i in iList)
                {
                    if (i == randomNum)
                    {
                        isScienceSame = true;
                        break;
                    }
                }
                if (!isScienceSame)
                {
                    build = sciences[randomNum];
                    iList.Add(randomNum);
                    isScienceFinish = true;
                }

            }

            LoadMessage message = new LoadMessage();
            message.lineNum = type;
            message.roundSpend = build.round;
            message.load = 1f / message.roundSpend;
            message.round = build.round;
            message.type = randomNum;
            loadMessages.Add(message);
            //Uigengxing
            SciencePanelUIUpdate.Instance.BuildLineUpdate(type - 1, build.ScienceName, build.Infotext);
        }
        
    }
    public void RoundEvent()
    {
        List<LoadMessage> buildingMassages_Remove = new List<LoadMessage>();
        SciencePanelUIUpdate.Instance.ViewPoint(Data.SciencePoint);
        foreach (LoadMessage massage in loadMessages)
        {
            Debug.Log(massage.roundSpend--);
            //UI更新
            SciencePanelUIUpdate.Instance.BuildLineUpdate(massage.lineNum-1,massage.load);
            if (massage.roundSpend == 0)
            {
                //输出
                Debug.Log(massage.lineNum);
                switch (massage.lineNum)
                {
                    case 1:
                        event_1[massage.type].DoEvent();
                        buildingMassages_Remove.Add(massage);
                        isFull[0] = false;
                        break;
                    case 2:
                        event_2[massage.type].DoEvent();
                        buildingMassages_Remove.Add(massage);
                        isFull[1] = false;
                        break;
                    case 3:
                        event_3[massage.type].DoEvent();
                        buildingMassages_Remove.Add(massage);
                        isFull[2] = false;
                        break;
                    default:
                        event_4[massage.type].DoEvent();
                        buildingMassages_Remove.Add(massage);
                        isFull[3] = false;
                        break;
                }

                //UI更新
                SciencePanelUIUpdate.Instance.BuildLine_Remove(massage.lineNum-1);
            }
        }
        foreach (LoadMessage remove in buildingMassages_Remove)
        {
            loadMessages.Remove(remove);
        }
    }
    void LevelUp(int type, List<int> iList)
    {
        if (iList.Count >= maxIndex[type - 1])
        {
            minIndex[type - 1] = maxIndex[type - 1];
            maxIndex[type - 1] += 3;
        }
    }
    public bool ScienceSpend()
    {
        float spend = Data.ScienceSpend;
        float point = Data.SciencePoint;
        if (spend < point)
        {
            Data.SciencePoint = point - spend;
            Data.ScienceSpend = spend + 5;
            SciencePanelUIUpdate.Instance.ViewPoint(Data.SciencePoint);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OnClick_shengwu()
    {
        SciencebuildCreat(1);
    }
    public void OnClick_WuLi()
    {
        SciencebuildCreat(2);
    }
    public void OnClick_Inducty()
    {
        SciencebuildCreat(3);
    }
    public void OnClick_Soice()
    {
        SciencebuildCreat(4);
    }
    public void SaveData()
    {
        Data.maxIndex= maxIndex ;
        Data.minIndex=minIndex;
        Data.isFull=isFull;

        Data.index_1=index_1 ;
        Data.index_2 = index_2;
        Data.index_3 = index_3;
        Data.index_4 = index_4;
        Data.loadMessages_science=loadMessages;
    }
    void LoadData()
    {
        foreach(LoadMessage load in loadMessages)
        {
            int type = load.lineNum;
            ScienceItem build;
            switch (type)
            {
                case 1:
                    build= event_1[load.type];
                    
                    
                    break;
                case 2:
                    build = event_2[load.type];
                    break;
                case 3:
                    build = event_3[load.type];
                    
                    break;
                default:
                    build = event_4[load.type];
                    break;
            }
            SciencePanelUIUpdate.Instance.BuildLineUpdate(type - 1, build.ScienceName, build.Infotext);
            SciencePanelUIUpdate.Instance.BuildLineUpdate(type - 1, load.load*(load.round-load.roundSpend));
        }
        
    }
}
