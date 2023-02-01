using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{

    DayNightSprite[] dayNightSprites; 

    private void Start()
    {

        dayNightSprites = FindObjectsOfType<DayNightSprite>();

    }

    public void SwitchTime()
    {

        foreach(DayNightSprite s in dayNightSprites)
        {

            s.SwitchSprite();

        }

    }

}
