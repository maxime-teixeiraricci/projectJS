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
        Building[] buildings = FindObjectsOfType<Building>();
        Citizen[] citizens = FindObjectsOfType<Citizen>();


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
