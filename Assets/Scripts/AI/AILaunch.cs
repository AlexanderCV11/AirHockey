using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILaunch : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float MAX_DISTANCE;

    private Rigidbody2D AI_RB;
    private Vector2 startPosition, clampedPosition;
    private bool canSlow;

    void Start()
    {
        AI_RB = GetComponent<Rigidbody2D>();
        AI_RB.isKinematic = true;
        startPosition = transform.position;
        LaunchFicha();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchFicha()
    {
        clampedPosition = new Vector2(Random.Range(startPosition.x, Random.Range(-MAX_DISTANCE, MAX_DISTANCE)), 
                                      Random.Range(startPosition.y, Random.Range(-MAX_DISTANCE, MAX_DISTANCE))).normalized * MAX_DISTANCE;
        //Debug.Log(clampedPosition);
        AI_RB.isKinematic = false;
        Vector2 throwVector = startPosition - clampedPosition;
        AI_RB.AddForce(throwVector * force);
        Invoke("Reset", 5f);
    }

    public void Reset()
    {
        transform.position = startPosition;
        AI_RB.isKinematic = true;
        AI_RB.velocity = Vector2.zero;
        canSlow = false;

        Invoke("LaunchFicha", 1f);
    }
}