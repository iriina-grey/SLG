 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameDataValue : MonoBehaviour
{
    #region 重要游戏数据
    public int round;
    int manNum;

    public float man_Reduce_Farm;
    public float man_Reduce_Produce;
    public float man_Increace_SciencePoint;
    #endregion
    #region 主要资源信息
    public float food;
    float energy;
    float mineral;
    float products;
    float awakeNum = 100f;

    float up_food;
    float up_energy;
    float up_mineral;
    float up_products;
    float up_awakeNum = 5f;

    float reduce_food;
    float reduce_energy;
    float reduce_mineral;
    float reduce_products;
    float reduce_awakeNum = 0f;

    public float sciencePoint;
    float scienceSpend;
    #endregion
    #region 建筑资源相关
    //总体信息
    int buildNum_All;
    int buildNum_max;
    bool[] buildLine_Allow;
    List<LoadMessage> buildingMassages;
    //数量
    int farmNum;
    int powerStationNum;
    int factoryNum;
    int laboratoryNum;
    //产值
    float farmProduce;
    float powerStationProduce;
    float factoryProduce;
    float laboratoryProduce;
    //消耗
    float framSpend_Energy;
    float factory_Energy;
    float factory_Mimeral;
    float laboratory_Energy;
    #endregion
    #region 
    #region 建筑相关
    //产值增量
    float up_farmProduce;
    float up_powerStationProduce;
    float up_factoryProduce;
    float up_laboratoryProduce;
    //产值倍率
    float pup_farmProduce;
    float pup_powerStationProduce;
    float pup_factoryProduce;
    float pup_laboratoryProduce;
    //消耗减少
    float down_framSpend_Energy;
    float down_factory_Energy;
    float down_factory_Mimeral;
    float down_laboratory_Energy;
    //建筑属性
    float down_BuildSpend;
    int down_BuildRound;
    //
    #region 游戏物体
    public List<PlantSaveData> plantlist;
    public List<EnemySaveData> enemylist;
    public List<Vector3> wallPosition;
    #endregion
    public Vector3 mainPlayerPosition;
    public int moveRangeNum;
    public int rayArray_Length;
    
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
    public SaveData Save()
    {
        SaveData save = new SaveData();
        save.round = this.round;
        save.manNum = this.manNum;
        save.man_Reduce_Farm = this.man_Reduce_Farm;
        save.man_Reduce_Produce = this.man_Reduce_Produce;
        save.man_Increace_SciencePoint = this.man_Increace_SciencePoint;

        save.food = this.food;
        save.energy = this.energy;
        save.mineral = this.mineral;
        save.products = this.products;

        
        save.up_food= this.up_food;
        save.up_energy= this.up_energy;
        save.up_mineral= this.up_mineral;
        save.up_products=this.up_products;
        save.up_awakeNum =this.up_awakeNum;
        save.reduce_food =this.reduce_food ;
        save.reduce_energy =this.reduce_energy ;
        save.reduce_mineral=this.reduce_mineral ;
        save.reduce_products=this.reduce_products ;
        save.reduce_awakeNum=this.reduce_awakeNum;
        
        save.buildNum_All=BuildNum_All  ;
        save.buildNum_max=BuildNum_max ;

        save.farmNum=FarmNum;
        save.powerStationNum=PowerStationNum;
        save.factoryNum=FactoryNum;
        save.laboratoryNum=LaboratoryNum;
        save.farmProduce=FarmProduce;
        save.powerStationProduce=PowerStationProduce;
        save.factoryProduce=FactoryProduce;
        save.laboratoryProduce=LaboratoryProduce;
        save.framSpend_Energy=FramSpend_Energy;
        save.factory_Energy=Factory_Energy;
        save.factory_Mimeral=Factory_Mimeral;
        save.laboratory_Energy=Laboratory_Energy;
        save.up_farmProduce=Up_farmProduce;
        save.up_powerStationProduce=Up_powerStationProduce;
        save.up_factoryProduce=Up_factoryProduce ;
        save.up_laboratoryProduce=Up_laboratoryProduce ;
        save.pup_farmProduce = Pup_farmProduce;
        save.pup_powerStationProduce=Pup_powerStationProduce  ;
        save.pup_factoryProduce=Pup_factoryProduce  ;
        save.pup_laboratoryProduce=Pup_laboratoryProduce  ;
        save.down_framSpend_Energy=Down_framSpend_Energy  ;
        save.down_factory_Energy=Down_factory_Energy  ;
        save.down_factory_Mimeral=Down_factory_Mimeral ;
        save.down_laboratory_Energy=Down_laboratory_Energy  ;
        save.down_BuildSpend=Down_BuildSpend ;
         save.down_BuildRound=Down_BuildRound ;
        save.buildLine_Allow =BuildLine_Allow ;
         save.buildingMassages=BuildingMassages ;
        save.sciencePoint=SciencePoint ;
        save.scienceSpend=ScienceSpend  ;
        save.round=Round ;

    save. plantlist=this.plantlist;
    save.enemylist=this.enemylist;
    save.wallPosition=this.wallPosition;
    
    save. mainPlayerPosition=this.mainPlayerPosition;
    save. moveRangeNum=this.moveRangeNum;
    save. rayArray_Length=this.rayArray_Length;
    
    
    save. index_1=this.index_1;
    save. index_2= this.index_2;
    save.index_3=this.index_3;
    save.index_4=this.index_4;
    save. maxIndex=this.maxIndex;
    save. minIndex=this.minIndex;
    save. isFull=this.isFull;
    save. loadMessages_science=this.loadMessages_science;
        return save;
}

    public int BuildNum_All { get => buildNum_All; set => buildNum_All = value; }
    public int BuildNum_max { get => buildNum_max; set => buildNum_max = value; }
    public int FarmNum { get => farmNum; set => farmNum = value; }
    public int PowerStationNum { get => powerStationNum; set => powerStationNum = value; }
    public int FactoryNum { get => factoryNum; set => factoryNum = value; }
    public int LaboratoryNum { get => laboratoryNum; set => laboratoryNum = value; }
    public float FarmProduce { get => farmProduce; set => farmProduce = value; }
    public float PowerStationProduce { get => powerStationProduce; set => powerStationProduce = value; }
    public float FactoryProduce { get => factoryProduce; set => factoryProduce = value; }
    public float LaboratoryProduce { get => laboratoryProduce; set => laboratoryProduce = value; }
    public float FramSpend_Energy { get => framSpend_Energy; set => framSpend_Energy = value; }
    public float Factory_Energy { get => factory_Energy; set => factory_Energy = value; }
    public float Factory_Mimeral { get => factory_Mimeral; set => factory_Mimeral = value; }
    public float Laboratory_Energy { get => laboratory_Energy; set => laboratory_Energy = value; }
    public float Up_farmProduce { get => up_farmProduce; set => up_farmProduce = value; }
    public float Up_powerStationProduce { get => up_powerStationProduce; set => up_powerStationProduce = value; }
    public float Up_factoryProduce { get => up_factoryProduce; set => up_factoryProduce = value; }
    public float Up_laboratoryProduce { get => up_laboratoryProduce; set => up_laboratoryProduce = value; }
    public float Pup_farmProduce { get => pup_farmProduce; set => pup_farmProduce = value; }
    public float Pup_powerStationProduce { get => pup_powerStationProduce; set => pup_powerStationProduce = value; }
    public float Pup_factoryProduce { get => pup_factoryProduce; set => pup_factoryProduce = value; }
    public float Pup_laboratoryProduce { get => pup_laboratoryProduce; set => pup_laboratoryProduce = value; }
    public float Down_framSpend_Energy { get => down_framSpend_Energy; set => down_framSpend_Energy = value; }
    public float Down_factory_Energy { get => down_factory_Energy; set => down_factory_Energy = value; }
    public float Down_factory_Mimeral { get => down_factory_Mimeral; set => down_factory_Mimeral = value; }
    public float Down_laboratory_Energy { get => down_laboratory_Energy; set => down_laboratory_Energy = value; }
    public float Down_BuildSpend { get => down_BuildSpend; set => down_BuildSpend = value; }
    public int Down_BuildRound { get => down_BuildRound; set => down_BuildRound = value; }
    public bool[] BuildLine_Allow { get => buildLine_Allow; set => buildLine_Allow = value; }
    public List<LoadMessage> BuildingMassages { get => buildingMassages; set => buildingMassages = value; }
    public float SciencePoint { get => sciencePoint; set => sciencePoint = value; }
    public float ScienceSpend { get => scienceSpend; set => scienceSpend = value; }
    public int Round { get => round; set => round = value; }
    #endregion
    #endregion
    private void Awake()
    {
        MainValueAwake();
        BuildValue_Awake();
        SceniceValue_Awake();
        BaseValueAwake();
        ScienceDataAwake();
        GameObjDataAwake();

       
        
    }

    public void BuildValue_NumChange(int value,string type)
    {      
            switch (type)
            {
                case "farm":
                    FarmNum += value;
                    break;

                case "powerStation":
                    PowerStationNum += value;
                    break;

                case "factory":
                    FactoryNum += value;
                    break;

                case "laboratory":
                    LaboratoryNum += value;
                    break;

            }
        BuildNum_All = FactoryNum + FarmNum + LaboratoryNum + PowerStationNum;
    }
    public bool BuildValue_IsAllowToBuild()
    {
        BuildNum_All = FactoryNum + FarmNum + LaboratoryNum + PowerStationNum;
        if (BuildNum_All < BuildNum_max)
        {
            return true;
        }else
        {
            return false;
        }
    }
    public float[] GetBaseValue_All()
    {
        float[] values = new float[4];
        values[0] = food;
        values[1] = energy;
        values[2] = mineral;
        values[3] = products;
        return values;
    }
    public void RoundAndManNumChange()
    {
        round++;
        manNum++;
    }
    public float[] ChangBaseValue_All()
    {
        
        float[] changes = new float[4];
        up_food = up_awakeNum + ((farmProduce + up_farmProduce) * farmNum * pup_farmProduce);
        up_energy = up_awakeNum + ((PowerStationProduce + up_powerStationProduce) * powerStationNum * pup_powerStationProduce);
        up_mineral = 0;
        up_products = up_awakeNum + ((factoryProduce + up_factoryProduce) * factoryNum * pup_factoryProduce);

        reduce_food = reduce_awakeNum + manNum * man_Reduce_Farm;
        reduce_energy = reduce_awakeNum + factoryNum * (factory_Energy - down_factory_Energy)+laboratoryNum*(laboratory_Energy-down_laboratory_Energy);
        reduce_mineral = reduce_awakeNum + factoryNum * (factory_Mimeral - down_factory_Mimeral);
        reduce_products = reduce_awakeNum + manNum * man_Reduce_Produce;

        changes[0] = up_food - reduce_food;
        changes[1] = up_energy - reduce_energy;
        changes[2] = up_mineral - reduce_mineral;
        changes[3] = up_products = reduce_products;

        food += changes[0];
        energy += changes[1];
        mineral += changes[2];
        products += changes[3];
        sciencePoint += (manNum / 5) * man_Increace_SciencePoint + laboratoryNum * (laboratoryProduce+up_laboratoryProduce)*pup_laboratoryProduce;
        RoundAndManNumChange();
        return changes;
    }
    public float BaSeValue_Reduce(float value,string type)
    {
        switch (type)
        {
            case "food":
                food += value;
                return food;
                
            case "energy":
                energy += value;
                return energy;
                
            case "mineral":
                mineral += value;
                return mineral;
                
            case "products":
                products += value;
                return products;
               
        }
        return 0;
    } 
    void BuildValue_Awake()
    {
        //总体信息
        this.buildNum_All=0;
        this.buildNum_max=5;
        this.buildLine_Allow =new bool[3] { true, false, false }; ;
        this.buildingMassages = new List<LoadMessage>();
        //数量
        this.farmNum=0;
        this.powerStationNum=0;
        this.factoryNum=0;
        this.laboratoryNum=0;
        //产值
        this.farmProduce=10;
        this.powerStationProduce=10;
        this.factoryProduce=20;
        this.laboratoryProduce=10;
        //消耗
        this.framSpend_Energy=5;
        this.factory_Energy=10;
        this.factory_Mimeral=10;
        this.laboratory_Energy=5;
    }
    void SceniceValue_Awake()
    {
        //产值增量
        this.up_farmProduce=0;
        this.up_powerStationProduce=0;
        this.up_factoryProduce=0;
        this.up_laboratoryProduce=0;
        //产值倍率
        this.pup_farmProduce=1;
        this.pup_powerStationProduce=1;
        this.pup_factoryProduce=1;
        this.pup_laboratoryProduce=1;
        //消耗减少
        this.down_framSpend_Energy=0;
        this.down_factory_Energy=0;
        this.down_factory_Mimeral=0;
        this.down_laboratory_Energy=0;
        //建筑属性
        this.down_BuildSpend=0;
        this.down_BuildRound=0;
    }
    private void BaseValueAwake()
    {
        food = awakeNum;
        energy = awakeNum;
        mineral = awakeNum+100;
        products = awakeNum;

        up_food = up_awakeNum;
        up_energy = up_awakeNum;
        up_mineral = 0;
        up_products = up_awakeNum;

        reduce_food = reduce_awakeNum;
        reduce_energy = reduce_awakeNum;
        reduce_mineral = reduce_awakeNum;
        reduce_products = reduce_awakeNum;
        sciencePoint = 100;
        scienceSpend = 50;
    }
    void MainValueAwake()
    {
        round = 1;
        manNum = 5;
        man_Reduce_Farm=1;
        man_Reduce_Produce=1;
        man_Increace_SciencePoint=1;
    }
    void GameObjDataAwake()
    {
        #region 游戏物体
     plantlist=new List<PlantSaveData>();
     enemylist=new List<EnemySaveData>();
        wallPosition = new List<Vector3>() ;
    #endregion
     mainPlayerPosition=new Vector3(0,0,0);
     moveRangeNum=1;
     rayArray_Length=5;     
    }
    void ScienceDataAwake()
    {
        maxIndex = new int[4] { 3, 3, 3, 3 };
        minIndex = new int[4];
        isFull = new bool[4] { false, false, false, false };
        index_1 = new List<int>();
        index_2 = new List<int>();
        index_3 = new List<int>();
        index_4 = new List<int>();
        loadMessages_science = new List<LoadMessage>();
    }
    public void LoadSave(SaveData save)
    {
        this.manNum = save.manNum;
        this.man_Reduce_Farm = save.man_Reduce_Farm;
        this.man_Reduce_Produce = save.man_Reduce_Produce;
        this.man_Increace_SciencePoint = save.man_Increace_SciencePoint;
        this.food = save.food;
        this.energy = save.energy;
        this.mineral = save.mineral;
        this.products = save.products;
        this.awakeNum = save.awakeNum;
        this.up_food = save.up_food;
        this.up_energy = save.up_energy;
        this.up_mineral = save.up_mineral;
        this.up_products = save.up_products;
        this.up_awakeNum = save.up_awakeNum;
        this.reduce_food = save.reduce_food;
        this.reduce_energy = save.reduce_energy;
        this.reduce_mineral = save.reduce_mineral;
        this.reduce_products = save.reduce_products;
        this.reduce_awakeNum = save.reduce_awakeNum;
        SciencePoint = save.sciencePoint;
        ScienceSpend = save.scienceSpend;
        BuildNum_All = save.buildNum_All;
        BuildNum_max = save.buildNum_max;
        BuildLine_Allow = save.buildLine_Allow;
        BuildingMassages = save.buildingMassages;
        FarmNum = save.farmNum;
        PowerStationNum = save.powerStationNum;
        FactoryNum = save.factoryNum;
        LaboratoryNum = save.laboratoryNum;
        FarmProduce = save.farmProduce;
        PowerStationProduce = save.powerStationProduce;
        FactoryProduce = save.factoryProduce;
        LaboratoryProduce = save.laboratoryProduce;
        FramSpend_Energy = save.framSpend_Energy;
        Factory_Energy = save.factory_Energy;
        Factory_Mimeral = save.factory_Mimeral;
        Laboratory_Energy = save.laboratory_Energy;
        Up_farmProduce = save.up_farmProduce;
        Up_powerStationProduce = save.up_powerStationProduce;
        Up_factoryProduce = save.up_factoryProduce;
        Up_laboratoryProduce = save.up_laboratoryProduce;
        Pup_farmProduce = save.pup_farmProduce;
        Pup_powerStationProduce = save.pup_powerStationProduce;
        Pup_factoryProduce = save.pup_factoryProduce;
        Pup_laboratoryProduce = save.pup_laboratoryProduce;
        Down_framSpend_Energy = save.down_framSpend_Energy;
        Down_factory_Energy = save.down_factory_Energy;
        Down_factory_Mimeral = save.down_factory_Mimeral;
        Down_laboratory_Energy = save.down_laboratory_Energy;
        Down_BuildSpend = save.down_BuildSpend;
        Down_BuildRound = save.down_BuildRound;
        BuildNum_All = save.buildNum_All;
        BuildNum_max = save.buildNum_max;
        FarmNum = save.farmNum;
        PowerStationNum = save.powerStationNum;
        FactoryNum = save.factoryNum;
        LaboratoryNum = save.laboratoryNum;
        FarmProduce = save.farmProduce;
        PowerStationProduce = save.powerStationProduce;
        FactoryProduce = save.factoryProduce;
        LaboratoryProduce = save.laboratoryProduce;
        FramSpend_Energy = save.framSpend_Energy;
        Factory_Energy = save.factory_Energy;
        Factory_Mimeral = save.factory_Mimeral;
        Laboratory_Energy = save.laboratory_Energy;
        Up_farmProduce = save.up_farmProduce;
        Up_powerStationProduce = save.up_powerStationProduce;
        Up_factoryProduce = save.up_factoryProduce;
        Up_laboratoryProduce = save.up_laboratoryProduce;
        Pup_farmProduce = save.pup_farmProduce;
        Pup_powerStationProduce = save.pup_powerStationProduce;
        Pup_factoryProduce = save.pup_factoryProduce;
        Pup_laboratoryProduce = save.pup_laboratoryProduce;
        Down_framSpend_Energy = save.down_framSpend_Energy;
        Down_factory_Energy = save.down_factory_Energy;
        Down_factory_Mimeral = save.down_factory_Mimeral;
        Down_laboratory_Energy = save.down_laboratory_Energy;
        Down_BuildSpend = save.down_BuildSpend;
        Down_BuildRound = save.down_BuildRound;
        BuildLine_Allow = save.buildLine_Allow;
        BuildingMassages = save.buildingMassages;
        SciencePoint = save.sciencePoint;
        ScienceSpend = save.scienceSpend;
        Round = save.round;

    }
}
