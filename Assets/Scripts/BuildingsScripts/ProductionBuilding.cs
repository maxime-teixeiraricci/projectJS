using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : Building {
    bool fait = false;
    public void start()
    {
        askSupplyToConstruct();
        alphaColor = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
    }

    public void Update()
    {
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
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

}
