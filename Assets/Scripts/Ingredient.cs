using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [HideInInspector] // Det skal ignoreres i Unity programmet.
    public enum IngredientType // Forskellige typer af ingredienser
    {
        B�f,
        Bacon,
        Tomat,
        Bund,
        Top,
        Ketchup
    }

    public IngredientType ingredientType; // Hvilken type ingrediens er dette
}
