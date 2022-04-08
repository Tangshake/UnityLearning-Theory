using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 0.2f;

    [SerializeField]
    private List<GameObject> lEnemies;

    private float leftBound = -13.0f;
    private float rightBound = 13.0f;

    private void Start()
    {
        //StartCoroutine("SpawnEnemy");
        StartEnemySpawn();
    }

    private void SpawnEnemy()
    {
        var pos = Random.Range(leftBound, rightBound);
        var enemyIndex = Random.Range(0, lEnemies.Count);   //Max is exclusive sooo it should be safe.

        Instantiate(lEnemies[enemyIndex], new Vector3(pos, 20, 48), Quaternion.identity);
    }

    public void StartEnemySpawn()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
    }

    public void StopEnemySpawn()
    {
        CancelInvoke("SpawnEnemy");
    }
    
}
