using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sends the player back to the start of the level upon collision (activates gm script "PlayerDeath()")
public class SpikePlant : MonoBehaviour
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

            gm.PlayerDeath();

        }

    }

}
