using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData 
{
    #region 重要游戏数据
    public  int round;
    public int manNum;
     
    public float man_Reduce_Farm;
    public float man_Reduce_Produce;
    public float man_Increace_SciencePoint;
     #endregion
     #region 主要资源信息
    public float food;
    public float energy;
    public float mineral;
    public float products;
    public float awakeNum = 100f;
     
    public float up_food;
    public float up_energy;
    public float up_mineral;
    public float up_products;
    public float up_awakeNum = 5f;
    
    public float reduce_food;
    public float reduce_energy;
    public float reduce_mineral;
    public float reduce_products;
    public float reduce_awakeNum = 0f;
    
    public float sciencePoint;
    public float scienceSpend;
     #endregion
     #region 建筑资源相关
     //总体信息
    public int buildNum_All;
    public int buildNum_max;
    public bool[] buildLine_Allow;
    public List<LoadMessage> buildingMassages;
     //数量
    public int farmNum;
    public int powerStationNum;
    public int factoryNum;
    public int laboratoryNum;
     //产值
    public float farmProduce;
    public float powerStationProduce;
    public float factoryProduce;
    public float laboratoryProduce;
     //消耗
    public float framSpend_Energy;
    public float factory_Energy;
    public float factory_Mimeral;
    public float laboratory_Energy;
     #endregion
     #region 
     #region 建筑相关
     //产值增量
    public float up_farmProduce;
    public float up_powerStationProduce;
    public float up_factoryProduce;
    public float up_laboratoryProduce;
    //产值倍率
    public float pup_farmProduce;
    public float pup_powerStationProduce;
    public float pup_factoryProduce;
    public float pup_laboratoryProduce;
     //消耗减少
    public float down_framSpend_Energy;
    public float down_factory_Energy;
    public float down_factory_Mimeral;
    public float down_laboratory_Energy;
    //建筑属性
    public float down_BuildSpend;
    public int down_BuildRound;
    #endregion
    #endregion
    #region 科技面板数据
    public List<int> index_1;
    public List<int> index_2;
    public List<int> index_3;
    public List<int> index_4;
    public int[] maxIndex;
    public int[] minIndex;
    public bool[] isFull;
    public List<LoadMessage> loadMessages_science;
    #endregion
    #region 游戏物体
    public List<PlantSaveData> plantlist;
    public List<EnemySaveData> enemylist;
    public List<Vector3> wallPosition;
    #endregion
    public Vector3 mainPlayerPosition;
    public int moveRangeNum;
    public int rayArray_Length;
}
