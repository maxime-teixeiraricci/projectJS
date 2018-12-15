using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Crafter/Better Camp")]
public class CrafterDecisionBetterCamp : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return IsBetterCamp(controler);
    }

    public bool IsBetterCamp(FSMControler controler)
    {
        Building[] buildings = FindObjectsOfType<Building>();

        foreach (Building building in buildings)

        {
            if (building.tag == "Camp" && building.isPlaced && building.isConstruct)
            {
                foreach (RessourceTank rt in building.GetComponent<RessourceInventory>().ressourcesList)
                {
                    if (rt.number >= 10)
                    {
                        controler.target = building.gameObject;
                        return true;
                    }
                }
            }
        }

        return false;
    }
}