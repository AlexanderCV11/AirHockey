using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashController : MonoBehaviour
{
    public int playerCashPoints = 100;
    public int enemyCashPoints;
    public TextMeshProUGUI uiCashpoints;

    public static CashController autoRef;
    
    private void Awake()
    {
        if (CashController.autoRef == null)
        {
            CashController.autoRef = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        uiCashpoints.text = "Points: " + playerCashPoints;
    }

    public void AddCashPointsToPlayer()
    {
        playerCashPoints += 100;
        uiCashpoints.text = "Points: " + playerCashPoints;
    }
}
