using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILaunch : MonoBehaviour
{
    private float force = -400f;
    private float MAX_DISTANCE = 2f;
    private Vector2 maxDrag;

    private Rigidbody2D AI_RB;
    private Vector2 startPosition, clampedPosition;
    private bool canSlow;
    // Start is called before the first frame update
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
        Debug.Log("Lanzando");
        clampedPosition = startPosition * MAX_DISTANCE;
        AI_RB.isKinematic = false;
        Vector2 throwVector = startPosition - clampedPosition;
        AI_RB.AddForce(throwVector * force);
        Invoke("LaunchFicha", 5f);
    }
}
