using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [HideInInspector]
    public enum IngredientType
    {
        Bøf,
        Bacon,
        Tomat,
        Bund,
        Top
    }

    public IngredientType ingredientType;
}
