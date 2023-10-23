using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoost : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ficha")
        {
            collision.GetComponent<Ficha>().rb.velocity *= 2;
            Destroy(gameObject);
        }
    }
}
