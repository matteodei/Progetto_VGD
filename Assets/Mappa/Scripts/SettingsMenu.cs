using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;
using Unity.VisualScripting;

public class SettingsMenu : MonoBehaviour
{
   
    public GameObject fullscreen;
    public GameObject volume;
    public GameObject grafica;
    public GameObject risoluzione;
    public GameObject bottoneSetting;
    public GameObject bottoneResume;

    public bool menuScelta;
    public bool menuSetting;

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropdown;




    // Start is called before the first frame update
    void Start()
    {
        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        { 
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height);
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
                scelta();
                menuScelta = true;
            }
            else if (menuScelta == true && menuSetting == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Gioco();
                menuSetting = false;
                menuScelta = false;
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
        fullscreen.SetActive(true);
        volume.SetActive(true);
        grafica.SetActive(true);
        risoluzione.SetActive(true);
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
        menuSetting = true;
    }

    public void scelta()
    {
        bottoneSetting.SetActive(true);
        bottoneResume.SetActive(true);
        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
    }

    public void Gioco()
    {

        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
        bottoneSetting.SetActive(false);
        bottoneResume.SetActive(false);
    }




}
 