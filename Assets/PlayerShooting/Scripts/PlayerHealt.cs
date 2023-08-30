using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealt : MonoBehaviour
{
    public int maxHealth = 100;
    public AudioSource _healingSound;
    public int currentHealth;
    public Collider player;
    public Image barraVita;
    public TMP_Text vita;
    private void Start()
    {
        currentHealth = maxHealth;
     ;
    }
    private void Update()
    {

        if (SettingsMenu.statoTrucchi)
        {
            vita.text = "INF";
        }
        else
        {
            OnTriggerStay(player);
            barraDellaVita();
            vita.text = currentHealth.ToString();
        }
        
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

            if (Input.GetKeyDown(KeyCode.E) && currentHealth < 100 )
            {
                _healingSound.Play();
                print("Cura");
                currentHealth += 50;
                if(currentHealth >= maxHealth){
                currentHealth = maxHealth;
                    
                }
                other.gameObject.SetActive(false);

            }

        }


    }

    public void barraDellaVita()
    {
        barraVita.fillAmount = currentHealth / 100f;
    }
}

