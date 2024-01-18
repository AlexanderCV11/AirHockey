using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_MOV1 : MonoBehaviour
{
    public float forceX;
    public float forceY;
    public Rigidbody2D rbENY;
    public Collider2D colPLY;

    // Start is called before the first frame update
    void Start()
    {
        rbENY = GetComponent<Rigidbody2D>();
        rbENY.velocity = new Vector2(forceX, forceY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == colPLY)
        {
            float temp;

            temp = ((rbENY.velocity.x / Mathf.Abs(rbENY.velocity.x)) * 10) /*+ Mathf.Abs(rbENY.velocity.y)*/;
            rbENY.velocity = new Vector2(temp, rbENY.velocity.y);

            if (Mathf.Abs(rbENY.velocity.x) < Mathf.Abs(rbENY.velocity.y))
            {
                temp = ((rbENY.velocity.y / Mathf.Abs(rbENY.velocity.y)) * 10) /*+ Mathf.Abs(rbENY.velocity.x)*/;
                rbENY.velocity = new Vector2(rbENY.velocity.x, temp);
            }
        }
    }
}
