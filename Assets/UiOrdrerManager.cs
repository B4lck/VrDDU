using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiOrdrerManager : MonoBehaviour
{
    public BurgerOrderManager orderMan;
    [SerializeField]
    public Sprite[] sprites;
    /*
     0. Bund 
     1. Bacon
     2. Bøf
     3. Ketchup
     4. Tomat
     5. Top
     */

    // Update is called once per frame
    void Update()
    {
        foreach (Order ordre in orderMan.Orders)
        {
            if (!ordre) continue;
            foreach (Ingredient.IngredientType ingredient in ordre.ingredienser)
            {
                int i = System.Array.IndexOf(ordre.ingredienser.ToArray(), ingredient);
                switch (ingredient)
                {
                    default:
                        break;
                }
            }
        }
    }
}
