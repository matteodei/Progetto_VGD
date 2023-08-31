using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneration : MonoBehaviour
{
    private int randomIndexEnemy;
    private Vector3 randomIndexSpawner;
    private Vector3 Spawn1 = new Vector3();
    private Vector3 Spawn2 = new Vector3();

    private float waitTime;
    private float initWaitTime = 1f;

    private float tempoTrascorso = 0f;
    public float tempoMax = 10f;

    public GameObject[] myEnemies;
    public Transform[] mySpawner;
    static private int nEnemies;
    public int maxEnemy;

    public TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        nEnemies = 0;
        randomIndexEnemy = 0;
        randomIndexSpawner = new Vector3();
        waitTime = initWaitTime;
        Spawn1 = mySpawner[14].position;
        Spawn2 = mySpawner[15].position;
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = tempoTrascorso.ToString();

        if (ArenaMode.ArenaModeFlag == false)
        {
            if (nEnemies >= maxEnemy)
            {
                return;
            }
            if (waitTime <= 0)
            {
                randomIndexEnemy = Random.Range(0, myEnemies.Length);
                randomIndexSpawner = mySpawner[Random.Range(0, 13)].position;
                if (nEnemies <= 50)
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

        else
        {
            if (Time.timeScale == 1)
            {
                tempoTrascorso += Time.deltaTime;
                if (tempoTrascorso >= tempoMax)
                {
                    ArenaMode.ArenaModeFlag = false;
                }


                if (waitTime <= 0)
                {

                    Debug.Log("spawn");
                    Instantiate(myEnemies[randomIndexEnemy], Spawn1, Quaternion.identity);
                    Instantiate(myEnemies[randomIndexEnemy], Spawn1, Quaternion.identity);
                    Instantiate(myEnemies[randomIndexEnemy], Spawn2, Quaternion.identity);
                    Instantiate(myEnemies[randomIndexEnemy], Spawn2, Quaternion.identity);
                    nEnemies++;
                    initWaitTime = 15f;
                    waitTime = initWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
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
