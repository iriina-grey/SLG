using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlantFactory", menuName = "Map/Plant/Creat/PlantFactory")]
public class PlantFactory : ScriptableObject
{
    [SerializeField]
    Plant[] plants;
    
    


    public void CreatPlant(List<Vector3> positions, List<GameObject> plantsList, float InsChance)
    {
        if (Random.Range(0f, 1f) <= InsChance)
        {
            int type = Random.Range(0, plants.Length);
            Debug.Log(type);
            int resource = Random.Range(100, 1000);
            int wallNum = Random.Range(0, positions.Count);
            plants[type].InsPlant(positions[wallNum], plantsList, resource%4);
            
        }
    }
    public void CreatPlant(Vector3 positions, List<GameObject> plantsList,PlantSaveData data)
    {
        plants[data.type-1].InsPlant(positions, plantsList, data);
    }


}
