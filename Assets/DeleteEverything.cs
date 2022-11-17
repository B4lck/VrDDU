using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEverything : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        Destroy(hit.gameObject);
    }
}
