using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Science/Item/ScienceItem", fileName = "ScienceItem")]
public class ScienceItem : ScriptableObject
{
    public string ScienceName;
    [TextArea]
    public string Infotext;

    public int round;
    public int level;

    public virtual void DoEvent()
    {

    }
}
