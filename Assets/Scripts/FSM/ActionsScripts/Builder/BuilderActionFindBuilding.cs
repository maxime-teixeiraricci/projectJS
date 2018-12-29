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
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.refreshSoundBools();

        Building[] buildings = FindObjectsOfType<Building>();
        Citizen[] citizens = FindObjectsOfType<Citizen>();


        if(controler.manualTarget != null)
        {
            controler.target = controler.manualTarget;
            return;
        }

        // S'il y a un transporteur avec une cible, prendre sa cible
        foreach(Citizen cit in citizens)
        {
            if(cit.GetComponent<Citizen>().group.ToString() == "Transport" && cit.GetComponent<FSMControler>().finalTarget != null)
            {
                controler.target = cit.GetComponent<FSMControler>().finalTarget;
                return;
            }
        }

        foreach (Building building in buildings)
        {
            if (!building.isConstruct && building.enoughConstructToBuild && building.enoughToolsToBuild && building.isPlaced)
            {
                controler.target = building.gameObject;
                return;
            }
        }

        foreach (Building building in buildings)
        {
            if (!building.isConstruct && building.enoughConstructToBuild && building.isPlaced)
            {
                controler.target = building.gameObject;
                return;
            }
        }

        foreach (Building building in buildings)
        {
            if (!building.isConstruct && building.enoughToolsToBuild && building.isPlaced)
            {
                controler.target = building.gameObject;
                return;
            }
        }

        foreach (Building building in buildings)
        {
            if (!building.isConstruct && building.isPlaced)
            {
                controler.target = building.gameObject;
                return;
            }
        }
    }
}
