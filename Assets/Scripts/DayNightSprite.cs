using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSprite : MonoBehaviour
{

    public Sprite daySprite;
    public Sprite nightSprite;

    SpriteRenderer spriteRenderer;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();

    }

    public void SwitchSprite()
    {

        if (gm.flipped)
        {

            spriteRenderer.sprite = nightSprite;

        }
        else
        {

            spriteRenderer.sprite = daySprite;

        }

    }
}
