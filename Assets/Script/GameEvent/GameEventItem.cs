using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventItem : ScriptableObject
{
    [TextArea]
    public string infoText;

    public float Value;

    public virtual void Event()
    {

    }
}
