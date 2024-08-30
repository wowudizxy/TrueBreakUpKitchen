using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static event EventHandler Foodcaught;
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            
            //Foodcaught?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject, 0.1f); // ÑÓ³ÙÏú»Ù 0.1 Ãë
        }

        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
            Foodcaught?.Invoke(this, EventArgs.Empty);

        }

        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
