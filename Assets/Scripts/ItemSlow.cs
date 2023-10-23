using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ficha")
        {
            collision.GetComponent<Ficha>().canSlow = true;
            Destroy(gameObject);
        }
    }
}
