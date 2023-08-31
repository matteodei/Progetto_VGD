using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10; // Quantit� di danni inflitti al giocatore
    public float attackCooldown = 1.0f; // Tempo di attesa tra gli attacchi
    public float attackRange = 1.5f; // Distanza ravvicinata per l'attacco

    private Transform player; // Referenza al transform del giocatore
    private float lastAttackTime; // Momento dell'ultimo attacco

    private Animator enemyState;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastAttackTime = -attackCooldown; // Inizializza il timer per consentire il primo attacco
        enemyState = GetComponent<Animator>();
    }

    private void Update()
    {
        // Calcola la distanza tra nemico e giocatore
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!enemyState.GetBool("isDead"))
        {
            // Verifica se � passato il tempo di attesa e il giocatore � nella distanza di attacco
            if (Time.time - lastAttackTime >= attackCooldown && distanceToPlayer <= attackRange && enemyState.GetBool("isAttack"))
            {
                // Infliggi danni al giocatore
                PlayerHealt playerHealth = player.GetComponent<PlayerHealt>();
                if (playerHealth != null && !SettingsMenu.statoTrucchi)
                {
                    playerHealth.TakeEnemiesDamage(damageAmount);
                }

                lastAttackTime = Time.time; // Aggiorna il timer dell'ultimo attacco
            }
        }
    }
}
