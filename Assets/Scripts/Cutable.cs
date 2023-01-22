using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutable : MonoBehaviour
{
    public GameObject CutTo; // Hvad skal den blive til
    public int Health = 2; // Hvor mange gange man skal skære den

    public void cut()
    {
        Health -= 1; // Fratræk et liv
        if (Health <= 0) // Hvis den ikke har flere liv
        {
            Instantiate(CutTo, transform.position + new Vector3(0,.1f,0), transform.rotation); // Spawn
            Instantiate(CutTo, transform.position + new Vector3(0,.3f,0), transform.rotation); // Spawn
            Instantiate(CutTo, transform.position + new Vector3(0,.5f,0), transform.rotation); // Spawn
            Destroy(gameObject); // Slet sig selv
        }
    }
}
