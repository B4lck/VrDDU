using UnityEngine;
using System;
using System.Collections.Generic;

public class BurgerOrderManager : MonoBehaviour
{
    [SerializeField]
    public Order[] Orders = new Order[3];

    public AudioSource RigtigLydEffekt;
    private UiOrdrerManager UIManager;

    public void Awake()
    {
        UIManager = gameObject.GetComponent<UiOrdrerManager>();
    }

    public void CreateNewOrder(Order TargetOrder)
    {
        for (int i = 0; i < Orders.Length; i++)
        {
            if (Orders[i] == null)
            {
                Orders[i] = TargetOrder;
                break;
            }
        }
        UIManager.UpdateUi();
    }

    public void CheckOrder(List<Ingredient> Burger)
    {

        bool CorrectOrder;
        foreach (Order order in Orders)
        {
            Debug.Log(order);
            if (order == null) { continue; } // Hvis ikke ordren er sat, s� lad v�r med at tjekke den
            CorrectOrder = true; // Reset 

            for (int i = 0; i < order.ingredienser.Count; i++) //Check ingredienserne igennem p� ordren
            {
                Debug.Log(Burger[i].ingredientType + " fra burgeren");
                Debug.Log(order.ingredienser[i] + " fra ordreren");
                if (Burger[i] == null) { CorrectOrder = false;  break; } //Hvis ikke burgeren har flere ingredienser, s� er det ikke den rigtige burger
                if (order.ingredienser[i] != Burger[i].ingredientType) //Hvis ingrediens typen ikke matcher er det ikke den rigtige burger
                {
                    Debug.Log("Ikke det samme");
                    CorrectOrder = false;
                    break;                
                }
            }

            if (CorrectOrder) // Hvis den ikke har fundet en fejl i burgeren, s� er det den rigtige burger.
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
        _ing.Clear();
        Debug.Log("Rigtigt!");
        UIManager.UpdateUi();
    }

    void WrongOrder(List<Ingredient> _ing)
    {
        foreach (Ingredient ingredient in _ing)
        {
            Destroy(ingredient.gameObject);
        }
        _ing.Clear();
        Debug.Log("Forkert!");
        UIManager.UpdateUi();
    }

    private void Start()
    {
        Order order1 = gameObject.AddComponent(typeof(Order)) as Order;
        order1.OrderConstructor(new List<Ingredient.IngredientType>()
        {
            Ingredient.IngredientType.Bund,
            Ingredient.IngredientType.B�f,
            Ingredient.IngredientType.Bacon,
            Ingredient.IngredientType.Top,
        }, 180f);
        Order order2 = gameObject.AddComponent(typeof(Order)) as Order;
        order2.OrderConstructor(new List<Ingredient.IngredientType>()
        {
            Ingredient.IngredientType.Bund,
            Ingredient.IngredientType.B�f,
            Ingredient.IngredientType.Tomat,
            Ingredient.IngredientType.Top,
        }, 180f);
        Order order3 = gameObject.AddComponent(typeof(Order)) as Order;
        order3.OrderConstructor(new List<Ingredient.IngredientType>()
        {
            Ingredient.IngredientType.Bund,
            Ingredient.IngredientType.B�f,
            Ingredient.IngredientType.Tomat,
            Ingredient.IngredientType.Bacon,
            Ingredient.IngredientType.Top,
        }, 180f);
        CreateNewOrder(order1);
        CreateNewOrder(order2);
        CreateNewOrder(order3);
    }
}
