using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float spawnRangeX1 = -3.5f; //
    private float spawnRangeX2 = 3.5f; //
    private float spawnRangeZ1 = 4.5f; //8-12
    private float spawnRangeZ2 = 6.5f; //8-12

    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnEnemies()
    {

        int enemiesIndex = Random.Range(0, enemies.Count);
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX1, spawnRangeX2),2, Random.Range(spawnRangeZ1, spawnRangeZ2));

        Instantiate(enemies[enemiesIndex], spawnPos, enemies[enemiesIndex].transform.rotation);
    }
}
