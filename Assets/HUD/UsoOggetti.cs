using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsoOggetti : MonoBehaviour
{
    public bool redgem;
    public bool bluegem;

    

    public GameObject GemmaRossaAlt;
    public GameObject GemmaRossaCan;
    public GameObject GemmaRossa;

    public GameObject GemmaBluAlt;
    public GameObject GemmaBluCan;
    public GameObject GemmaBlu;


   // public GameObject prova;
    public Collider player;

    private void Start()
    {
       
        GemmaRossaCan.SetActive(false);
        GemmaRossaAlt.SetActive(false);
        GemmaBluCan.SetActive(false);
        GemmaBluAlt.SetActive(false);
        //prova.SetActive(false);
       
    }

    private void Update()
    {
        OnTriggerStay(player);
        OnTriggerEnter(player);
    }




    void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("ZonaGemmaRossa"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GemmaRossa.SetActive(false);
                GemmaRossaCan.SetActive(true);
                redgem = true;

            }
        }
        else if (other.CompareTag("ZonaGemmaBlu"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GemmaBlu.SetActive(false);
                GemmaBluCan.SetActive(true);
                bluegem = true;

            }
        }
        else if (other.CompareTag("AltareRosso"))
        {
            if (Input.GetKeyDown(KeyCode.E) && redgem == true)
            {
                GemmaRossaAlt.SetActive(true);
                GemmaRossaCan.SetActive(false);
            }
        }
        else if (other.CompareTag("AltareBlu"))
        {
            if (Input.GetKeyDown(KeyCode.E) && bluegem == true)
            {
                GemmaBluAlt.SetActive(true);
                GemmaBluCan.SetActive(false);

            }
            
          
        }



           /* if (Input.GetKeyDown(KeyCode.C) && redgem == true)
              { 
                    print("Stai premendo C");
                    prova.SetActive(true);
              
              }*/
         
        
    }



}
