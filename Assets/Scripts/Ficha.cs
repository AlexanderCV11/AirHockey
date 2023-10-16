using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float MAX_DISTANCE;

    private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector2 startPosition, clampedPosition;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnMouseDrag()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Vector2 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        clampedPosition = dragPosition;

        float dragDistance = Vector2.Distance(startPosition, dragPosition);

        if (dragDistance > MAX_DISTANCE)
        {
            clampedPosition = startPosition + (dragPosition - startPosition).normalized * MAX_DISTANCE;
        }

        if (dragPosition.x > startPosition.x)
        {
            clampedPosition.x = startPosition.x;
        }

        transform.position = clampedPosition;
    }

    private void OnMouseUp()
    {
        Throw();
    }

    private void Throw()
    {
        rb.isKinematic = false;
        Vector2 throwVector = startPosition - clampedPosition;
        rb.AddForce(throwVector * force);
        
        float resetTime = 5f;
        Invoke("Reset", resetTime);
    }

    private void Reset()
    {
        transform.position = startPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
