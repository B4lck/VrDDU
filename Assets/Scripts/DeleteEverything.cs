using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEverything : MonoBehaviour
{
    public LayerMask DoNotDelete;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.layer == DoNotDelete) { Debug.Log("Hello world!"); return; }
        Debug.Log("Deleted " + hit.transform.name);
        Destroy(hit.gameObject);
    }
}
