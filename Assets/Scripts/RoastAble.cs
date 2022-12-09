using UnityEngine.Audio;
using UnityEngine;

public class RoastAble : MonoBehaviour
{
    public int RoastStatus = 0;

    public Material[] RoastMaterials = new Material[3];
    public AudioSource LydEffekt;
    public ParticleSystem StegeEffekt;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = RoastMaterials[0];
    }

    public void Roast()
    {
        RoastStatus += 1;
        RoastStatus = Mathf.Clamp(RoastStatus, 0, 2);
        gameObject.GetComponent<Renderer>().material = RoastMaterials[RoastStatus];
    }

    private void OnCollisionEnter(Collision hit)
    {
        Stegepande hitPande = hit.gameObject.GetComponent<Stegepande>();
        if (hitPande != null)
        {
            if (hitPande.Roasting != gameObject && hitPande.Heated)
            {
                hitPande.StartRoasting(gameObject);
                LydEffekt.Play();
                StegeEffekt.Play();            }
        }
    }

    private void OnCollisionExit(Collision hit)
    {
        Stegepande hitPande = hit.gameObject.GetComponent<Stegepande>();
        if (hitPande != null)
        {
            if (hitPande.Roasting == gameObject)
            {
                hitPande.StopRoasting();
                LydEffekt.Stop();
                StegeEffekt.Stop();
            }
        }
    }
}