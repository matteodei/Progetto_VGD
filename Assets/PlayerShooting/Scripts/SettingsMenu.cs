using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
   
    
    public GameObject volume;
    public GameObject bottoneSetting;
    public GameObject bottoneResume;
    public GameObject bottoneMenu;
    public GameObject bottoneBack;
    public GameObject testi;
    public GameObject CanvasGame;
    public GameObject barraDellaVita;
    public GameObject tastiGrafica;
    public GameObject menuGrafica;
    public GameObject tastiRisoluzione;
    public GameObject menuRisoluzione;
    public GameObject fullScreenOn;
    public GameObject fullScreenOff;
    public GameObject cheatOn;
    public GameObject cheatOff;
    


    public bool schermoIntero;
    public bool menuScelta;
    public bool menuSetting;
    public static bool statoTrucchi;

    

    private bool isPaused = false;

    public AudioMixer audioMixer;

    




    // Start is called before the first frame update
    void Start()
    {
        barraDellaVita.SetActive(true);
        volume.SetActive(false);
        
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenu.SetActive(false);
        bottoneBack.SetActive(false);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(false);
        menuGrafica.SetActive(false);
        fullScreenOn.SetActive(false);
        fullScreenOff.SetActive(false);
        cheatOn.SetActive(false);
        cheatOff.SetActive(false);

        testi.SetActive(false);
        CanvasGame.SetActive(true);

        

  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            
            if (menuScelta == false && menuSetting == false)
            {
                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                CanvasGame.SetActive(false);
                scelta();
                menuScelta = true;
                Pause();
            }
            else if (menuScelta == true && menuSetting == false)
            {
                
                Gioco();
                menuSetting = false;
                menuScelta = false;
                Pause();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (menuScelta == true && menuSetting == true)
            {

                scelta();
                menuScelta = true;
                menuSetting = false;
                
            }

        }

        if(menuScelta && menuSetting)
        {
            if (statoTrucchi)
            {
                cheatOn.SetActive(true);
                cheatOff.SetActive(false);
            }
            else
            {
                cheatOn.SetActive(false);
                cheatOff.SetActive(true);
            }
        }



       
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    
    public void setting()
    {
        barraDellaVita.SetActive(false);
        testi.SetActive(true);
        
        volume.SetActive(true);
        
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenu.SetActive(false);
        bottoneBack.SetActive(true);
        menuSetting = true;
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);
        menuGrafica.SetActive(true);
        fullScreenOff.SetActive(true);
        fullScreenOn.SetActive(false);
      
    }

    public void scelta()
    {
        barraDellaVita.SetActive(false);
        testi.SetActive(false);
        bottoneMenu.SetActive(true);
        bottoneSetting.SetActive(true);
        bottoneResume.SetActive(true);
        bottoneBack.SetActive(false);
       
        volume.SetActive(false);
       
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(false);
        menuGrafica.SetActive(false);
        menuSetting = false;
        fullScreenOn.SetActive(false);
        fullScreenOff.SetActive(false);
        cheatOn.SetActive(false);
        cheatOff.SetActive(false);


    }

    public void Gioco()
    {

        CanvasGame.SetActive(true);
        barraDellaVita.SetActive(true);
        testi.SetActive(false);
        
        volume.SetActive(false);
        
       
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenu.SetActive(false);
        bottoneBack.SetActive(false);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(false);
        menuGrafica.SetActive(false);
        fullScreenOn.SetActive(false);
        fullScreenOff.SetActive(false);
        cheatOn.SetActive(false);
        cheatOff.SetActive(false);

    }


    public void Pause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Mette in pausa il tempo di gioco
            
        }
        else
        {
            Time.timeScale = 1; // Ripristina il tempo di gioco normale
            
        }
    }

    

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CanvasGame.SetActive(true);
        barraDellaVita.SetActive(true);
        testi.SetActive(false);
        
        volume.SetActive(false);
        
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenu.SetActive(false);
        bottoneBack.SetActive(false);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(false);
        menuGrafica.SetActive(false);
        fullScreenOn.SetActive(false);
        fullScreenOff.SetActive(false);
        cheatOn.SetActive(false);
        cheatOff.SetActive(false);

        Pause();

        menuScelta = false;

        
            

    }

    public void menu()
    { 
        SceneManager.LoadScene("Menu_iniziale");
    }

    public void graphicMenu()
    {
        tastiGrafica.SetActive(true);
        menuGrafica.SetActive(false);

    }
    public void setGraphicLow()
    {
        QualitySettings.SetQualityLevel(0);
        tastiGrafica.SetActive(false);
        menuGrafica.SetActive(true);
    }

    public void setGraphicMid()
    {
        QualitySettings.SetQualityLevel(1);
        tastiGrafica.SetActive(false);
        menuGrafica.SetActive(true);
    }

    public void setGraphicHigh()
    {
        QualitySettings.SetQualityLevel(2);
        tastiGrafica.SetActive(false);
        menuGrafica.SetActive(true);
    }

    public void resolutionMenu()
    {
        tastiRisoluzione.SetActive(true);
        menuRisoluzione.SetActive(false);
    }

    public void setRes1()
    {
        Screen.SetResolution(720, 480, true);
        schermoIntero = true;
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);
        fullScreenOn.SetActive(true);
        fullScreenOff.SetActive(false);

    }

    public void setRes2()
    {
        Screen.SetResolution(1024, 768, true);
        schermoIntero = true;
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);
        fullScreenOn.SetActive(true);
        fullScreenOff.SetActive(false);

    }

    public void setRes3()
    {
        Screen.SetResolution(1440, 900, true);
        schermoIntero = true;
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);
        fullScreenOn.SetActive(true);
        fullScreenOff.SetActive(false);

    }

    public void setRes4()
    {
        Screen.SetResolution(1920, 1080, true);
        schermoIntero = true;
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);
        fullScreenOn.SetActive(true);
        fullScreenOff.SetActive(false);
        
    }

    public void SetFullScreen()
    {
        
        if (schermoIntero == false)
        {
            schermoIntero = true;
            Screen.fullScreen = schermoIntero ;
            fullScreenOn.SetActive(true);
            fullScreenOff.SetActive(false);
           
        }

        else
        {
            schermoIntero = false;
            Screen.fullScreen = schermoIntero;
            fullScreenOn.SetActive(false);
            fullScreenOff.SetActive(true);
            
        }

    }


    public void SetCheat()
    {
        if (statoTrucchi == false)
        {
            statoTrucchi = true;
            cheatOn.SetActive(true);
            cheatOff.SetActive(false);

        }

        else
        {
            statoTrucchi = false;
            cheatOn.SetActive(false);
            cheatOff.SetActive(true);

        }
    }







}
