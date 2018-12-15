using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Better Camp")]
public class CarrierDecisionBetterCamp : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return IsBetterCamp(controler);
    }

    public bool IsBetterCamp(FSMControler controler)
    {
        Building[] buildings = FindObjectsOfType<Building>();
        Building target = controler.target.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();

        foreach (RessourceTank rt in controler.GetComponent<RessourceInventory>().ressourcesList)
        {


            foreach (Building building in buildings)

            {
                if (building.tag == "Camp" && building.isPlaced && building.isConstruct)
                {
                    foreach (RessourceTank rT in building.GetComponent<RessourceInventory>().ressourcesList)
                    {
                        if (rT.number >= rt.numberToTransport)
                        {
                            controler.target = building.gameObject;
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }
}