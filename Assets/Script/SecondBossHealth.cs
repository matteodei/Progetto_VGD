using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SecondBossHealth : MonoBehaviour
{

    public int health = 100;
    private Animator stateHealt;
    private NavMeshAgent enemy;
    private bool isTakingDamage = false;
    private float damageCooldown = 0.1f; // Tempo di cooldown tra i danni
    private float lastDamageTime = 0f; // Memorizza il tempo dell'ultimo danno

    public static int bossMorti = 0;
    private void Start()
    {
        stateHealt = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        // Controllo per reimpostare lo stato solo dopo il cooldown
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            stateHealt.SetBool("isHit", false);
            isTakingDamage = false;
        }

        if (bossMorti == 2)
        {
            SceneManager.LoadScene("Fine_gioco_vittoria");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            bossMorti = 0;

        }
    }

    public void TakeDamage(int damage)
    {
        if (!isTakingDamage)
        {
            health -= damage;
            stateHealt.SetBool("isHit", true);
            isTakingDamage = true;
            enemy.isStopped = true;
            enemy.velocity = Vector3.zero;
            lastDamageTime = Time.time; // Aggiorna il tempo dell'ultimo danno

            if (health <= 0)
            {
                
                Die();
                
            }
        }
    }

    public void DamageAnimationFinished()
    {
        // Questo metodo viene chiamato dall'animazione quando � finita
        stateHealt.SetBool("isHit", false);
        isTakingDamage = false;
        enemy.isStopped = false;
    }

    void Die()
    {
        stateHealt.SetBool("isDead", true);
        enemy.isStopped = true;
        enemy.velocity = Vector3.zero;
        
       
    }

    public void DieAnimationFinished()
    {
        bossMorti++;
        
        Destroy(this.gameObject);
    }
}
