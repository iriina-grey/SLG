using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : ScriptableObject,IPlantMake
{
    [SerializeField]
    Material[] materials;
    [SerializeField]
    GameObject plantPrefabe;
    [SerializeField]
    protected  float mineral_num;
    [SerializeField]
    protected  float energy_num;
    [SerializeField]
    protected  float food_num;
    [SerializeField]
    protected int type;
    [TextArea]
    public string infoText;


    public virtual void InsPlant(Vector3 position, List<GameObject> plantsList, int Random)
    {
        GameObject plant = Instantiate(plantPrefabe, position, Quaternion.identity);
        PlantData data = plant.AddComponent<PlantData>();
        plant.transform.GetComponent<Renderer>().material = materials[Random/materials.Length];
        data.energy = Random * energy_num;
        data.food = Random * food_num;
        data.mineral = Random * mineral_num;
        data.caijiRound = 0;
        data.type = type;
        plantsList.Add(plant);

    }
    public virtual void InsPlant(Vector3 position, List<GameObject> plantsList, PlantSaveData saveData)
    {
        GameObject plant = Instantiate(plantPrefabe, position, Quaternion.identity);
        PlantData data = plant.AddComponent<PlantData>();
        plant.transform.GetComponent<Renderer>().material = materials[0];
        data.energy = saveData.energy;
        data.food = saveData.food;
        data.mineral = saveData. mineral;
        data.caijiRound = saveData.caijiRound ;
        data.type = saveData.type;
        plantsList.Add(plant);

    }

    public virtual void InsPlant(Vector3 position, int Random)
    {
        
    }
}
