using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValueOfGame : MonoBehaviour
{

    #region 资源值
    #region 基础资源
    float food;
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

    float sciencePoint;
    float sciencePointSpend;
    #endregion
    #region 建筑信息：数量，产值
    //上限
    int max;
    int nowNum;
    //队列可用性
    bool[] buildLineAllow;
    
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
    public float Food { get => food; set => food = value; }
    public float Energy { get => energy; set => energy = value; }
    public float Mineral { get => mineral; set => mineral = value; }
    public float Products { get => products; set => products = value; }
    public float Up_food { get => up_food; set => up_food = value; }
    public float Up_energy { get => up_energy; set => up_energy = value; }
    public float Up_mineral { get => up_mineral; set => up_mineral = value; }
    public float Up_products { get => up_products; set => up_products = value; }
    public float Reduce_food { get => reduce_food; set => reduce_food = value; }
    public float Reduce_energy { get => reduce_energy; set => reduce_energy = value; }
    public float Reduce_mineral { get => reduce_mineral; set => reduce_mineral = value; }
    public float Reduce_products { get => reduce_products; set => reduce_products = value; }    
    public int FarmNum { get => farmNum; set => farmNum = value; }
    public int PowerStationNum { get => powerStationNum; set => powerStationNum = value; }
    public int FactoryNum { get => factoryNum; set => factoryNum = value; }
    public int LaboratoryNum { get => laboratoryNum; set => laboratoryNum = value; }
    public float FarmProduce { get => farmProduce; set => farmProduce = value; }
    public float PowerStationProduce { get => powerStationProduce; set => powerStationProduce = value; }
    public float FactoryProduce { get => factoryProduce; set => factoryProduce = value; }
    public float LaboratoryProduce { get => laboratoryProduce; set => laboratoryProduce = value; }
    public float SciencePoint { get => sciencePoint; set => sciencePoint = value; }
    public float SciencePointSpend { get => sciencePointSpend; set => sciencePointSpend = value; }
    #endregion

    private void Awake()
    {
        
        
        ValueAwake();
        
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("MainScene");

    }
    private void ValueAwake()
    {
        Food=awakeNum;
        Energy=awakeNum;
        Mineral=awakeNum;
        Products=awakeNum;

        Up_food=up_awakeNum;
        Up_energy = up_awakeNum;
        Up_mineral = up_awakeNum;
        Up_products = up_awakeNum;

        Reduce_food=reduce_awakeNum;
        Reduce_energy = reduce_awakeNum;
        Reduce_mineral = reduce_awakeNum;
        Reduce_products = reduce_awakeNum;
            
    }

    public float[] ValueGet_All()
    {
        float[] value = new float[4];
        value[0] = food;
        value[1] = energy;
        value[2] = mineral;
        value[3] = products;
        return value;
    }
    public float[] ValueChangeNum()
    {
        float[] value=new float[4];
        value[0] = Up_food + Reduce_food;
        value[1] = Up_energy + Reduce_energy;
        value[2] = Up_mineral + Reduce_mineral;
        value[3] = Up_products + Reduce_products;
        return value;
    }
    public float[] ValueRoundChang()
    {
        float[] value = new float[4];
        value = ValueChangeNum();
        food += value[0];
        energy += value[1];
        mineral += value[2];
        products += value[3];
        return ValueGet_All();
    }
    public void ValueUpdate()
    {
        Up_food =up_awakeNum;//农业区产值*区划数量*增加量+初始增量
        Up_energy = up_awakeNum;//电厂输出*数量*增加量+初始增量
        Up_mineral = up_awakeNum;//星球采掘
        Up_products = up_awakeNum;//区划*数量*增量

        Reduce_food = reduce_awakeNum;
        Reduce_energy = reduce_awakeNum;
        Reduce_mineral = reduce_awakeNum;
        Reduce_products = reduce_awakeNum;
    }
   
}
