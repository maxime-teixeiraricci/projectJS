using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalRessource : MonoBehaviour
{
    public float recoltFrequence = 1.0f; // Nombre de ressource par seconde;
    public int numberRessource;
    public string nameCompetence;
    public GameObject ressource;
    public RessourceTank structRessource;
    public Ressource ressou;

    public void Recolt(Citizen citizen)
    {
        // if (citizen.ressources.Count != citizen.citizenSetting.inventorySize)
        //{
        //citizen.addRessource(Instantiate(ressource));
        RessourceTank rt = citizen.ressourcesToTransport.getStruct(structRessource.ressource);
        if (!rt.Equals(RessourceInventory.NULL))
        {
            if (rt.number < rt.numberLimit)
            {
                citizen.ressourcesToTransport.add(structRessource);
                numberRessource--;
                if (numberRessource <= 0)
                {
                    Destroy(gameObject);
                }

            }
        }
        else{
            citizen.ressourcesToTransport.add(structRessource);
            numberRessource--;
            if (numberRessource <= 0)
            {
                Destroy(gameObject);
            }
        }
        //numberRessource--;
    }


    
}
