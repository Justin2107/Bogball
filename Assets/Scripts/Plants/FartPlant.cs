using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script causes the player to be shot in the reverse direction of where they land on the plant. This causes the plant to be activated,
//and unable to be activated again until regenerating
public class FartPlant : MonoBehaviour
{

    public float fartForce = 100f;
    //How long until the plant regenerates (in seconds)
    public float regenTime = 3f;

    Collider2D myCollider;
    Rigidbody2D playerRb;
    Vector2 forceDirection;

    private void Start()
    {

        myCollider = GetComponent<Collider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            forceDirection = collision.transform.position - transform.position;
            ActivateFart();

        }

    }

    void ActivateFart()
    {

        //Need to add animation code here
        playerRb.AddForce(forceDirection * fartForce, ForceMode2D.Impulse);
        myCollider.enabled = false;
        StartCoroutine(Regenerate());

    }

    IEnumerator Regenerate()
    {

        yield return new WaitForSeconds(regenTime);

        myCollider.enabled = true;
        //Need to add animation code here

    }
}
