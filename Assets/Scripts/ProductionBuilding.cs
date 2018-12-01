﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionBuilding : Building {

    public void start()
    {
        askSupplyToConstruct();
        alphaColor = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
    }

    public void Update()
    {
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
            if (!stock.contain(r))
            {
                stock.add(r);
            }
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

    public void askSupplyToConstruct()
    {
        //Demande au "camp de transporteurs" ou au dispacher des ressources
        //S'il y a assez de constructions on le signal
        enoughConstructToBuild = true;
        foreach (RessourceTank r in ressourcesNeededToConstruct.ressourcesList)
        {
            RessourceTank rTStock = stock.getStruct(r.ressource);
            if (!rTStock.Equals(null) && rTStock.number <= r.number)
            {
                enoughConstructToBuild = false;
            }
        }
    }
}
