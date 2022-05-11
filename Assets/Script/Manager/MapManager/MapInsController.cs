using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.EventMessenger;
public class MapInsController :Singleton<MapInsController>
{
    public Transform mapCreatePoint;
    public GameObject rayPoint;
    public GameObject mapWall;
    public Transform map;
    public Material[] ice_material;
    public GameObject testPlant;
    public PlantFactory plantFactory;
    public EnemyFactory enemyFactory;

    Transform[] rayArray;
    int rayArray_Length;
    //zhanshi
    List<GameObject> plantList;
    float maxDistance;
    LayerMask layerMask;
    List<Vector3> newWallPosition;
    List<Vector3> WallPositions;

    //敌人数据
    float insRange;
    int roundnum;
    bool isOnPlant;
    int level;
    int enemyInsArea;
    public List<GameObject> enemyList;

    Vector3 move_Horizontal;
    Vector3 move_Vertical;

    GameDataValue dataValue;
    private new void Awake()
    {
        base.Awake();
        dataValue = GameObject.Find("ValueOfGame").GetComponent<GameDataValue>();
        rayArray_Length = dataValue.rayArray_Length;

        plantList = new List<GameObject>();
        layerMask = 1 << 8;
        WallPositions = new List<Vector3>();
        maxDistance = ( new Vector3(0, -50, 0)).magnitude+2f;       
        move_Horizontal = new Vector3(100f, 0f, 0f);
        move_Vertical = new Vector3(0f, 0f, 100f);
        rayArray = new Transform[rayArray_Length * rayArray_Length];
       
        

        testPlant.transform.GetComponent<Renderer>().material = ice_material[1];
         insRange=1f;
        roundnum=1;
        isOnPlant=false;
        level=1;
        enemyInsArea=8;
        enemyList = new List<GameObject>();
        Messenger.AddListener("Save", this.SaveData);
        //enemyList=GameObject.Find("ValueOfGame").transform.GetComponent<BettleData>().enemyList;
    }
    private void Start()
    {
        RayArrayIns(rayArray_Length, mapCreatePoint.position);
        LoadData();
        
        MapWallIns();
    }
    void RayArrayIns(int length, Vector3 centerPosition)
    {
        Vector3 firstPoint = centerPosition + length / 2 * (move_Horizontal + move_Vertical);
        Vector3 nowPoint;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                nowPoint = firstPoint - i * move_Vertical - j * move_Horizontal;
                
                rayArray[i*length+j]= GameObject.Instantiate(rayPoint, nowPoint, Quaternion.identity, mapCreatePoint).transform;
            }
        }
    }
    void MapWallIns()
    {
        newWallPosition = new List<Vector3>();
        Debug.Log(rayArray.Length);
        foreach (Transform point in rayArray)
        {
            Vector3 newPoint=new Vector3(0,0,0);
            
                newPoint = point.position + new Vector3(0f, -50f, 0f);
            
            
           
            if (!PhysicsRayCast_Wall(point, layerMask))
            {
                GameObject.Instantiate(mapWall, newPoint, Quaternion.Euler(90f, 0f, 0f), map);
                newWallPosition.Add(newPoint);
                WallPositions.Add(newPoint);
                
            }
                
        }
       
    }
    bool PhysicsRayCast_Wall(Transform point,LayerMask layerMask_F)
    {
        return Physics.Raycast(point.position, -transform.up, maxDistance, layerMask_F);
    }

    void PlantCreat()
    {

    }
    void EnemyCreat()
    {
        
        isOnPlant = PhysicsRayCast_Wall(mapCreatePoint.transform, 1 << 10);
        
        if (isOnPlant)
        {
            
            if (Random.Range(0f, 1f) <= insRange * roundnum)
            {
                Debug.Log("DoEnemyCreat" + isOnPlant);
                Vector3 offer;
                Vector3 insPosition = mapCreatePoint.transform.position;
                offer = Random.Range(4, enemyInsArea) * move_Horizontal* Random_pord() + Random.Range(4, enemyInsArea) * move_Vertical* Random_pord();
                insPosition += offer;
                enemyFactory.EnemyIns(level,insPosition,enemyList);
                roundnum++;
            }

        }
        else
        {
            roundnum = 1;
        }
    }
    int  Random_pord()
    {
        if (Random.Range(0f, 1f) > 0.5)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    public  void AfterPlayerMove()
    {
        MapWallIns();
        if (newWallPosition.Count!=0)
        plantFactory.CreatPlant(newWallPosition, plantList, 1);
        Debug.Log("nowPlant:"+plantList.Count);
        EnemyCreat();
        
        
    }
    public void SavePreper()
    {

    }
    List<EnemySaveData> EnemySaveDatas()
    {
        List<EnemySaveData> enemySaveDatas=new List<EnemySaveData>();
        foreach(GameObject enemy in enemyList)
        {
            EnemySaveData data = new EnemySaveData();
            data.position = enemy.transform.position;
            data.level = enemy.GetComponent<Enemy>().level;
            enemySaveDatas.Add(data);
        }
        return enemySaveDatas;
    }
    List<PlantSaveData> PlantSaveDatas()
    {
        List<PlantSaveData> plantSaveDatas = new List<PlantSaveData>();
        foreach(GameObject plant in plantList)
        {

            Debug.Log(plant == null);
            Debug.Log(plantList.Count);
            PlantSaveData saveData = new PlantSaveData();
            PlantData plantData = plant.GetComponent<PlantData>();
            saveData.caijiRound = plantData.caijiRound;
            saveData.energy = plantData.energy;
            saveData.food = plantData.food;
            saveData.mineral = plantData.mineral;
            saveData.position = plant.transform.position;
            saveData.type = plantData.type;
            plantSaveDatas.Add(saveData);
        }
        return plantSaveDatas;
    }
    public void SaveData()
    {
        List<PlantSaveData> plantSaveDatas = PlantSaveDatas();
        List<EnemySaveData> enemySaveDatas = EnemySaveDatas();

        dataValue.plantlist = plantSaveDatas;
        dataValue.enemylist = enemySaveDatas;
        dataValue.wallPosition = WallPositions;       
    }
    void LoadData()
    {
        List<Vector3> wallPosition = dataValue.wallPosition;
        List<PlantSaveData> plantSaveDatas = dataValue.plantlist;
        List<EnemySaveData> enemySaveDatas = dataValue.enemylist;

        foreach(Vector3 position in wallPosition)
        {
            GameObject.Instantiate(mapWall, position, Quaternion.Euler(90f, 0f, 0f), map);            
            WallPositions.Add(position);
        }
        foreach(EnemySaveData saveData in enemySaveDatas)
        {
            enemyFactory.EnemyIns(saveData.level, saveData.position, enemyList);
        }
        foreach(PlantSaveData saveData in plantSaveDatas)
        {
            plantFactory.CreatPlant(saveData.position, plantList, saveData);
        }
    }
}
