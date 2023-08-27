
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform[] pathEnemy;
    private int pathEnemyIndex;
    private int index;
    private Vector3 actualCpTarget;

    private NavMeshAgent enemy;
    private Animator enemyState;


    private float distanceEnemyPlayer;

    [SerializeField] private float rangeAlert;
    [SerializeField] private float rangeAttack;

    private float waitTime;
    private float initWaitTime = 1f;

    public GameObject playerTarget;
    private float damageAttack;
    private Vector3 playerPos;




    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemyState = GetComponent<Animator>();
        waitTime = initWaitTime;
        pathEnemyIndex = Random.Range(0, pathEnemy.Length);
    }

    // Update is called once per frame
    void Update()
    {
        ResetAnimation(enemyState);

        if (true)  // bisogna metterci il controllo della vita del player
        {
            playerPos = playerTarget.transform.position;
        }

        //if(healt.healt >0)
        //{
        float distance = Vector3.Distance(playerPos, transform.position);


        if (distance > rangeAlert)
        {
            idleStateMode();
        }
        else
        {
            followPlayer();
        }
        //}
        //else
        //{
        //  nemico morto
        //}
    }

    private void idleStateMode()
    {
        enemy.SetDestination(pathEnemy[pathEnemyIndex].position);
        if (Vector3.Distance(transform.position, pathEnemy[pathEnemyIndex].position) < 10.0f)
        {

            if (waitTime <= 0)
            {
                pathEnemyIndex = Random.Range(0, pathEnemy.Length);
                waitTime = initWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    private void followPlayer()
    {
        distanceEnemyPlayer = Vector3.Distance(transform.position, playerPos);

        if (distanceEnemyPlayer < rangeAttack)
        {
            enemy.velocity = Vector3.zero;
            enemy.isStopped = true;
            enemyState.SetBool("isAlert", false);
            enemyState.SetBool("isAttack", true);
        }
        else if (distanceEnemyPlayer < rangeAlert)
        {
            enemy.isStopped = false;
            enemy.destination = playerPos;
            enemy.SetDestination(playerTarget.transform.position);
            enemyState.SetBool("isAlert", true);
        }
    }

    private void ResetAnimation(Animator animator)
    {
        animator.SetBool("isAlert", false);
        animator.SetBool("isAttack", false);
    }


}
