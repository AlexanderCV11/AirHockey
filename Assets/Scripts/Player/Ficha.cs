using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour
{
    /*[SerializeField]*/ private float force = 400; //fuerza con la que sale disparada la ficha
    /*[SerializeField]*/ private float MAX_DISTANCE = 2; //maxima distancia para poder hacer drag

    public Vector2 startPosition, clampedPosition; //punto donde se empieza el drag y donde termina
    private Camera mainCamera; //referencia a la camara
    private GameManager refGM; //referencia al game manager
    
    private Rigidbody2D rb; //referencia a el rigidbody de la ficha
    public GameObject uiPoints; //referencia del prefab que muestra "+100" puntos cuando choca con el la ficha enemiga
    private bool icePower;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; //se obtiene la camara principal
        rb = GetComponent<Rigidbody2D>(); //se obtiene elrigidbody y las fiscas de la ficha
        rb.isKinematic = true; //se inicializa la ficha de tipo kinematic
        startPosition = transform.position; //se define que el punto de inicio de la ficha es donde empieza
        refGM = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnMouseDrag()
    {
        if (refGM.startParty)
        {
            SetPosition(); //funcion que se llama cuando se arrastra el mouse
        }
        
    }

    private void SetPosition()
    {
        Vector2 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //vector temporal que detecta la posicion del mouse
        clampedPosition = dragPosition;

        float dragDistance = Vector2.Distance(startPosition, dragPosition); //variable temporal que calcula la distancia de arrastre

        if (dragDistance > MAX_DISTANCE)
        {
            clampedPosition = startPosition + (dragPosition - startPosition).normalized * MAX_DISTANCE; //en caso de que el jugador arrastre el mouse mas de lo permitido
        }

        if (dragPosition.x > startPosition.x)
        {
            clampedPosition.x = startPosition.x; //no permite que se arrastre a la derecha
        }

        transform.position = clampedPosition;
    }

    private void OnMouseUp()
    {
        if (refGM.startParty)
        {
            Throw(); //funcion que se llama cuando se levanta el mouse 
        }
    }

    /*funcion para lanzar la ficha*/
    private void Throw()
    {
        rb.isKinematic = false; //la ficha se vulve un objeto dinamico para que tenga fisicas 
        Vector2 throwVector = startPosition - clampedPosition; //variable que calcula el angulo el vector (direccion y fuerza) en la que va a salir disparada la ficha
        rb.AddForce(throwVector * force); //se le agrega la fuerza previamente calculada

        Invoke("Reset", 5f); //dentro de 5 segundos se llamara a una funcion que restaura los valores de la ficha 
    }

    /*funcion que resetea la ficha a sus valores originales*/
    public void Reset()
    {
        transform.position = startPosition; //la ficha velve a su posicion original
        rb.isKinematic = true; //se veulve kinematic
        rb.velocity = Vector2.zero; //la velocidad se vuelve cero

        CancelInvoke("Reset"); /*se llama a una funcion de cancel un problema que hace que esta funcion se llame varias veces*/
    }

    /*funcion que activa el poder de fuego*/
    public void FirePower()
    {
        force *= 2; //aumenta la velocidad a la que este sale lanzado
    }

    /*funcion que activa el poder de hielo*/
    public void IcePower()
    {
        icePower = true;
    }

    /*funcion que spawnea objeti UI de puntos conseguidos cuando la ficha del jugador choca con la ficha enemiga*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 spawnPoint; //variable que guarda la posicion donde chocaron
        if (collision.gameObject.layer == 6 && !rb.isKinematic)
        {
            if (icePower)
            {
                refGM.refAI.IceHit();
            }
            spawnPoint = collision.transform.position; //guarda el punto de colision
            Instantiate(uiPoints, spawnPoint, uiPoints.transform.rotation); //spawnea los puntos en la ubicacion de choque
            refGM.PlayerAddCash();
        }
    }
}
