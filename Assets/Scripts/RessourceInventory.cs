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
            if (rT.ressource == ressource)
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
            rT.number++;
        }
        else
        {
            rT = new RessourceTank();
            rT.ressource = ressource;
            rT.number = 1;
            int buildingLimit = gameObject.GetComponent<Building>().ressourcesLimitStock.getLimit(ressource);
            if (buildingLimit != -1)
            {
                rT.limitNb = buildingLimit;
            }
            else
            {
                rT.limitNb = 99; // Limite le nombre de ressource à 99 par défaut
            }

        }
    }

    public bool remove(Ressource ressource)
    {
        RessourceTank rT = getStruct(ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            if (rT.number > 0)
            {
                rT.number--;
                return true;
            }
        }
        return false;
    }

    public int getLimit(Ressource ressource)
    {
        RessourceTank rT = getStruct(ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            return rT.limitNb;
        }
        return -1;
    }
}


[System.Serializable]
public struct RessourceTank
{
    public Ressource ressource;
    public int number;
    public int limitNb;
}