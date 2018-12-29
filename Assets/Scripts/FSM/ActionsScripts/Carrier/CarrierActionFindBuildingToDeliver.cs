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

        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.refreshSoundBools();

        if (controler.manualTarget != null)
        {
            controler.finalTarget = controler.manualTarget;

            return;
        }

        foreach (Building building in buildings)
        {
          
            if (building.needRessources && building.isPlaced)
            {
                controler.finalTarget = building.gameObject;
                foreach (RessourceTank rt in building.getRessourcesNeeded())
                {
                    
                    controler.GetComponent<Citizen>().ressourcesToTransport.add(rt);
                }
                if (building.needTools) {
                    foreach (Tool t in building.getToolsNeeded())
                    {

                        controler.GetComponent<Citizen>().toolsToTransport.add(t);
                    }
                    return;
                }
                else
                {
                    foreach(Tool t in controler.GetComponent<Citizen>().toolsToTransport.toolInventory)
                    {
                        t.neededToTransport = false;
                    }
                }
            }else if (building.needTools && building.isPlaced)
            {
                controler.finalTarget = building.gameObject;
                foreach (Tool t in building.getToolsNeeded())
                {

                    controler.GetComponent<Citizen>().toolsToTransport.add(t);
                }
                foreach (RessourceTank rT in controler.GetComponent<Citizen>().ressourcesToTransport.ressourcesList)
                {
                    rT.neededToTransport = false;
                }
                return;
            }
        }
    }
}
