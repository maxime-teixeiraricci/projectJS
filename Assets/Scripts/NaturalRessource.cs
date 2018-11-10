using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalRessource : MonoBehaviour
{
    public float recoltFrequence = 1.0f; // Nombre de ressource par seconde;
    public int numberRessource;
    public string nameCompetence;
    public GameObject ressource;

    public void Recolt(Citizen citizen)
    {
        if (citizen.ressources.Count != citizen.citizenSetting.inventorySize)
        {
            citizen.addRessource(Instantiate(ressource));
            numberRessource--;
            if (numberRessource <= 0)
            {
                Destroy(gameObject);
            }

        }
    }


    
}
