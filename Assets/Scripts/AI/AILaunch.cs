using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILaunch : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float MAX_DISTANCE;

    public Rigidbody2D AI_RB; //ref del rigidbody de la ficha
    public Vector2 startPosition, clampedPosition; 

    void Start()
    {
        AI_RB = GetComponent<Rigidbody2D>();
        AI_RB.isKinematic = true;
        startPosition = transform.position;
    }

    public void LaunchFicha()
    {
        clampedPosition = new Vector2(8.0f, Random.Range(-MAX_DISTANCE, MAX_DISTANCE));
        //Debug.Log(clampedPosition);
        AI_RB.isKinematic = false;
        Vector2 throwVector = startPosition - clampedPosition;
        AI_RB.AddForce(throwVector * force);
        Invoke("Reset", 5f);
    }

    public void Restart()
    {
        transform.position = startPosition;
        AI_RB.isKinematic = true;
        AI_RB.velocity = Vector2.zero;

        Invoke("LaunchFicha", 1f);
    }

    public void IceHit()
    {
        AI_RB.velocity /= 2;
    }
}