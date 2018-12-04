using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Carrier/Find Building To Deliver")]
public class CarrierActionFindBuildingToDeliver : FSMAction
{

    public override void Act(FSMControler controler)
    {
        FindBuildingToDeliver(controler);
    }

    public void FindBuildingToDeliver(FSMControler controler)
    {
        Building[] buildings = FindObjectsOfType<Building>();

        foreach (Building building in buildings)
        {
            if (building.needRessource)
            {
                controler.finalTarget = building.gameObject;
                controler.GetComponent<Citizen>().ressourcesToTransport = building.getRessourcesNeeded();
                return;
            }
        }
    }
}
