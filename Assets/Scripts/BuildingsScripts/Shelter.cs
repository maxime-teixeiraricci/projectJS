using System.Collections;
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

    }
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

    void give(GameObject ressource, Citizen citizen)
    {
        /*
        Ressource r = ressource.GetComponent<RessourceContainer>().ressource;
        if (!citizen.inventaire.ContainsKey(r))
        {
            citizen.inventaire.Add(r, 1);
        }
        citizen.inventaire[r] += 1;
        citizen.ressources.Add(ressource);
        stock[r].RemoveAt(0);
        */
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

}
