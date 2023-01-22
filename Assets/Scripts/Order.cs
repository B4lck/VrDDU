using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<Ingredient.IngredientType> ingredienser;                                    // Liste over ingredienser der er i ordren.
    public float timer;                                                                     // Timer over ordren, hvor lang tid der er tilbage
    public void OrderConstructor(List<Ingredient.IngredientType> ingredients, float time)   // Da unity's system ikke tillader constructors til klasser, så må jeg manuelt lave en
    {
        this.ingredienser = ingredients;
        this.timer = time;
    }

    private void Update() // Hvert frame
    {
        timer -= Time.deltaTime; // Fjern milisekunder siden sidste frame fra timeren
        if (timer <= 0) //Hvis timeren er under 0, så er tiden gået.
        {
            EndOrder();
        }
    }

    public void EndOrder() // Fjern ordren.
    {
        Destroy(this);
    }
}
