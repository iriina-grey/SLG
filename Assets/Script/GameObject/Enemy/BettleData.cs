using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettleData : MonoBehaviour
{
    public List<GameObject> enemyList;

    private void Awake()
    {
        enemyList = new List<GameObject>();
    }
}
