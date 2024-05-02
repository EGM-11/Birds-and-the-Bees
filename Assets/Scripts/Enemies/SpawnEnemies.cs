using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemy;
    private float randomPosX;
    private float randomPosY;
    private Vector2 enemySpawnPos;
    private float spawnInterval = 5;
    private float spawnCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        //declaring the starting spawn position
        randomPosX = Random.Range(-15,15);
        randomPosY = Random.Range(-15,15);
        enemySpawnPos = new Vector2(randomPosX,randomPosY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
        yield return new WaitForSeconds(spawnInterval);

        spawnCount = Random.Range(4,8);

        for (int i = 0; i < spawnCount; i++)
        {
            //spawns a random amount of enemies in random positions
            Instantiate(enemy, enemySpawnPos, Quaternion.identity);
            randomPosX = Random.Range(-15,15);
            randomPosY = Random.Range(-15,15);
            enemySpawnPos = new Vector2(randomPosX,randomPosY);
        }
        //makes the spawn interval shorter after every wave
        spawnInterval = spawnInterval - 0.2f;
        if (spawnInterval < 3.4f)
        {
            spawnInterval = 3.4f;
        }
        Debug.Log("spawned" + spawnCount);
        }
    }
}
