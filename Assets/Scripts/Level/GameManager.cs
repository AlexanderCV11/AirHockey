using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool startParty;
    public GameObject panelPowerUps;
    public AILaunch refAI;

    private void Start()
    {
        StartPowerUpsPanel();
        refAI = GameObject.FindAnyObjectByType<AILaunch>();
    }

    void StartPowerUpsPanel()
    {
        panelPowerUps.SetActive(true);
        Invoke("ClosePowerUpsPanel", 5.0f);
    }

    void ClosePowerUpsPanel()
    {
        panelPowerUps.SetActive(false);
        startParty = true;
        refAI.LaunchFicha();
    }
}
