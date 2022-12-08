using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tallerken : MonoBehaviour
{
    public List<Ingredient> ingredienser = new List<Ingredient>();


    void add(Ingredient ingredient)
    {
        ingredienser.Add(ingredient);
        ingredient.gameObject.GetComponent<XrOffsetGrabInterable>().enabled = false;
        ingredient.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        for (int i = 0; i < ingredienser.Count; i++)
        {
            Transform obj = ingredienser[i].transform;
            Debug.Log(obj.name);
            obj.position = transform.position + (Vector3.up * i * .2f);
            obj.rotation = transform.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<Ingredient>())
        {
            add(collision.gameObject.GetComponent<Ingredient>());
        }
    }


}
