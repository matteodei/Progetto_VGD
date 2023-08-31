using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MenuIniziale : MonoBehaviour
{


    
    public GameObject volume;
    public GameObject testi;
    public GameObject newGame;
    public GameObject loadGame;
    public GameObject option;
    public GameObject quit;
    public GameObject back;
    public GameObject fullScreenOn;
    public GameObject fullScreenOff;
    public GameObject menuGrafica;
    public GameObject tastiRisoluzione;
    public GameObject tastiGrafica;
    public GameObject menuRisoluzione;
    public GameObject livelli;
    public GameObject bottoneLivelli;

    public AudioMixer audioMixer;

    public bool schermoIntero;


    // Start is called before the first frame update
    void Start()
    {

        
        volume.SetActive(false);
        testi.SetActive(false);
        back.SetActive(false);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(false);
        menuGrafica.SetActive(false);
        fullScreenOn.SetActive(false);
        fullScreenOff.SetActive(false);
        livelli.SetActive(true);
        bottoneLivelli.SetActive(false);



        testi.SetActive(false);




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    
    

    public void setting()
    {
        testi.SetActive(true);
        volume.SetActive(true);
        newGame.SetActive(false);
        loadGame.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);
        back.SetActive(true);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);
        menuGrafica.SetActive(true);
        fullScreenOff.SetActive(true);
        fullScreenOn.SetActive(false);
        livelli.SetActive(false);
        bottoneLivelli.SetActive(false);
    }

    public void menu()
    {
        testi.SetActive(false);
        volume.SetActive(false);
        newGame.SetActive(true);
        loadGame.SetActive(true);
        option.SetActive(true);
        quit.SetActive(true);
        back.SetActive(false);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(false);
        menuGrafica.SetActive(false);
        fullScreenOn.SetActive(false);
        fullScreenOff.SetActive(false);
        livelli.SetActive(true);
        bottoneLivelli.SetActive(false);

    }

    public void inizia() 
    {
        SceneManager.LoadScene("Scene_matteo");
    }


    public void NewGame()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("CurrentLevel", 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));

       
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SettingsMenu.scenaAttuale);
        Time.timeScale = 1;



    }

    public void sceltaLivello()
    {
        testi.SetActive(false);
        volume.SetActive(false);
        newGame.SetActive(false);
        loadGame.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);
        back.SetActive(true);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(false);
        menuGrafica.SetActive(false);
        fullScreenOn.SetActive(false);
        fullScreenOff.SetActive(false);
        bottoneLivelli.SetActive(true);
        livelli.SetActive(false);
        
    }

    public void firstLevel()
    {
        SceneManager.LoadScene("MappaUno");
    }

    public void secondLevel()
    {
        SceneManager.LoadScene("MappaDue");
    }

    public void thirdLevel()
    {
        SceneManager.LoadScene("MappaTre");
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
            Screen.fullScreen = schermoIntero;
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

    public void Quit()
    {
        Application.Quit();
    }



}
