using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kniv : MonoBehaviour
{
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.GetComponent<Cutable>() != null)
        {
            Debug.Log("I hit " + hit.gameObject.name);
            hit.gameObject.GetComponent<Cutable>().cut();
        }
    }
}
