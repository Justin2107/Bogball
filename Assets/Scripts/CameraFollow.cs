using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 offset;
    Vector3 modifiedOffset;
    public float smoothValue = 0.1f;
    public Transform playerTransform;
    public PlayerMovement playerMovement;

    private void Start()
    {

        modifiedOffset = offset;

    }

    private void FixedUpdate()
    {

        if (playerMovement.flipDirection == 1)
        {

            modifiedOffset.y = offset.y;

        }
        else
        {

            modifiedOffset.y = -offset.y;

        }
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + modifiedOffset, smoothValue);

    }


}
