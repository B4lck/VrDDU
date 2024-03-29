using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ketchup : MonoBehaviour
{
    public LayerMask TargetLayer;
    public GameObject KetchupStribe;
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, TargetLayer)) 
            // Send en raycast ud fra toppen og hvis den rammer tallerkenen
        { 
            Tallerken tal = hit.transform.GetComponent<Tallerken>(); 
            if (tal.ingredienser.Count > 0)
            {
                if (tal.ingredienser[tal.ingredienser.Count - 1].ingredientType == Ingredient.IngredientType.Bund)
                {
                    // Hvis det er en bund som er under
                    tal.add(Instantiate(KetchupStribe, tal.transform.position, Quaternion.Euler(0,0,0)).GetComponent<Ingredient>());
                }
            }
        }
    }
}
