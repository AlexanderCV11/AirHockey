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
    public PowerUps[] powers;

    /*variables de score*/
    private int scoreEnemy = 0; //score del enemigo
    private int scorePlayer = 0; //score del jugador
    public int playerCash; //dinero del jugador
    public int enemyCash; //dinero del enemigo
    public TextMeshProUGUI playerScore; //texto de score
    public TextMeshProUGUI enemyScore; //texto de score
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
        enemyScore.text = "" + scoreEnemy; //actualizar el puntaje
    }

    /*funcion que indica que el jugador puntuo*/
    public void AddPointPlayer()
    {
        scorePlayer++; //agrega puntaje al jugador
        playerScore.text = "" + scorePlayer; //actualizar el puntaje
    }

    //funcion para agregar dinero al player. Quiza en un foturo se agregue un argumento 
    public void PlayerAddCash()
    {
        playerCash += 100;
    }

    /*funcion que resetea las estadisticas necesarias para otra ronda*/
    public void ResetLevel()
    {
        /*refPlayer.transform.position = refPlayer.startPosition; //el jugador vuelve a la posicion de lanzamiento
        refPlayer.vfx.SetActive(false);
        refAI.rbENY.isKinematic = true;
        refAI.transform.position = refAI.startPosition; //el enemigo vuelve a la posicion de lanzamiento
        refAI.rbENY.velocity = Vector2.zero; //se define la velocidad en cero para evitar que la ficha enemiga salga disparada antes de tiempo*/
        refPlayer.Reset();
        refPlayer.vfx.SetActive(false);
        refPlayer.force = 300;
        refPlayer.forceAfterCollision = 10f;

        refAI.Restart();
        powers[0].selected = false;
        powers[1].selected = false;
        powers[2].selected = false;

        rock.SetActive(false);
        startParty = false; //se inicia la fase de preparacion
        scoreEnemy = 0; //se reinicia el score del enemigo
        scorePlayer = 0; //se reinicia el score del jugador
        enemyScore.text = "" + scoreEnemy; //actualizar el puntaje enemigo
        playerScore.text = "" + scorePlayer; //actualizar el puntaje del jugador
        StartPowerUpsPanel();
    }
}
