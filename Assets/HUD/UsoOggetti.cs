using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsoOggetti : MonoBehaviour
{
    public bool redgem;

    public GameObject GemmaRossaObj;
    public GameObject GemmaRossaCan;
    public GameObject prova;
    

    private void Start()
    {
       
        GemmaRossaCan.SetActive(false);
        prova.SetActive(false);
       
    }

    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gemma"))
        {

            
            GemmaRossaObj.SetActive(false);
            GemmaRossaCan.SetActive(true);
            redgem = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        {
            
              if (Input.GetKeyDown(KeyCode.C) && redgem == true)
               {
                print("Stai premendo C");
                prova.SetActive(true);
               }
         
        }
    }



}
