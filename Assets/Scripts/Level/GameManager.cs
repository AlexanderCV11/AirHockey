using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    /*variables de partida*/
    public bool startParty; //booleano que indica cuando empieza la partida
    public GameObject panelPowerUps; //referencia a el panel de compra de power ups
    public AILaunch refAI; //referencia de la ficha enemiga
    public Ficha refPlayer; //referencia de la ficha del player
    public GameObject rock;

    /*variables de score*/
    private int scoreEnemy = 0; //score del enemigo
    private int scorePlayer = 0; //score del jugador
    public int playerCash; //dinero del jugador
    public int enemyCash; //dinero del enemigo
    public TextMeshProUGUI globalScore; //texto de score
    public TextMeshProUGUI uiCashPoints; //texto de puntos para comprar power ups

    private void Start()
    {
        StartPowerUpsPanel(); //despligue de panel de power ups
        refAI = GameObject.FindAnyObjectByType<AILaunch>(); //encontrar referencia del objeto en escena que tenga el Script de "AILaunch"
        refPlayer = GameObject.FindAnyObjectByType<Ficha>(); //encontrar referencia del objeto en escena que tenga el Script de "AILaunch"
        rock.SetActive(false);
    }


    /*funcion que despliega panel de power ups*/
    void StartPowerUpsPanel()
    {
        uiCashPoints.text = "Points: " + playerCash; //actualizar el numero de dinero que tiene disponible el jugador
        panelPowerUps.SetActive(true); //activar el panel
        Invoke("ClosePowerUpsPanel", 5.0f); //llamar a la funcion que cierra el panel dentro de 5 segundos
    }

    /*funcion que cierra panel de power ups*/
    void ClosePowerUpsPanel()
    {
        panelPowerUps.SetActive(false); //desactivar el panel de power ups
        startParty = true; //empieza el juego 
        refAI.LaunchFicha(); //llamado de la funcion de la IA que lanza la ficha
    }

    /*--------------------------------------------------------------------------------------------------------------------------------------------*/

    /*funcion que indica que el enemigo puntuo*/
    public void AddPointEnemy()
    {
        scoreEnemy++; //agrega punteje del enemigo
        globalScore.text = scoreEnemy + "|" + scorePlayer; //actualizar el puntaje
        if (scoreEnemy >= 2)
        {
            //aqui va la funcion que "reinicia la prtida"
            Invoke("ResetLevel", 0.01f);
        }
    }

    /*funcion que indica que el jugador puntuo*/
    public void AddPointPlayer()
    {
        scorePlayer++; //agrega puntaje al jugador
        globalScore.text = scoreEnemy + "|" + scorePlayer; //actualizar el puntaje
        if (scorePlayer >= 2)
        {
            //aqui va la funcion que "reinicia la prtida"
            Invoke("ResetLevel", 0.01f);
        }
    }

    //funcion para agregar dinero al player. Quiza en un foturo se agregue un argumento 
    public void PlayerAddCash()
    {
        playerCash += 100;
    }

    /*funcion que resetea las estadisticas necesarias para otra ronda*/
    void ResetLevel()
    {
        refPlayer.transform.position = refPlayer.startPosition; //el jugador vuelve a la posicion de lanzamiento
        refAI.AI_RB.isKinematic = true;
        refAI.transform.position = refAI.startPosition; //el enemigo vuelve a la posicion de lanzamiento
        refAI.AI_RB.velocity = Vector2.zero; //se define la velocidad en cero para evitar que la ficha enemiga salga disparada antes de tiempo

        rock.SetActive(false);
        startParty = false; //se inicia la fase de preparacion
        scoreEnemy = 0; //se reinicia el score del enemigo
        scorePlayer = 0; //se reinicia el score del jugador
        globalScore.text = scoreEnemy + "|" + scorePlayer; //actualizar el puntaje
        StartPowerUpsPanel();
    }
}
