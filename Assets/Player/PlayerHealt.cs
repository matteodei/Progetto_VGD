using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealt : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool healed;
    public Collider player;
    public Image barraVita;
    public TMP_Text vita;
    private void Start()
    {
        currentHealth = maxHealth;
        healed = false;
    }
    private void Update()
    {
        OnTriggerStay(player);
        barraDellaVita();
        vita.text = currentHealth.ToString();
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

    private void OnTriggerStay(Collider other)
    {

         if (other.CompareTag("HealtZone"))
        {

            if (Input.GetKeyDown(KeyCode.E) && healed == false && currentHealth < 75)
            {
                print("Cura");
                currentHealth = 75;
                healed = true;

            }

        }


    }

    public void barraDellaVita()
    {
        barraVita.fillAmount = currentHealth / 100f;
    }
}

