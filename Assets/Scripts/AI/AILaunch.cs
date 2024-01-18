using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILaunch : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float MAX_DISTANCE;

    public Collider2D collPLY;
    public Rigidbody2D rbENY; //ref del rigidbody de la ficha
    public Vector2 startPosition, clampedPosition;
    public float constVelocity;
    private Vector2 iceVelocity;

    void Start()
    {
        rbENY = GetComponent<Rigidbody2D>();
        rbENY.isKinematic = true;
        startPosition = transform.position;
    }

    public void LaunchFicha()
    {
        clampedPosition = new Vector2(8.0f, Random.Range(-MAX_DISTANCE, MAX_DISTANCE));
        rbENY.isKinematic = false;
        Vector2 throwVector = startPosition - clampedPosition;
        rbENY.AddForce(throwVector * force);

        constVelocity = Mathf.Abs(rbENY.velocity.x);
        if (Mathf.Abs(rbENY.velocity.y) > Mathf.Abs(rbENY.velocity.x))
        {
            constVelocity = Mathf.Abs(rbENY.velocity.y);
        }

        //Invoke("Reset", 5f);
    }

    public void Restart()
    {
        transform.position = startPosition;
        rbENY.isKinematic = true;
        rbENY.velocity = Vector2.zero;

        Invoke("LaunchFicha", 1f);
    }

    public void IceHit()
    {
        iceVelocity = rbENY.velocity;
        rbENY.isKinematic = true;
        rbENY.velocity = Vector2.zero;

        Invoke("ResetIce", 1.5f);
    }

    private void ResetIce()
    {
        rbENY.isKinematic = false;
        rbENY.velocity = iceVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == collPLY)
        {
            float _temp;

            _temp = ((rbENY.velocity.x / Mathf.Abs(rbENY.velocity.x)) * 10);
            rbENY.velocity = new Vector2(_temp, rbENY.velocity.y);

            if (Mathf.Abs(rbENY.velocity.y) > Mathf.Abs(rbENY.velocity.x))
            {
                _temp = ((rbENY.velocity.y / Mathf.Abs(rbENY.velocity.y)) * 10);
                rbENY.velocity = new Vector2(rbENY.velocity.x, _temp);
            }
        }
    }
}