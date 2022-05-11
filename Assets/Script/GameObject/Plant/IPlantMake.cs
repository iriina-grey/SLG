using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlantMake 
{
    void InsPlant(Vector3 position, List<GameObject> plantsList, int Random);
    void InsPlant(Vector3 position, int Random);
}
