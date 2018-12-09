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
            if (building.needRessource && building.isPlaced)
            {
                controler.finalTarget = building.gameObject;
                foreach (RessourceTank rt in building.getRessourcesNeeded())
                {
                    
                    controler.GetComponent<Citizen>().ressourcesToTransport.add(rt);
                }
                return;
            }
        }
    }
}
