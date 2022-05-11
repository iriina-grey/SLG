using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOfPlayerController : Singleton<PartOfPlayerController>
{
    public GameObject moveArea;
    bool isOn = true;

    public void MoveAreaStateChange()
    {
        isOn = !isOn;
        moveArea.SetActive(isOn);
    }

}
