using UnityEngine.Audio;
using UnityEngine;

public class RoastAble : MonoBehaviour
{
    public int RoastStatus = 0; // Hvor langt den er med at riste

    public Material[] RoastMaterials = new Material[3]; // Materialerne
    public AudioSource LydEffekt; // Stege lyd effekten
    public ParticleSystem StegeEffekt; // Stege partiklen

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = RoastMaterials[0]; // Altid start som r�
    }

    public void Roast()
    {
        RoastStatus += 1; // Bliv mere stegt
        RoastStatus = Mathf.Clamp(RoastStatus, 0, 2); // Den m� ikke blive mere end 2
        gameObject.GetComponent<Renderer>().material = RoastMaterials[RoastStatus]; // �ndre materialen
    }

    private void OnCollisionEnter(Collision hit) // N�r objektet r�r noget andet.
    {
        Stegepande hitPande = hit.gameObject.GetComponent<Stegepande>();
        if (hitPande != null) // Hvis objektet har komponentet Stegepande, alts� at det er en stegepande.
        {
            if (hitPande.Roasting != gameObject && hitPande.Heated) // Og hvis stege panden ikke steger noget andet imens.
            {
                hitPande.StartRoasting(gameObject); // Begynd at stege det her.
                LydEffekt.Play();                   // Afspil lydeffekt.
                StegeEffekt.Play();                 // Afspil partikel effekt.
            }
        }
    }

    private void OnCollisionExit(Collision hit) // N�r objektet stopper med at r�re noget.
    {
        Stegepande hitPande = hit.gameObject.GetComponent<Stegepande>();
        if (hitPande != null) // Hvis den stopper med at r�re en Stegepande.
        {
            if (hitPande.Roasting == gameObject) // Og hvis panden var i gang med at stege det her objekt.
            {
                hitPande.StopRoasting(); // Stop med at steg.
                LydEffekt.Stop();        // Stop med at afspille lyd effekten.
                StegeEffekt.Stop();      // Stop med at afspille partikel effekten.
            }
        }
    }
}