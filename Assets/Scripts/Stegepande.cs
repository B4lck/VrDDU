using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stegepande : MonoBehaviour
{
    [Header("Diverse")]
    public GameObject Roasting; // Hvad den er igang med at stege
    public float CookingTime = 5f; // Hvor lang tid det tager om at stege noget
    public bool Heated = false; // Om panden er varm

    float Timer = 0; // Midlertidig timer

    public void StopRoasting()
    {
        Roasting = null; // Stop med at riste noget
    }

    public void StartRoasting(GameObject _object)
    {
        if (Roasting != _object) // Hvis ikke allerede den er i gang med at riste noget
        {
            Timer = 0; // Genstart timeren
            Roasting = _object; // Begynd at riste den
        }
    }


    private void Update()
    {

        if (Heated) // Hvis panden er varm
        {
            Timer += Time.deltaTime; // Tilføj tid siden sidste frame til timeren
            if (Roasting != null && Timer > CookingTime) // Hvis der er gået mere end 5 sekunder
            {
                if (Roasting.GetComponent<RoastAble>() != null) // Og det som den rister er en roastable
                {
                    Roasting.GetComponent<RoastAble>().Roast(); // Aktiver Roast funktionen på roastablen
                    Timer = 0; // Genstarter timeren
                }
            }
        }
    }

}
