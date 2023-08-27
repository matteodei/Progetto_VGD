using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeEnemiesDamage(int damage)
    {
        if (currentHealth > 0) 
        {
            Debug.Log("Danno, vita rimanente:" + currentHealth);
            currentHealth -= damage;
        }
        else
        {
            //GAMEOVER
            Debug.Log("Giocatore morto");
        }
        // Aggiungi qui la logica per gestire la morte del giocatore se la salute raggiunge zero
    }
}

