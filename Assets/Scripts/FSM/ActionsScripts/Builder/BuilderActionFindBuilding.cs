using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Builder/Find Building")]
public class BuilderActionFindBuilding : FSMAction
{

    public override void Act(FSMControler controler)
    {
        FindBuildingNotConstruct(controler);
    }

    public void FindBuildingNotConstruct(FSMControler controler)
    {
        Building[] buildings = FindObjectsOfType<Building>();

        foreach(Building building in buildings)
        {
            if (!building.isConstruct)
            {
                controler.target = building.gameObject;
            }
        }

    }
}
