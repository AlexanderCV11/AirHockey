/*si la porteria es enemiga, la variable ply_ai es "true" y se espera qu en esta porteria (enemiga) entre la ficha del jugador*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool ply_ai; //variable para saber si es porteria aliada o enemiga. Verdaderon para aliada, falso para enemiga
    public ScoreManager score;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ply_ai)
        {
            if (collision.tag == "AI")
            {
                collision.GetComponent<AILaunch>().Reset();
                score.AddPointEnemy();
            }
        }
        else
        {
            
            if (collision.tag == "Ficha")
            {
                collision.GetComponent<Ficha>().Reset();
                score.AddPointPlayer();
            }
        }
    }
}
