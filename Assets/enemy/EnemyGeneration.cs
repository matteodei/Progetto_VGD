using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    private int randomIndexEnemy;
    private Vector3 randomIndexSpawner;

    private float waitTime;
    private float initWaitTime = 1f;

    public GameObject[] myEnemies;
    public Transform[] mySpawner;
    static private int nEnemies;
    public int maxEnemy;

    // Start is called before the first frame update
    void Start()
    {
        nEnemies = 0;
        randomIndexEnemy = 0;
        randomIndexSpawner = new Vector3();
        waitTime = initWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (nEnemies >= maxEnemy)
        {
            return;
        }
        if (waitTime<= 0)
        {
            randomIndexEnemy= Random.Range(0, myEnemies.Length);
            randomIndexSpawner = mySpawner[Random.Range(0, mySpawner.Length)].position;
            if (nEnemies<= 50)
            {
                Instantiate(myEnemies[randomIndexEnemy], randomIndexSpawner, Quaternion.identity);
                nEnemies++;
            }
            waitTime = initWaitTime;

        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public int GetNEnemy()
    {
        return nEnemies;
    }

    public int enemyKilled()
    {
        return nEnemies--;
    }

}
