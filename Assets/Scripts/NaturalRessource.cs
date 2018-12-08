using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalRessource : MonoBehaviour
{
    public float recoltFrequence = 1.0f; // Nombre de ressource par seconde;
    public float numberRessource;
    public int maxRessource;
    public string nameCompetence;
    public GameObject ressource;

    float timetoGrow = 1000.0f;

    float timePassed;

    private void Update()
    {
        Growth();
        //Debug.Log("Nb ressources = " + 1.0f / timetoGrow);
    }

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

    public void Growth()
    {
        if(numberRessource < maxRessource)
        {
            numberRessource += 1.0f / timetoGrow;
        }
    }


    
}
