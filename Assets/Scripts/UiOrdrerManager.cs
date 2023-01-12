using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiOrdrerManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] sprites;
    /*
     0. Bund 
     1. Bacon
     2. Bøf
     3. Ketchup
     4. Tomat
     5. Top
     */
    private BurgerOrderManager OrderManager;
    public GameObject timerText;

    public List<GameObject> AktiveSprites;
    public Image canvas;

    private void Awake()
    {
        OrderManager = gameObject.GetComponent<BurgerOrderManager>();
    }

    public void UpdateUi()
    {
        
        foreach (GameObject aSprite in AktiveSprites) {
            Destroy(aSprite);
        }
        AktiveSprites.Clear();


        // Draw the orders
        foreach (Order ordre in OrderManager.Orders)
        {
            if (!ordre) continue;
            int x = System.Array.IndexOf(OrderManager.Orders, ordre);
            foreach (Ingredient.IngredientType ingredient in ordre.ingredienser) {
                int y = System.Array.IndexOf(ordre.ingredienser.ToArray(), ingredient);
                int i = 0;
                switch (ingredient)
                {
                    case Ingredient.IngredientType.Bund:
                        i = 0;
                        break;
                    case Ingredient.IngredientType.Bacon:
                        i = 1;
                        break;
                    case Ingredient.IngredientType.Bøf:
                        i = 2;
                        break;
                    case Ingredient.IngredientType.Ketchup:
                        i = 3;
                        break;
                    case Ingredient.IngredientType.Tomat:
                        i = 4;
                        break;
                    case Ingredient.IngredientType.Top:
                        i = 5;
                        break;
                    default:
                        break;
                }
                //Lav objekterne
                GameObject obj = Instantiate(sprites[i], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), canvas.transform);
                GameObject timer = Instantiate(timerText, new Vector3(0,0,0), new Quaternion(0,0,0,0), canvas.transform);
                //Placer dem
                obj.transform.localPosition = new Vector3(x * 34,y * 10,0);
                timer.transform.localPosition = new Vector3(x * 34, -20);
                //Indstil timeren teksten
                timer.GetComponent<TextMeshProUGUI>().text = Mathf.Round(ordre.timer).ToString();
                //Tilføj dem til listen
                AktiveSprites.Add(timer);
                AktiveSprites.Add(obj);
            }
        }
    }

    private void Update()
    {
        UpdateUi();
    }
}
