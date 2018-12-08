using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RessourceInventory : MonoBehaviour
{

    public static RessourceTank NULL = new RessourceTank();

    public List<RessourceTank> ressourcesList;

    public RessourceTank getStruct(Ressource ressource)
    {
        print(ressourcesList.Count);
        foreach (RessourceTank rT in ressourcesList)
        {
            //print(ressource.name + " - " + rT.ressource.name);
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


    public void add(RessourceTank ressourceTank)
    {
        RessourceTank rT = getStruct(ressourceTank.ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            rT.number = rT.number + 1;
        }
        else
        {
            RessourceTank res = new RessourceTank();
            ressourceTank.copy(res);
            res.neededToTransport = true;
            res.ressource = ressourceTank.ressource;
            res.numberToTransport = 1;
            res.numberLimit = 10; // Limite le nombre de ressource à 99 par défaut
            res.number = 1;
            if (ressourceTank.numberToConstruct != -1)
            {
                res.numberToTransport = ressourceTank.numberToConstruct;
                res.numberLimit = ressourceTank.numberToConstruct; // Limite le nombre de ressource à 99 par défaut
                res.number = 0;
            }
            Debug.Log(res.ressource);
            ressourcesList.Add(res);
        }
    }

    public void add(Ressource ressource)
    {
        RessourceTank rT = getStruct(ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            rT.number = rT.number + 1;
        }
        else
        {
            rT = new RessourceTank();
            rT.ressource = ressource;
            rT.number = 1;
            rT.numberLimit = 2; // Limite le nombre de ressource à 99 par défaut
            ressourcesList.Add(rT);
        }
    }

    public void addSpecific(Ressource ressource, int number)
    {
        RessourceTank rT = getStruct(ressource);
        if (!rT.Equals(RessourceInventory.NULL))
        {
            rT.numberToTransport = number;
            rT.neededToTransport = true;
        }
        else
        {
            rT = new RessourceTank();
            rT.ressource = ressource;
            rT.number = 0;
            rT.numberToTransport = number;
            rT.neededToTransport = true;
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
                //print(nbElementsTotal(ressource));



             

                //numberRessources = numberRessources - 1;
                //rT.number = numberRessources;
                //print(rT.number);
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
                Debug.Log("Value number new RT = " + rT.number);
                Debug.Log("Value numberToTransport new RT = " + rT.numberToTransport);
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

    public bool sameRessource(RessourceTank ressourceTank)
    {
        return ressourceTank.ressource == ressource;
    }

    public RessourceTank copy()
    {
        RessourceTank rt = new RessourceTank();
        rt.ressource = ressource;
        rt.number = number;
        rt.numberLimit = numberLimit;
        rt.numberToConstruct = numberToConstruct;
        rt.numberToTransport = numberToTransport;
        rt.neededToTransport = neededToTransport;
        rt.neededToConstruct = neededToConstruct;
        return rt;
    }

    public void copy(RessourceTank rt)
    {
        rt.ressource = ressource;
        rt.number = number;
        rt.numberLimit = numberLimit;
        rt.numberToConstruct = numberToConstruct;
        rt.numberToTransport = numberToTransport;
        rt.neededToTransport = neededToTransport;
        rt.neededToConstruct = neededToConstruct;
    }
}