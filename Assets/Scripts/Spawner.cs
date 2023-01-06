using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public void Spawn(Transform trans)
    {
        Instantiate(ObjectToSpawn, trans.position, trans.rotation);
    }
}
