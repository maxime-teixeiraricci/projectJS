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
    public RessourceTank structRessource;
    public Ressource ressou;

    public TextMesh health;

    float timetoGrow = 2.0f;

    float timePassed;

    private void Update()
    {
        health.transform.rotation = Camera.main.transform.rotation;
        if (health.text == "100%")
        {
            health.text = "";
        }
        Growth();
        updateText();
        //Debug.Log("Nb ressources = " + 1.0f / timetoGrow);
    }

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

    public void Growth()
    {
        if(numberRessource < maxRessource)
        {
            numberRessource += Time.deltaTime / timetoGrow;
        }
    }

    public void updateText()
    {
        health.text = ((int)(numberRessource / maxRessource * 100)).ToString() + "%";
    }


    
}
