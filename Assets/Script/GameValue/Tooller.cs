using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tooller 
{
    public int RandomValue_Get(int min,int max)
    {
        return Random.Range(min, max);
    }
    public float RandomValue_Get(float min, float max)
    {
        return Random.Range(min, max);
    }
    public void UI_TextAlpha(Transform text)
    {
        
    }
}
