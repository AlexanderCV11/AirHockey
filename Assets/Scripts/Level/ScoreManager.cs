using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int scoreEnemy = 0;
    private int scorePlayer = 0;
    public TextMeshProUGUI globalScore;

    private void Update()
    {
        globalScore.text = scoreEnemy + "_" + scorePlayer;
    }

    public void  AddPointEnemy()
    {
        scoreEnemy++;
    }

    public void AddPointPlayer()
    {
        scorePlayer++;
    }
}
