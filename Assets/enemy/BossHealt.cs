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
    private bool firstDeath;
    private float damageCooldown = 0.1f; // Tempo di cooldown tra i danni
    private float lastDamageTime = 0f; // Memorizza il tempo dell'ultimo danno


    // Start is called before the first frame update
    void Start()
    {
        stateBoss = GetComponent<Animator>();
        boss = GetComponent<NavMeshAgent>();
        firstDeath = true; 
    }

    // Update is called once per frame
    void Update()
    {
        // Controllo per reimpostare lo stato solo dopo il cooldown
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            stateBoss.SetBool("isDamage", false);
            isTakingDamage = false;
        }

        if (firstDeath)
        {
            if (health <= 0)
            {
                SecondFase();
            }
        }else if (health<= 0)
        {
            Die();
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
            lastDamageTime = Time.time; // Aggiorna il tempo dell'ultimo danno

            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void DamageAnimationFinished()
    {
        // Questo metodo viene chiamato dall'animazione quando è finita
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

    public void SecondFase()
    {
        Die();
        Instantiate(this.gameObject, transform.position, Quaternion.identity);
        Instantiate(this.gameObject, transform.position, Quaternion.identity);
        firstDeath = false;
        health = 300;
    }
}
