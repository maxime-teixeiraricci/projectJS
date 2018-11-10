using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalRessource : MonoBehaviour
{
    public float recoltFrequence = 1.0f; // Nombre de ressource par seconde;
    public string nameCompetence;
    public GameObject ressource;

    public void Recolt(Citizen citizen)
    {
        citizen.addRessource(ressource);
    }


    
}
