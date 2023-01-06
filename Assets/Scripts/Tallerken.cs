using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tallerken : MonoBehaviour
{
    public List<Ingredient> ingredienser = new List<Ingredient>();
    public AudioSource LydEffekt;

    public OrderManager orderManager;


    public void add(Ingredient ingredient)
    {
        ingredienser.Add(ingredient);
        ingredient.gameObject.GetComponent<XrOffsetGrabInterable>().enabled = false;
        ingredient.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        LydEffekt.Play();
        if (ingredient.ingredientType == Ingredient.IngredientType.Top) { orderManager.CheckOrder(ingredienser); }
    }

    private void Update()
    {
        Vector3 offset = Vector3.zero;
        for (int i = 0; i < ingredienser.Count; i++)
        {
            Transform obj = ingredienser[i].transform;

            offset += new Vector3(0, obj.localScale.z / 2, 0);


            obj.position = transform.position + offset;


            obj.rotation = i == 0? Quaternion.Euler(90,0,0) : Quaternion.Euler(-90,0,0);
            if (ingredienser[i].ingredientType == Ingredient.IngredientType.Ketchup) obj.rotation = Quaternion.Euler(0, 0, 0);
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
