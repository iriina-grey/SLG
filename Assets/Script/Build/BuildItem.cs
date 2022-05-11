using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildItem : ScriptableObject, IBuildEvent
{

    public  float spend;
    public int round;
    public string buildName;

    public string type;

    
    public virtual float CancelToBuild()
    {
        return -spend;
    }

    public  virtual void DoBuildEvent()
    {
        GameObject.Find("ValueOfGame").transform.GetComponent<GameDataValue>().BuildValue_NumChange(1, type);

    }

    public virtual float SpendToBuild()
    {
        return spend;
    }

    
}
