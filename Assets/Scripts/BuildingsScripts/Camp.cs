using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : Building
{
    bool done = false;
    // Liste des outils craftable par le batiment
    public Dictionary<Tool, int> toolsStock;

    public bool enoughResourcesToCraft = false;

    public void start()
    {
        askSupplyToConstruct();
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
        GetComponent<MeshRenderer>().material.color = alphaColor;
    }

    public void Update()
    {
        if (!done)
        {
            askSupplyToConstruct();
            Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
            alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
            GetComponent<MeshRenderer>().material.color = alphaColor;
            done = true;
        }

        if (!isConstruct)
        {
            if (!enoughConstructToBuild)
            {
                askSupplyToConstruct();
            }
            else
            {
                askForConstructer();
                if (alphaColor.a >= 1.0)
                {
                    isConstruct = true;
                }
            }
        }

        if (!enoughResourcesToCraft)
        {
            askSupplyToCraft();
        }
    }

    //Called when a citizen need to drop his ressources
    public override void addRessource(GameObject ressource, int quantite)
    {
        for (int i = 0; i < quantite; i++)
        {
            Ressource r = ressource.GetComponent<RessourceContainer>().ressource;
            inventory.add(r);
        }
    }

    //Fading animation to represent building construction
    public override void construct()
    {
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, colorStart.a + (1.0f / timeToBuild));
        GetComponent<MeshRenderer>().material.color = alphaColor;
    }

    public override void askForConstructer()
    {
        //Lors du placement du batiment il demande a être construit jusqu'à ce qu'il le soit
        //Demande au "camp de constructeurs" ou au dispacher
    }

    public void consommer()
    {
        //On consomme une ressource par habitant et par jour (à définir)
        //Si il n'y a plus de nourriture pour tenir le jour suivant, on appel askSupply
    }

    public void askSupplyToCraft()
    {
        // Demande la livrison de ressources, pour pouvoir construire des outils
        // Possiblement, demander un stock supérieur au strict minimum 
        // (Par exemple, demander 2x plus de ressources, pour éviter les changements incessants d'états)
        enoughResourcesToCraft = true;
    }

    public override void askSupplyToConstruct()
    {
        //Demande au "camp de transporteurs" ou au dispacher des ressources
        //S'il y a assez de constructions on le signal
        enoughConstructToBuild = true;
        foreach (RessourceTank r in inventory.getRessourcesNeededConstruct())
        {
            if (r.number < r.numberToConstruct)
            {
                enoughConstructToBuild = false;
            }
        }
    }
}
