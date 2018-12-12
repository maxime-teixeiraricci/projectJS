using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Carrier/Gather Resources")]
public class CarrierActionGatherResources : FSMAction
{

    public override void Act(FSMControler controler)
    {
        GatherResources(controler);
    }

    private void GatherResources(FSMControler controler)
    {
        Building target = controler.target.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach(RessourceTank rT in citizen.ressourcesToTransport.getRessourcesNeededTransport())
        {

            if (rT.number < rT.numberLimit)
            {
                target.give(rT.ressource, citizen);
            }
            
        }

        foreach (Tool t in citizen.toolsToTransport.getToolsNeededTransport())
        {

            if (t.number < t.numberLimit)
            {
                target.giveTool(t, citizen);
            }

        }
    }

}
