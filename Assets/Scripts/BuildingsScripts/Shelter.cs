﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : Building
{
    public int nX;
    public int nY;
    public float dX;
    public float dY;
    bool fait = false;
    private GameObject res;

    bool onPlane;

    public void Start()
    {
        res = GameObject.Find("ResourcesManager");
        askSupplyToConstruct();
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
        GetComponent<MeshRenderer>().material.color = alphaColor;
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

                    foreach (RessourceTank r in inventory.getRessourcesNeededConstruct())
                    {
                        for (int i = 0; i < r.numberToConstruct; i++)
                        {
                            inventory.remove(r.ressource);
                        }

                    }
                }
            }
        }
    }
    

    /*int i = 0;
    foreach(List<GameObject> listRessource in stock.Values)
    {
        foreach (GameObject r in listRessource)
        {
            r.transform.position = transform.position + new Vector3(dX / (nX - 1) * (i % nX) - dX * 0.5f, 0.5f, dY / (nY - 1) * (i / nY) - dY * 0.5f);
            i++;
        }
    }*/


    public override void addRessource(GameObject ressource, int quantite)
    {
        for (int i = 0; i < quantite; i++)
        {
            Ressource r = ressource.GetComponent<RessourceContainer>().ressource;
            inventory.add(r);
        }
    }

    void contain(Ressource ressource)
    {

    }

    public override void take(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) < inventory.getLimit(ressource))
        {
            citizen.ressourcesToTransport.remove(ressource);
            inventory.add(ressource);
        }
    }

    public override void give(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) > 0)
        {
            citizen.ressourcesToTransport.add(ressource);
            inventory.remove(ressource);
        }

        if (enoughConstructToBuild)
        {
            needRessource = false;
        }
        if (GetComponent<ToolInventory>())
        {
            // L'outil à construire
            Tool tool = GetComponent<ToolInventory>().activeTool;
            // La ressource qu'il faut pour le construire
            Ressource resNeed = tool.ressourceNeeded;

            // Le nombre de cette ressource qu'il faut
            int nbrRessource = tool.numberRessourcesNeeded;

            // Le nombre de la ressource contenu dans le batiment
            int stockRessource = GetComponent<RessourceInventory>().nbElementsTotal(ressource);

            if (stockRessource >= nbrRessource)
            {
                needRessource = false;
            }
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

    public override void askSupplyToConstruct()
    {
        //Demande au "camp de transporteurs" ou au dispacher des ressources

        //S'il y a assez de constructions on le signal
        
        if(!inventory.getRessourcesNeededConstruct().Equals(new List<RessourceTank>()))
        {
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

    private void OnTriggerEnter(Collider other)
    {

        // Mauvais collide : On entre en contact avec un item de la map
        if (!isPlaced)
        {
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }

        // Good Collide : le poitneur de la souris entre sur le terrain
        if (!isPlaced && other == GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
            goodPosition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        // Bon exit : On sort de la collision genante
        if (!isPlaced )
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
            goodPosition = true;
        }
         
        // Mauvais collide : On sort de la map
        if (!isPlaced && other == GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // si lorsqu'on quitte un collider, on entre dans un autre collider, notre objet reste alors impossible à placer.
        // On applique cette vérification uniquement aux batiments qui ne sont pas encore placés.
        // On vérifie bien de ne pas prendre en compte la collision avec le terrain
        if(!isPlaced && other != GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }
    }

}
