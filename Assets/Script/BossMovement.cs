using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{

    private NavMeshAgent boss;
    private Animator bossState;

    [SerializeField] private float rangeAttack;

    public GameObject playerTarget;
    private Vector3 playerPos;

    private float distanceEnemyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<NavMeshAgent>();
        bossState = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetAnimation(bossState);

        if (true)  // bisogna metterci il controllo della vita del player
        {
            playerPos = playerTarget.transform.position;
        }

        float distance = Vector3.Distance(playerPos, transform.position);

        followPlayer();

    }

    private void followPlayer()
    {
        distanceEnemyPlayer = Vector3.Distance(transform.position, playerPos);

        if (distanceEnemyPlayer < rangeAttack)
        {
            boss.velocity = Vector3.zero;
            boss.isStopped = true;
            bossState.SetBool("isAttack", true);
            Debug.Log("nemico in attaco");
            Debug.Log(distanceEnemyPlayer.ToString());
        }
        else
        {
            boss.isStopped = false;
            boss.destination = playerPos;
            boss.SetDestination(playerTarget.transform.position);
            Debug.Log("Nemico ti sta inseguendo");
            Debug.Log(distanceEnemyPlayer.ToString());
        }

    }

    private void ResetAnimation(Animator animator)
    {
        animator.SetBool("isAttack", false);
    }

}
