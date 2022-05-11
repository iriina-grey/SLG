using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildEvent 
{
     void DoBuildEvent();
    float SpendToBuild();
    float CancelToBuild();
}
