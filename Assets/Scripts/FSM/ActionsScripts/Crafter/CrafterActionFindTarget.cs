using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Crafter/Find Building")]
public class CrafterActionFindTarget : FSMAction
{

    public override void Act(FSMControler controler)
    {
        FindBuilding(controler);
    }

    public void FindBuilding(FSMControler controler)
    {
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.isWalking = false;
        Building[] buildings = FindObjectsOfType<Building>();
        Citizen[] citizens = FindObjectsOfType<Citizen>();

        foreach (Building building in buildings)
            
        {
            if (building.tag == "Camp" && building.isPlaced && building.isConstruct)
            {
                foreach (RessourceTank rt in building.GetComponent<RessourceInventory>().ressourcesList)
                {
                    if (rt.number >= 10)
                    {
                        controler.target = building.gameObject;
                        return;
                    }
                }               
            }
        }


        foreach (Building building in buildings)
        {
            if (building.tag == "Camp" && building.isPlaced && building.isConstruct)
            {
                controler.target = building.gameObject;
                return;
            }
        }
    }
}
