using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public GameObject[] enemiesSpawnPoints;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitVars()
    {
        enemiesSpawnPoints = GameObject.FindGameObjectsWithTag("enemySpawn");
    }

    private void InitAll()
    {
        InitObjects();
        InitVars();
    }

    private void SpawnEnemies()
    {
        foreach (var enemySpawnPoint in enemiesSpawnPoints)
        {
            int rand = (int)Random.Range(1f, 6f);
            if (rand > 1)
            {
                Instantiate(gm.ennemyPrefab, enemySpawnPoint.transform.position, Quaternion.identity);

            }
            Destroy(go);
        }
    }

    private void Start()
    {
        InitAll();
        SpawnEnemies();
    }
}