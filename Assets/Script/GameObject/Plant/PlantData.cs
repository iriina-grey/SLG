using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantData : MonoBehaviour
{
    public float energy { get; set; }
    public float mineral { get ; set ; }
    public float food { get ; set ; }
    public int type { get; set; }
    public int caijiRound;
    
    public float[] GetValue()
    {
        float[] values = new float[4];
        values[0] = this.food;
        values[1] = this.energy;
        values[2] = this.mineral;
        values[3] = 0;
        return values;

    }
}
