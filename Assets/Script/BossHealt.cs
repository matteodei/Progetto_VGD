using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossHealt : MonoBehaviour
{
    public int health;
    private Animator stateBoss;
    private NavMeshAgent boss;

    private bool isTakingDamage = false;
    private float damageCooldown = 0.1f;
    private float lastDamageTime = 0f;

    private bool bosscreati;

    public GameObject bossSecondPhase;
    public GameObject skeletonSecondPhase;

    void Start()
    {
        stateBoss = GetComponent<Animator>();
        boss = GetComponent<NavMeshAgent>();
        bosscreati = false;
    }

    void Update()
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            stateBoss.SetBool("isHit", false);
            isTakingDamage = false;
        }

        if (health <= 0 && !bosscreati)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isTakingDamage)
        {
            health -= damage;
            stateBoss.SetBool("isHit", true);
            isTakingDamage = true;
            boss.isStopped = true;
            boss.velocity = Vector3.zero;
            lastDamageTime = Time.time;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void DamageAnimationFinished()
    {
        stateBoss.SetBool("isHit", false);
        isTakingDamage = false;
        boss.isStopped = false;
    }

    void Die()
    {
        stateBoss.SetBool("isDead", true);
        boss.isStopped = true;
        boss.velocity = Vector3.zero;
        bosscreati = true;
    }

    public void DieAnimationFinished()
    {
        Destroy(this.gameObject);
        SecondPhase();
    }

    public void SecondPhase()
    {
        Instantiate(bossSecondPhase, transform.position , Quaternion.identity);
        Instantiate(bossSecondPhase, transform.position, Quaternion.identity);
        Instantiate(skeletonSecondPhase, transform.position, Quaternion.identity);
        Instantiate(skeletonSecondPhase, transform.position, Quaternion.identity);
        Instantiate(skeletonSecondPhase, transform.position, Quaternion.identity);
        Instantiate(skeletonSecondPhase, transform.position, Quaternion.identity);

    }
}
