using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stegepande : MonoBehaviour
{
    [Header("Diverse")]
    public GameObject Roasting;
    public float CookingTime = 5f;
    public bool Heated = false;

    float Timer = 0;

    public void StopRoasting()
    {
        Roasting = null;
    }

    public void StartRoasting(GameObject _object)
    {
        if (Roasting != _object)
        {
            Timer = 0;
            Roasting = _object;
        }
    }


    private void Update()
    {

        if (Heated)
        {
            Timer += Time.deltaTime;
            if (Roasting != null && Timer > CookingTime)
            {
                if (Roasting.GetComponent<RoastAble>() != null)
                {
                    Roasting.GetComponent<RoastAble>().Roast();
                    Timer = 0;
                }
            }
        }
    }

}
