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
            target.give(rT.ressource,citizen);
        }
    }

}
