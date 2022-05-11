using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.EventMessenger;
public class BuildingController :Singleton<BuildingController>
{
    List<LoadMessage> buildingMassages;
    [SerializeField] BuildItem[] buildItems;

    bool[] buildLine_Allow;

    GameDataValue data;
    private new void Awake()
    {   //从GameValue获得
        
        data = GameObject.Find("ValueOfGame").transform.GetComponent<GameDataValue>();
        //data.BuildNum_max = 20;
        buildLine_Allow = data.BuildLine_Allow;
        buildingMassages = data.BuildingMassages;
        BuildPanelUIController.Instance.BuildNum_Update(data.BuildNum_max, data.BuildNum_All);
        
        Debug.Log("awake");
    }
    private void Start()
    {
        LoadSave();
    }
    public void RoundEvent()
    {
        List<LoadMessage> buildingMassages_Remove=new List<LoadMessage>();
        foreach (LoadMessage massage in buildingMassages)
        {
            Debug.Log( massage.roundSpend--);
            //UI更新
            BuildPanelUIController.Instance.BuildLineUpdate(massage.lineNum, massage.load);
            if (massage.roundSpend == 0)
            {
                //输出
                Debug.Log("EndBuild");

                buildItems[massage.type].DoBuildEvent();
                
                buildLine_Allow[massage.lineNum] = true;
                buildingMassages_Remove.Add(massage);
                //UI更新
                BuildPanelUIController.Instance.BuildNum_Update(data.BuildNum_max, data.BuildNum_All);
                BuildPanelUIController.Instance.BuildLine_Remove(massage.lineNum);
            }
        }
        foreach(LoadMessage remove in buildingMassages_Remove)
        {
            buildingMassages.Remove(remove);
        }
    }

    public void OnBuildFactory()
    {
        AddBuildLine(2);
    }
    public void OnBuildFarm()
    {
        AddBuildLine(0);
    }
    public void OnBuildPowerStation()
    {
        AddBuildLine(1);
    }
    public void OnBuildLaboratory()
    {
        AddBuildLine(3);
    }
    void MessageAdd(int type,int lineNum)
    {
        LoadMessage massage = new LoadMessage();
        massage.type = type;
        massage.lineNum = lineNum;
        massage.round = buildItems[type].round - data.Down_BuildRound;
        massage.roundSpend = buildItems[type].round-data.Down_BuildRound;//减去减免回合
        massage.load = 1f / massage.roundSpend;
        
        ;
        buildingMassages.Add(massage);
    }
    void AddBuildLine(int type)
    {
        int i = 0;
        float spend;
        
            foreach (bool isAllow in buildLine_Allow)
            {
                if (isAllow)
                {

                    if (data.BuildValue_IsAllowToBuild())
                    {
                        spend = buildItems[type].spend - data.Down_BuildSpend;
                        UIupdate.Instance.ValueReduceView(spend, "products", 3);
                        buildLine_Allow[i] = !isAllow;
                        MessageAdd(type, i);
                        //UI
                        BuildPanelUIController.Instance.BuildLineUpdate(i, buildItems[type].buildName);
                        break;
                    }
                    else
                    {
                        //超出限制
                        break;
                    }

                }

                i++;
                if (i > 2)
                {
                    Debug.Log("无多余队列");
                }
            }
        
    }
    public void BuildLine_Allow_Change()
    {
        if (buildingMassages.Count == 0|| buildingMassages.Count == 1)
        {
            if (!buildLine_Allow[2]&& buildLine_Allow[1])
            {
                buildLine_Allow[2] = true;
                BuildPanelUIController.Instance.BuildLine_On(2);
            }else if (!buildLine_Allow[1])
            {
                buildLine_Allow[1] = true;
                BuildPanelUIController.Instance.BuildLine_On(1);
            }
        }else if (buildingMassages.Count == 2)
        {
            buildLine_Allow[2] = true;
            BuildPanelUIController.Instance.BuildLine_On(2);
        }
    }
    public void SaveData()
    {
        data.BuildingMassages = buildingMassages;
        data.BuildLine_Allow = buildLine_Allow;
    }
   void LoadSave()
    {
        if (buildingMassages.Count > 0)
        {
            foreach(LoadMessage loadMessage in buildingMassages)
            {
                int round = loadMessage.round - loadMessage.roundSpend;
                BuildPanelUIController.Instance.BuildLineUpdate(loadMessage.lineNum, loadMessage.load*round);
            }
        }
    }
}
