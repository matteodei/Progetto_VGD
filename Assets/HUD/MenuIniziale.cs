using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MenùIniziale : MonoBehaviour
{


    public GameObject fullscreen;
    public GameObject volume;
    public GameObject grafica;
    public GameObject risoluzione;
    public GameObject testi;
    public GameObject newGame;
    public GameObject loadGame;
    public GameObject option;
    public GameObject quit;
    public GameObject back;

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
        testi.SetActive(false);
        back.SetActive(false);

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
        testi.SetActive(true);
        fullscreen.SetActive(true);
        volume.SetActive(true);
        grafica.SetActive(true);
        risoluzione.SetActive(true);
        newGame.SetActive(false);
        loadGame.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);
        back.SetActive(true);
    }

    public void menù()
    {
        testi.SetActive(false);
        fullscreen.SetActive(false);
        volume.SetActive(false);
        grafica.SetActive(false);
        risoluzione.SetActive(false);
        newGame.SetActive(true);
        loadGame.SetActive(true);
        option.SetActive(true);
        quit.SetActive(true);
        back.SetActive(false);
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
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));

        
    }

}
