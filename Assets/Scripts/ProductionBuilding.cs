using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionBuilding : Building {
    bool fait = false;
    public void start()
    {
        askSupplyToConstruct();
        alphaColor = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
    }

    public void Update()
    {
        if (!fait)
        {
            askSupplyToConstruct();
            Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
            alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
            GetComponent<MeshRenderer>().material.color = alphaColor;
            fait = true;
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
        alphaColor = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor.a += 1.0f / timeToBuild;
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

    public override void give(Ressource ressource, Citizen citizen)
    {
        throw new System.NotImplementedException();
    }

    public override void take(Ressource ressource, Citizen citizen)
    {
        throw new System.NotImplementedException();
    }
}
