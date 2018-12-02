using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInventory : MonoBehaviour
{

    public static RessourceTank NULL = new RessourceTank();

    public List<RessourceTank> ressourcesList;

    public RessourceTank getStruct(Ressource ressource)
    {
        foreach (RessourceTank rT in ressourcesList)
        {
            if (rT.ressource.Equals(ressource))
            {
                return rT;
            }
        }
        return RessourceInventory.NULL;
    }

    public bool contain(Ressource ressource)
    {
        return !getStruct(ressource).Equals(RessourceInventory.NULL);
    }

    public int nbElementsTotal(Ressource ressource)
    {
        RessourceTank rT = getStruct(ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            return rT.number;
        }
        else
        {
            return 0;
        }
    }

    public void add(Ressource ressource)
    {
        RessourceTank rT = getStruct(ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            rT.number = rT.number + 1;
            print(nbElementsTotal( ressource));
        }
        else
        {
            rT = new RessourceTank();
            rT.ressource = ressource;
            rT.number = 1;
            rT.numberLimit = 99; // Limite le nombre de ressource à 99 par défaut
            ressourcesList.Add(rT);
        }
    }

    public void remove(Ressource ressource)
    {
        RessourceTank rT = getStruct(ressource);
        //numberRessources = rT.number;
        if (!rT.Equals(RessourceInventory.NULL))
        {
            if (rT.number > 0)
            {
                rT.number = rT.number - 1;
                print(nbElementsTotal(ressource));



             

                //numberRessources = numberRessources - 1;
                //rT.number = numberRessources;
                print(rT.number);
                //return true;
            }
        }
        //return false;
    }

    public int getLimit(Ressource ressource)
    {
        RessourceTank rT = getStruct(ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            return rT.numberLimit;
        }
        return -1;
    }

    public List<RessourceTank> getRessourcesNeededConstruct()
    {
        List<RessourceTank> res = new List<RessourceTank>();
        if(!ressourcesList.Equals(new List<RessourceTank>()))
        {
            foreach (RessourceTank rT in ressourcesList)
            {
                if (rT.neededToConstruct)
                {
                    res.Add(rT);
                }
            }
        }
        return res;
    }

    
    public List<RessourceTank> getRessourcesNeededTransport()
    {
        List<RessourceTank> res = new List<RessourceTank>();
        foreach (RessourceTank rT in ressourcesList)
        {
            if (rT.neededToTransport)
            {
                res.Add(rT);
            }
        }
        return res;
    }
}


[System.Serializable]
public class RessourceTank
{
    public Ressource ressource;
    public int number;
    public int numberLimit;
    public int numberToConstruct;
    public int numberToTransport;
    //public int numberToCraft;
    public bool neededToTransport;
    public bool neededToConstruct;
    //public bool neededToCraft;
}