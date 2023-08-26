using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsoOggetti : MonoBehaviour
{
    public bool redgem;

    public GameObject GemmaRossaObj;
    public GameObject GemmaRossaCan;

    private void Start()
    {
        GemmaRossaCan.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           redgem = true;
            GemmaRossaObj.SetActive (false);
            GemmaRossaCan.SetActive(true);
        }
    }
}
