using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    GameManager gm;

    private void Start()
    {

        gm = FindObjectOfType<GameManager>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            gm.NextLevel();

        }

    }

}
