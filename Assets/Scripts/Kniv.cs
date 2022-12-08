using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kniv : MonoBehaviour
{
    public AudioSource LydEffekt;
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.GetComponent<Cutable>() != null)
        {
            hit.gameObject.GetComponent<Cutable>().cut();
            LydEffekt.Play();
        }
    }
}
