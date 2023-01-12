using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutable : MonoBehaviour
{
    public GameObject CutTo;
    public int Health = 2;

    public void cut()
    {
        Health -= 1;
        if (Health <= 0)
        {
            Instantiate(CutTo, transform.position + new Vector3(0,.1f,0), transform.rotation);
            Instantiate(CutTo, transform.position + new Vector3(0,.3f,0), transform.rotation);
            Instantiate(CutTo, transform.position + new Vector3(0,.5f,0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
