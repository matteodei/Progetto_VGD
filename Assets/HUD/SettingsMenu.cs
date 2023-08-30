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
   
    public GameObject fullscreen;
    public GameObject volume;
    public GameObject grafica;
    public GameObject risoluzione;
    public GameObject bottoneSetting;
    public GameObject bottoneResume;
    public GameObject bottoneMenù;
    public GameObject bottoneBack;
    public GameObject testi;
    public GameObject CanvasGame;
    public GameObject barraDellaVita;
    public GameObject tastiGrafica;
    public GameObject menuGrafica;
    public GameObject tastiRisoluzione;
    public GameObject menuRisoluzione;

   

    public bool menuScelta;
    public bool menuSetting;

    private bool isPaused = false;

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropdown;




    // Start is called before the first frame update
    void Start()
    {
        barraDellaVita.SetActive(true);
        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenù.SetActive(false);
        bottoneBack.SetActive(false);
        tastiGrafica.SetActive(false);
        tastiRisoluzione.SetActive(false);
        
        testi.SetActive(false);
        CanvasGame.SetActive(true);


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        { 
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
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
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    { 
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    { 
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    

    public void setting()
    {
        barraDellaVita.SetActive(false);
        testi.SetActive(true);
        fullscreen.SetActive(true);
        volume.SetActive(true);
        grafica.SetActive(true);
        risoluzione.SetActive(true);
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenù.SetActive(false);
        bottoneBack.SetActive(true);
        menuSetting = true;
        

}

    public void scelta()
    {
        barraDellaVita.SetActive(false);
        testi.SetActive(false);
        bottoneMenù.SetActive(true);
        bottoneSetting.SetActive(true);
        bottoneResume.SetActive(true);
        bottoneBack.SetActive(false);
        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
        menuSetting = false;
    }

    public void Gioco()
    {

        CanvasGame.SetActive(true);
        barraDellaVita.SetActive(true);
        testi.SetActive(false);
        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenù.SetActive(false);
        bottoneBack.SetActive(false);
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
        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneMenù.SetActive(false);
        bottoneBack.SetActive(false);

        Pause();

        menuScelta = false;


    }

    public void menù()
    { 
        SceneManager.LoadScene("Menù_iniziale");
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
        SetFullScreen(true);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);
    }

    public void setRes2()
    {
        Screen.SetResolution(1024, 768, true);
        SetFullScreen(true);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);

    }

    public void setRes3()
    {
        Screen.SetResolution(1440, 900, true);
        SetFullScreen(true);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);

    }

    public void setRes4()
    {
        Screen.SetResolution(1920, 1080, true);
        SetFullScreen(true);
        tastiRisoluzione.SetActive(false);
        menuRisoluzione.SetActive(true);


    }





}
 