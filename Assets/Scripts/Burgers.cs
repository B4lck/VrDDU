using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burgers : MonoBehaviour
{
    public List<Ingredient.IngredientType> Hamburger = new List<Ingredient.IngredientType>()
    {
        Ingredient.IngredientType.Bund,
        Ingredient.IngredientType.Ketchup,
        Ingredient.IngredientType.Bøf,
        Ingredient.IngredientType.Top
    };
    public List<Ingredient.IngredientType> Bacon = new List<Ingredient.IngredientType>()
    {
        Ingredient.IngredientType.Bund,
        Ingredient.IngredientType.Ketchup,
        Ingredient.IngredientType.Bøf,
        Ingredient.IngredientType.Bacon,
        Ingredient.IngredientType.Top
    };
    public List<Ingredient.IngredientType> DoubleBacon = new List<Ingredient.IngredientType>()
    {
        Ingredient.IngredientType.Bund,
        Ingredient.IngredientType.Ketchup,
        Ingredient.IngredientType.Bøf,
        Ingredient.IngredientType.Bacon,
        Ingredient.IngredientType.Bacon,
        Ingredient.IngredientType.Top
    };
    public List<Ingredient.IngredientType> Tomat = new List<Ingredient.IngredientType>()
    {
        Ingredient.IngredientType.Bund,
        Ingredient.IngredientType.Ketchup,
        Ingredient.IngredientType.Bøf,
        Ingredient.IngredientType.Tomat,
        Ingredient.IngredientType.Top
    };
    public List<Ingredient.IngredientType> Vegan = new List<Ingredient.IngredientType>()
    {
        Ingredient.IngredientType.Bund,
        Ingredient.IngredientType.Ketchup,
        Ingredient.IngredientType.Tomat,
        Ingredient.IngredientType.Top
    };
    public List<Ingredient.IngredientType> MandeMand = new List<Ingredient.IngredientType>()
    {
        Ingredient.IngredientType.Bund,
        Ingredient.IngredientType.Ketchup,
        Ingredient.IngredientType.Bøf,
        Ingredient.IngredientType.Tomat,
        Ingredient.IngredientType.Bacon,
        Ingredient.IngredientType.Top
    };
}
