using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Science/Item/ScienceItem/WuLi", fileName = "WuLi_")]
public class WuLi : ScienceItem
{    
    public float up_laboratoryProduce;
    public float pup_laboratoryProduce;
    public float down_laboratory_Energy;
    public float up_powerStationProduce;
    public float pup_powerStationProduce;
    public int type;
    public override void DoEvent()
    {
        base.DoEvent();
        ValueChange(type);
    }
    void ValueChange(int type)
    {
        GameDataValue gameData = GameObject.Find("ValueOfGame").GetComponent<GameDataValue>();
        switch (type)
        {
            case 1:
                gameData.Up_laboratoryProduce+=up_laboratoryProduce;
                break;
            case 2:
                gameData.Pup_laboratoryProduce+=pup_laboratoryProduce;
                break;
            case 3:
                gameData.Down_laboratory_Energy += down_laboratory_Energy;
                break;
            case 4:
                gameData.Up_powerStationProduce += up_powerStationProduce;
                break;
            default:
                gameData.Pup_powerStationProduce += pup_powerStationProduce;
                break;
        }
    }
}
