using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealt : MonoBehaviour
{
    public int health = 100;
    private Animator stateHealt;
    private NavMeshAgent enemy;

    private bool isTakingDamage = false;
    private float damageCooldown = 0.5f; // Tempo di cooldown tra i danni
    private float lastDamageTime = 0f; // Memorizza il tempo dell'ultimo danno

    private void Start()
    {
        stateHealt = GetComponent<Animator>();
    }

    private void Update()
    {

        enemy = GetComponent<NavMeshAgent>();
        stateHealt = GetComponent<Animator>();
        // Controllo per reimpostare lo stato solo dopo il cooldown
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            stateHealt.SetBool("isDamage", false);
            isTakingDamage = false;
        }

    }

    public void TakeDamage(int damage)
    {
        if (!isTakingDamage)
        {
            health -= damage;
            stateHealt.SetBool("isDamage", true);
            isTakingDamage = true;
            enemy.isStopped = true;
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
        stateHealt.SetBool("isDamage", false);
        isTakingDamage = false;
        enemy.isStopped = false;
    }

    void Die()
    {
        stateHealt.SetBool("isDead", true);
        // Implementa qui il comportamento quando il nemico muore
    }

    public void DieAnimationFinished()
    {
        Destroy(this.gameObject);
    }
}
