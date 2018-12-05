using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : Building
{
    bool done = false;
    public bool enoughResourcesToCraft = false;

    [Header("Work")]
    public int numberWorkers;
    public List<Citizen> listWorkers;

    

    public void Start()
    {
        askSupplyToConstruct();
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
        GetComponent<MeshRenderer>().material.color = alphaColor;
    }

    public void Update()
    {
        foreach (Citizen citizen in listWorkers)
        {
            if (citizen.group != Citizen.Group.Collect) FireWorker(citizen);
            break;
        }
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

    public void HireWorker(Citizen citizen)
    {
        if (numberWorkers > listWorkers.Count && !listWorkers.Contains(citizen))
        {
            listWorkers.Add(citizen);
            citizen.workPlace = this;
        }
    }

    public void FireWorker(Citizen citizen)
    {
        if (listWorkers.Contains(citizen))
        {
            listWorkers.Remove(citizen);
            citizen.workPlace = null;
        }
    }
}
