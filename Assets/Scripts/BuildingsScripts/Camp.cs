using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
    }

    public void Update()
    {
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
        //progressionBuild.transform.rotation = Quaternion.LookRotation(progressionBuild.transform.position - Camera.main.transform.position);
        progressionBuild.transform.rotation = Camera.main.transform.rotation;
        if(progressionBuild.text == "100%")
        {
            progressionBuild.text = "";
        }
        foreach (Citizen citizen in listWorkers)
        {
            if (citizen.group != Citizen.Group.Collect) FireWorker(citizen);
            break;
        }
        if (!done)
        {
            if (!isConstruct)
            {
                needRessources = true;
                needTools = true;
            }
            askSupplyToConstruct();
            Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
            alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
            GetComponent<MeshRenderer>().material.color = alphaColor;
            done = true;
        }

        if (!isConstruct)
        {
            if (!enoughToolsToBuild)
            {
                askSupplyToConstruct();
            }
            else if (!enoughToolsToBuild)
            {
                askSupplyToConstruct();
            }
            else
            {

                if (timeToBuild <= passedTimedBuild)
                {
                    isConstruct = true;
                    foreach (RessourceTank r in inventory.getRessourcesNeededConstruct())
                    {
                        for (int i = 0; i < r.numberToConstruct; i++)
                        {
                            inventory.remove(r.ressource);
                            totalNbr.Remove(r.ressource);
                        }

                    }

                    foreach (Tool t in toolsInventory.getToolsNeededConstruct())
                    {
                        for (int i = 0; i < t.nbToConstruct; i++)
                        {
                            toolsInventory.remove(t);
                            toolText.text = (int.Parse(toolText.text) - 1).ToString();
                        }

                    }
                }
            }
        }
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
