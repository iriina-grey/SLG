using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlantCreaterFactory
{
     void CreatPlant(List<Vector3> vectors, List<PlantData> plantsList,float InsChance);
}
