using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyFactory", menuName = "Map/Enemy/Creat/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField]
    GameObject[] enemyPrefab;

    public void EnemyIns(int level,Vector3 position,List<GameObject> enemys)
    {
        GameObject enemyIns = Instantiate(enemyPrefab[level], position, Quaternion.identity);

        enemyIns.GetComponent<Enemy>().level = level;
        enemys.Add(enemyIns);
    }
}
