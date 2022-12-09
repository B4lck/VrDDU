using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<Ingredient.IngredientType> ingredienser;
    public float timer;
    public void OrderConstructor(List<Ingredient.IngredientType> ingredients, float time)
    {
        this.ingredienser = ingredients;
        this.timer = time;
        Debug.Log("Oprettede en ordre");
    }
}
