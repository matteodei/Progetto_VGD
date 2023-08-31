using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public string scenename;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(scenename);
        }
    }

    public void apriMenu(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void riprova()
    {
        SceneManager.LoadScene(SettingsMenu.scenaAttuale);
        Time.timeScale = 1;
    }

}
