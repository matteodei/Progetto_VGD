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

    public GameObject bossPhase2Prefab; // Prefab per la seconda fase del boss

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
            stateBoss.SetBool("isDamage", false);
            isTakingDamage = false;
        }

        if (health <= 0 && !bosscreati)
        {
            SecondPhase();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isTakingDamage)
        {
            health -= damage;
            stateBoss.SetBool("isDamage", true);
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
        stateBoss.SetBool("isDamage", false);
        isTakingDamage = false;
        boss.isStopped = false;
    }

    void Die()
    {
        stateBoss.SetBool("isDead", true);
        boss.isStopped = true;
        boss.velocity = Vector3.zero;
    }

    public void DieAnimationFinished()
    {
        Destroy(this.gameObject);
    }

    public void SecondPhase()
    {
        Die();
        Instantiate(bossPhase2Prefab, transform.position, Quaternion.identity);
        Instantiate(bossPhase2Prefab, transform.position, Quaternion.identity);
        bosscreati = true;
    }
}
