using UnityEngine;
using System;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    [SerializeField]
    public Order[] Orders = new Order[3];

    public AudioSource RigtigLydEffekt;

    public void CreateNewOrder(Order TargetOrder)
    {
        for (int i = 0; i < Orders.Length; i++)
        {
            Debug.Log(Orders[i]);
            if (Orders[i] == null)
            {
                Orders[i] = TargetOrder;
                break;
            }
        }
    }

    public void CheckOrder(List<Ingredient> Burger)
    {
        Debug.Log("Jeg blev kaldet!");

        bool CorrectOrder;
        foreach (Order order in Orders)
        {
            if (order == null) { continue; } // Hvis ikke ordren er sat, så lad vær med at tjekke den
            CorrectOrder = true; // Reset 

            for (int i = 0; i < order.ingredienser.Count; i++) //Check ingredienserne igennem på ordren
            {
                Debug.Log(Burger[i].ingredientType + " fra burgeren");
                Debug.Log(order.ingredienser[i] + " fra ordreren");
                if (Burger[i] == null) { CorrectOrder = false;  break; } //Hvis ikke burgeren har flere ingredienser, så er det ikke den rigtige burger
                if (order.ingredienser[i] != Burger[i].ingredientType) //Hvis ingrediens typen ikke matcher er det ikke den rigtige burger
                {
                    Debug.Log("Ikke det samme");
                    CorrectOrder = false;
                    break;                
                }
            }

            if (CorrectOrder) // Hvis den ikke har fundet en fejl i burgeren, så er det den rigtige burger.
            {
                CompletedOrder(order, Burger); 
                return;
            }
            
        }
        WrongOrder(Burger);
    }

    void CompletedOrder(Order order, List<Ingredient> _ing)
    {
        Orders[Array.IndexOf(Orders, order)] = null;
        RigtigLydEffekt.Play();
        foreach (Ingredient ingredient in _ing)
        {
            Destroy(ingredient.gameObject);
        }
    }

    void WrongOrder(List<Ingredient> _ing)
    {
        foreach (Ingredient ingredient in _ing)
        {
            Destroy(ingredient.gameObject);
        }
    }

    private void Start()
    {
        Order order1 = gameObject.AddComponent(typeof(Order)) as Order;
        order1.OrderConstructor(new List<Ingredient.IngredientType>()
        {
            Ingredient.IngredientType.Bund,
            Ingredient.IngredientType.Bøf,
            Ingredient.IngredientType.Bacon,
            Ingredient.IngredientType.Top,
        }, 20f);
        Order order2 = gameObject.AddComponent(typeof(Order)) as Order;
        order2.OrderConstructor(new List<Ingredient.IngredientType>()
        {
            Ingredient.IngredientType.Bund,
            Ingredient.IngredientType.Bøf,
            Ingredient.IngredientType.Tomat,
            Ingredient.IngredientType.Top,
        }, 20f);
        Order order3 = gameObject.AddComponent(typeof(Order)) as Order;
        order3.OrderConstructor(new List<Ingredient.IngredientType>()
        {
            Ingredient.IngredientType.Bund,
            Ingredient.IngredientType.Bøf,
            Ingredient.IngredientType.Tomat,
            Ingredient.IngredientType.Bacon,
            Ingredient.IngredientType.Top,
        }, 20f);
        CreateNewOrder(order1);
    }
}
