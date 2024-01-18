using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_MOV : MonoBehaviour
{
    public float forceX;
    public float forceY;
    public Rigidbody2D rbPLY;
    public Collider2D colENY;

    private Camera mainCamera; //referencia a la camara
    private float MAX_DISTANCE = 2; //maxima distancia para poder hacer drag
    public Vector2 startPosition, clampedPosition; //punto donde se empieza el drag y donde termina
    
    // Start is called before the first frame update
    void Start()
    {
        rbPLY = GetComponent<Rigidbody2D>();
        //rbPLY.velocity = new Vector2(forceX, forceY);

        mainCamera = Camera.main; //se obtiene la camara principal
        startPosition = transform.position; //se define que el punto de inicio de la ficha es donde empieza
        
    }

    private void OnMouseDrag()
    {
        SetPosition(); //funcion que se llama cuando se arrastra el mouse
    }

    private void OnMouseUp()
    {
        Throw(); //funcion que se llama cuando se levanta el mouse
    }

    public void Throw()
    {
        rbPLY.isKinematic = false;
        Vector2 throwVector = startPosition - clampedPosition; //variable que calcula el angulo el vector (direccion y fuerza) en la que va a salir disparada la ficha
        rbPLY.AddForce(new Vector2(throwVector.x * forceX, throwVector.y * forceX)); //se le agrega la fuerza previamente calculada
    }

    public void SetPosition()
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == colENY)
        {
            float temp;

            temp = ((rbPLY.velocity.x / Mathf.Abs(rbPLY.velocity.x)) * 10) /*+ Mathf.Abs(rbPLY.velocity.y)*/;
            rbPLY.velocity = new Vector2(temp, rbPLY.velocity.y);

            if (Mathf.Abs(rbPLY.velocity.x) < Mathf.Abs(rbPLY.velocity.y))
            {
                temp = ((rbPLY.velocity.y / Mathf.Abs(rbPLY.velocity.y)) * 10) /*+ Mathf.Abs(rbPLY.velocity.x)*/;
                rbPLY.velocity = new Vector2(rbPLY.velocity.x, temp);
            }
        }
    }
}
