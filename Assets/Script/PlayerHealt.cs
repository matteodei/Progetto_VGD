using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealt : MonoBehaviour
{
    public int maxHealth = 100;
    public AudioSource _healingSound;
    public int currentHealth;
    public Collider player;
    public Image barraVita;
    public TMP_Text vita;
    public static bool ArenaModeFlag = false;

    private void Start()
    {
        currentHealth = maxHealth;

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
           
            currentHealth -= damage;
        }
        else
        {
            SettingsMenu.scenaAttuale = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Fine_gioco_morte");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;



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

