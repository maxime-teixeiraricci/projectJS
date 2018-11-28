using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : Building
{
    public int nX;
    public int nY;
    public float dX;
    public float dY;

    private GameObject res;

    public void Start()
    {
        res = GameObject.Find("ResourcesManager");
    }

    public void Update()
    {
        int i = 0;
        foreach(List<GameObject> listRessource in stock.Values)
        {
            foreach (GameObject r in listRessource)
            {
                r.transform.position = transform.position + new Vector3(dX / (nX - 1) * (i % nX) - dX * 0.5f, 0.5f, dY / (nY - 1) * (i / nY) - dY * 0.5f);
                i++;
            }
        }
    }
    public override void addRessource(GameObject ressource, int quantite)
    {
        for (int i = 0; i < quantite; i++)
        {
            Ressource r = ressource.GetComponent<RessourceContainer>().ressource;
            if (!stock.ContainsKey(r))
            {
                stock.Add(r, new List<GameObject>());
            }
            stock[r].Add(ressource);
            res.GetComponent<ResourcesCount>().Add(r);
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

    public override void construct()
    {
        throw new System.NotImplementedException();
    }

    public override void askForConstructer()
    {
        throw new System.NotImplementedException();
    }
}
