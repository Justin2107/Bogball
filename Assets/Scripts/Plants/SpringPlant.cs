using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlant : MonoBehaviour
{

    public float springForce; 
    Vector2 forceDirection;
    Rigidbody2D playerRb;

    private void Start()
    {

        forceDirection = transform.up;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            ActivateSpringPlant();

        }
    }
    void ActivateSpringPlant()
    {

        playerRb.AddForce(forceDirection * springForce, ForceMode2D.Impulse);

    }

}
