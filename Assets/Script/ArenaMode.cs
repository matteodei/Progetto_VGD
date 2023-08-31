using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArenaMode : MonoBehaviour
{
    
    public GameObject portaAperta;
    public GameObject portaChiusa;
    public GameObject portaUscitaAperta;
    public GameObject portaUscitaChiusa;
    public Collider player;
    public static bool ArenaModeFlag = false;

    private void Start()
    {
        portaChiusa.SetActive(false);
        portaUscitaChiusa.SetActive(true);

    }
    private void Update()
    {
        if (ArenaModeFlag == true)
        {
            portaAperta.SetActive(false);
            portaChiusa.SetActive(true);
            portaUscitaAperta.SetActive(false);
            portaUscitaChiusa.SetActive(true);
        }
        if (ArenaModeFlag == false)
        {
            portaUscitaAperta.SetActive(true);
            portaUscitaChiusa.SetActive(false);

        }



    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArenaMode"))
        {
            ArenaModeFlag = true;
            Debug.Log("Arena");
            other.gameObject.SetActive(false);
        }
    }


}