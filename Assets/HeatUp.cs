using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        Stegepande hitPande = hit.GetComponent<Stegepande>();
        if (hitPande != null)
        {
            hitPande.Heated = true;
        }
    }


    private void OnTriggerExit(Collider hit)
    {
        Stegepande hitPande = hit.GetComponent<Stegepande>();
        if (hitPande != null)
        {
            hitPande.Heated = false;
        }
    }
}
