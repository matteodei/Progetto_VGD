using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsoOggetti : MonoBehaviour
{
    public bool redgem;
    public bool bluegem;
    public bool dooropen;
    

    public bool redgemalt;
    public bool bluegemalt;

    

    public GameObject GemmaRossaAlt;
    public GameObject GemmaRossaCan;
    public GameObject GemmaRossa;

    public GameObject GemmaBluAlt;
    public GameObject GemmaBluCan;
    public GameObject GemmaBlu;

    public GameObject antaDestra;
    public GameObject antaSinistra;
    public GameObject antaDestraAperta;
    public GameObject antaSinistraAperta;

    public GameObject consegnaGem;
    public GameObject consegnaRossa;
    public GameObject consegnaBlu;
    public GameObject consegnaAlt;

   
    


    public Collider player;

    private void Start()
    {
       
        GemmaRossaCan.SetActive(false);
        GemmaRossaAlt.SetActive(false);
        GemmaBluCan.SetActive(false);
        GemmaBluAlt.SetActive(false);
        antaDestraAperta.SetActive(false);
        antaSinistraAperta.SetActive(false);
        consegnaGem.SetActive(true);
        consegnaRossa.SetActive(false);
        consegnaBlu.SetActive(false);
        consegnaAlt.SetActive(false);
        dooropen = false;
       // healed = false;




    }

    private void Update()
    {
        OnTriggerStay(player);
        OnTriggerEnter(player);

        if (dooropen == false)
            apriPorta();

        if (Time.timeScale == 0)
        {
            GemmaBluCan.SetActive(false);
            GemmaRossaCan.SetActive(false);
        }
        else
        {
            if (redgem == true && bluegem == true)
            {
                GemmaBluCan.SetActive(true);
                GemmaRossaCan.SetActive(true);
            }
            else if (redgem == false && bluegem == true)
            {
                GemmaBluCan.SetActive(true);
                GemmaRossaCan.SetActive(false);

            }
            else if (redgem == true && bluegem == false)
            {
                GemmaBluCan.SetActive(false);
                GemmaRossaCan.SetActive(true);
            }
        }
        if (Time.timeScale == 0)
        {
            consegnaGem.SetActive(false);
            consegnaRossa.SetActive(false);
            consegnaBlu.SetActive(false);
            consegnaAlt.SetActive(false);
        }
        else
        {
            if (bluegem == false && redgem == false && bluegemalt == false && redgemalt == false && dooropen == false)
            {
                consegnaGem.SetActive(true);
                consegnaRossa.SetActive(false);
                consegnaBlu.SetActive(false);
                consegnaAlt.SetActive(false);
            }
            else if (bluegem == true && redgem == false && bluegemalt == false && redgemalt == false)
            {
                consegnaGem.SetActive(false);
                consegnaRossa.SetActive(true);
                consegnaBlu.SetActive(false);
                consegnaAlt.SetActive(false);
            }
            else if (bluegem == false && redgem == true && bluegemalt == false && redgemalt == false)
            {
                consegnaGem.SetActive(false);
                consegnaRossa.SetActive(false);
                consegnaBlu.SetActive(true);
                consegnaAlt.SetActive(false);
            }
            else if ((bluegem == true || redgem == true) && (bluegemalt == true || redgemalt == true))
            {
                consegnaGem.SetActive(false);
                consegnaRossa.SetActive(false);
                consegnaBlu.SetActive(false);
                consegnaAlt.SetActive(true);
            }
            else if (bluegem == false && redgem == false && bluegemalt == false && redgemalt == false && dooropen == true)
            {
                consegnaGem.SetActive(false);
                consegnaRossa.SetActive(false);
                consegnaBlu.SetActive(false);
                consegnaAlt.SetActive(false);
            }
            else if (bluegem == true && redgem == true && bluegemalt == false && redgemalt == false)
            {
                consegnaGem.SetActive(false);
                consegnaRossa.SetActive(false);
                consegnaBlu.SetActive(false);
                consegnaAlt.SetActive(true);
            }






        }
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
                if (bluegem == false)
                {
                    consegnaBlu.SetActive(true);
                    consegnaGem.SetActive(false);

                }

                else
                {
                    consegnaBlu.SetActive(false);
                    consegnaRossa.SetActive(false);
                    consegnaAlt.SetActive(true);
                    consegnaGem.SetActive(false);
                }


            }
        }
        else if (other.CompareTag("ZonaGemmaBlu"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GemmaBlu.SetActive(false);
                GemmaBluCan.SetActive(true);
                bluegem = true;
                if (redgem == false)
                {
                    consegnaRossa.SetActive(true);
                    consegnaGem.SetActive(false);

                }
                    
                else
                {
                    consegnaBlu.SetActive(false);
                    consegnaRossa.SetActive(false);
                    consegnaAlt.SetActive(true);
                    consegnaGem.SetActive(false);
                }
                    
                    
            }
        }
        else if (other.CompareTag("AltareRosso"))
        {
            if (Input.GetKeyDown(KeyCode.E) && redgem == true)
            {
                GemmaRossaAlt.SetActive(true);
                GemmaRossaCan.SetActive(false);
                redgemalt = true;
                redgem = false;
                if (bluegemalt == true)
                    consegnaAlt.SetActive(false);
            }
        }
        else if (other.CompareTag("AltareBlu"))
        {
            if (Input.GetKeyDown(KeyCode.E) && bluegem == true)
            {
                GemmaBluAlt.SetActive(true);
                GemmaBluCan.SetActive(false);
                bluegemalt = true;
                bluegem = false;
                if (redgemalt == true)
                    consegnaAlt.SetActive(false);
            }
        }
       /* else if (other.CompareTag("HealtZone"))
        {
           
            if (Input.GetKeyDown(KeyCode.E) && healed == false)
            {
                print("Cura");
                healt.currentHealth = 75;
                healed = true;
            }

        }*/

        
    }

    private void apriPorta()
    {
        if (redgemalt == true && bluegemalt == true)
        {
            antaSinistraAperta.SetActive(true);
            antaDestraAperta.SetActive(true);
            antaDestra.SetActive(false);
            antaSinistra.SetActive(false);
            
            dooropen = true;
        }
    }



}
